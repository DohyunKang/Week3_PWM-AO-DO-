using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;
using System.Collections.Generic;

namespace Week3
{
    public partial class Form1 : Form
    {
        // AO 관련 변수
        private NationalInstruments.DAQmx.Task writeTask;  // AO Task
        private NationalInstruments.DAQmx.Task analogReadTask;  // AI Task for AO
        private AnalogSingleChannelWriter writer;
        private AnalogSingleChannelReader analogReader;
        private double ao_frequency;
        private double ao_dutyCycle;
        private double ao_highTime;
        private double ao_lowTime;
        private double ao_pwmElapsed;
        private bool ao_pwmStateHigh;
        private double ao_HighV;
        private double ao_LowV;
        private bool flagAO = false;  // AO 스위치 상태 플래그

        // DO 관련 변수
        private NationalInstruments.DAQmx.Task digitalWriteTask;  // DO Task
        private NationalInstruments.DAQmx.Task digitalReadTask;  // AI Task for DO
        private DigitalSingleChannelWriter digitalWriter;
        private AnalogSingleChannelReader digitalReader;
        private double do_frequency;
        private double do_dutyCycle;
        private double do_highTime;
        private double do_lowTime;
        private double do_pwmElapsed;
        private bool do_pwmStateHigh;
        private double do_HighV;
        private double do_LowV;
        private bool flagDO = false;  // DO 스위치 상태 플래그

        private DateTime lastPwmTime = DateTime.Now;
        private DateTime lastEdgeTime = DateTime.Now;
        private double previousVoltage = 0;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            writeTask = new NationalInstruments.DAQmx.Task();
            analogReadTask = new NationalInstruments.DAQmx.Task();
            digitalWriteTask = new NationalInstruments.DAQmx.Task();
            digitalReadTask = new NationalInstruments.DAQmx.Task();

            // AO 채널 설정
            writeTask.AOChannels.CreateVoltageChannel("Dev1/ao0", "", 0.0, 10.0, AOVoltageUnits.Volts);
            analogReadTask.AIChannels.CreateVoltageChannel("Dev1/ai0", "", AITerminalConfiguration.Rse, 0.0, 10.0, AIVoltageUnits.Volts);

            // DO 채널 설정
            digitalWriteTask.DOChannels.CreateChannel("Dev1/port0/line0", "", ChannelLineGrouping.OneChannelForAllLines);
            digitalReadTask.AIChannels.CreateVoltageChannel("Dev1/ai2", "", AITerminalConfiguration.Rse, 0.0, 10.0, AIVoltageUnits.Volts);

            writer = new AnalogSingleChannelWriter(writeTask.Stream);
            analogReader = new AnalogSingleChannelReader(analogReadTask.Stream);
            digitalWriter = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
            digitalReader = new AnalogSingleChannelReader(digitalReadTask.Stream);

            ao_frequency = 50;
            ao_dutyCycle = 50;
            ao_HighV = 5;
            ao_LowV = 0;

            do_frequency = 50;
            do_dutyCycle = 50;
            do_HighV = 5;
            do_LowV = 0;

            // 매개변수 없는 메서드를 호출하여 기본 파라미터 설정
            UpdatePWMParametersAO();
            UpdatePWMParametersDO();
        }

        // 매개변수가 없는 기본 AO 파라미터 업데이트 메서드
        private void UpdatePWMParametersAO()
        {
            UpdatePWMParametersAO(ao_frequency, ao_dutyCycle, ao_HighV, ao_LowV);  // 기존 메서드 호출
        }

        // 매개변수가 없는 기본 DO 파라미터 업데이트 메서드
        private void UpdatePWMParametersDO()
        {
            UpdatePWMParametersDO(do_frequency, do_dutyCycle, do_HighV, do_LowV);  // 기존 메서드 호출
        }

        // AO -> AI 데이터 처리 시작
        private void StartMultimediaTimerAO()
        {
            System.Threading.Tasks.Task.Run(() => GeneratePWMAndReadAIAsync());
        }

        // DO -> AI 데이터 처리 시작
        private void StartMultimediaTimerDO()
        {
            System.Threading.Tasks.Task.Run(() => GenerateDigitalPWM());
        }

        private void StopMultimediaTimerAO()
        {
            flagAO = false;
            lastPwmTime = DateTime.Now;
        }

        private void StopMultimediaTimerDO()
        {
            flagDO = false;
        }

        private async System.Threading.Tasks.Task GeneratePWMAndReadAIAsync()
        {
            flagAO = true;
            lastPwmTime = DateTime.Now; // 시작할 때 시간을 초기화

            while (flagAO)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - lastPwmTime;
                double elapsedSeconds = deltaTime.TotalSeconds;

                ao_pwmElapsed += elapsedSeconds;
                lastPwmTime = currentTime;

                if (ao_pwmStateHigh && ao_pwmElapsed >= ao_highTime)
                {
                    writer.WriteSingleSample(true, ao_LowV);
                    ao_pwmStateHigh = false;
                    ao_pwmElapsed = 0;
                }
                else if (!ao_pwmStateHigh && ao_pwmElapsed >= ao_lowTime)
                {
                    writer.WriteSingleSample(true, ao_HighV);
                    ao_pwmStateHigh = true;
                    ao_pwmElapsed = 0;
                }

                double inputVoltage = analogReader.ReadSingleSample();

                if (previousVoltage <= (ao_LowV + 0.1) && inputVoltage >= (ao_HighV - 0.1))
                {
                    TimeSpan periodTime = currentTime - lastEdgeTime;
                    lastEdgeTime = currentTime;

                    double period = periodTime.TotalSeconds * 1000;
                    double calculatedFrequency = 1000 / period;
                    double actualDutyCycle = (ao_highTime / periodTime.TotalSeconds) * 100;

                    this.Invoke((MethodInvoker)delegate
                    {
                        lblPeriod.Text = period.ToString("F2");
                        lblFrequency.Text = calculatedFrequency.ToString("F2");
                        lblDuty.Text = actualDutyCycle.ToString("F2");
                    });
                }

                previousVoltage = inputVoltage;

                this.Invoke((MethodInvoker)delegate
                {
                    ContinuousWfg.PlotYAppend(inputVoltage, elapsedSeconds);
                });

                await System.Threading.Tasks.Task.Delay(1);
            }

            lastPwmTime = DateTime.Now;
        }

        private async System.Threading.Tasks.Task GenerateDigitalPWM()
        {
            flagDO = true;
            lastPwmTime = DateTime.Now; // 시작할 때 시간을 초기화

            while (flagDO)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - lastPwmTime;
                double elapsedSeconds = deltaTime.TotalSeconds;

                do_pwmElapsed += elapsedSeconds;
                lastPwmTime = currentTime;

                // PWM 상태 변경
                if (do_pwmStateHigh && do_pwmElapsed >= do_highTime)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, false); // Low 상태로 전환
                    do_pwmStateHigh = false;
                    do_pwmElapsed = 0;
                }
                else if (!do_pwmStateHigh && do_pwmElapsed >= do_lowTime)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, true); // High 상태로 전환
                    do_pwmStateHigh = true;
                    do_pwmElapsed = 0;
                }

                // AI에서 DO 신호 읽기 (DO 신호를 아날로그 값으로 읽음)
                double inputVoltage = digitalReader.ReadSingleSample();

                if (previousVoltage <= (do_LowV + 0.1) && inputVoltage >= (do_HighV - 0.1))
                {
                    TimeSpan periodTime = currentTime - lastEdgeTime;
                    lastEdgeTime = currentTime;

                    double period = periodTime.TotalSeconds * 1000; // ms 단위로 변환
                    double calculatedFrequency = 1000 / period;
                    double actualDutyCycle = (do_highTime / periodTime.TotalSeconds) * 100;

                    // 주기, 빈도, 듀티 사이클 업데이트
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblPeriod2.Text = period.ToString("F2");
                        lblFrequency2.Text = calculatedFrequency.ToString("F2");
                        lblDuty2.Text = actualDutyCycle.ToString("F2");
                    });
                }

                previousVoltage = inputVoltage;

                // 실시간 그래프에 신호 추가
                this.Invoke((MethodInvoker)delegate
                {
                    ContinuousWfg2.PlotYAppend(inputVoltage, elapsedSeconds);
                });

                // 비동기적으로 1ms 대기
                await System.Threading.Tasks.Task.Delay(1);
            }

            lastPwmTime = DateTime.Now;
        }




        // DO 신호 출력 함수 (디지털 출력)
        private void WriteDigitalValue(bool isHigh)
        {
            digitalWriter.WriteSingleSampleSingleLine(true, isHigh);
        }

        private void UpdatePWMParametersAO(double frequency, double dutyCycle, double HighV, double LowV)
        {
            double period = 1.0 / frequency;
            double highTime = period * (dutyCycle / 100.0);
            double lowTime = period - highTime;

            ao_frequency = frequency;
            ao_highTime = highTime;
            ao_lowTime = lowTime;
            ao_HighV = HighV;
            ao_LowV = LowV;
        }

        private void UpdatePWMParametersDO(double frequency, double dutyCycle, double HighV, double LowV)
        {
            double period = 1.0 / frequency;
            double highTime = period * (dutyCycle / 100.0);
            double lowTime = period - highTime;

            // 실제로 이 값들이 변경되고 있는지 MessageBox로 확인
            MessageBox.Show(String.Format("!! DO Parameters Updated - Frequency: {0}, Duty Cycle: {1}, High Voltage: {2}, Low Voltage: {3}",
                                          frequency, dutyCycle, HighV, LowV));

            do_frequency = frequency;
            do_highTime = highTime;
            do_lowTime = lowTime;
            do_HighV = HighV;
            do_LowV = LowV;
        }

        private void ApplyButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                double frequencyAO, dutyCycleAO, HighVAO, LowVAO;
                double frequencyDO, dutyCycleDO, HighVDO, LowVDO;

                if (switch3.Value)
                {
                    frequencyDO = 1000 / (double)PeriodEdit.Value;
                    dutyCycleDO = (double)DutyEdit.Value;
                    HighVDO = (double)HighEdit.Value;
                    LowVDO = (double)LowEdit.Value;

                    lblPeriod2.Text = (1000 / frequencyDO).ToString("F2");
                    lblFrequency2.Text = frequencyDO.ToString("F2");
                    lblDuty2.Text = dutyCycleDO.ToString("F2");

                    MessageBox.Show(string.Format("DO Parameters Updated - Frequency: {0}, Duty Cycle: {1}, High Voltage: {2}, Low Voltage: {3}", frequencyDO, dutyCycleDO, HighVDO, LowVDO));
                    UpdatePWMParametersDO(frequencyDO, dutyCycleDO, HighVDO, LowVDO);
                }
                else
                {
                    frequencyAO = 1000 / (double)PeriodEdit.Value;
                    dutyCycleAO = (double)DutyEdit.Value;
                    HighVAO = (double)HighEdit.Value;
                    LowVAO = (double)LowEdit.Value;

                    lblPeriod.Text = (1000 / frequencyAO).ToString("F2");
                    lblFrequency.Text = frequencyAO.ToString("F2");
                    lblDuty.Text = dutyCycleAO.ToString("F2");

                    UpdatePWMParametersAO(frequencyAO, dutyCycleAO, HighVAO, LowVAO);
                }

                MessageBox.Show("파라미터 업데이트 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show("파라미터 업데이트 중 오류 발생: " + ex.Message);
            }
        }

        private void CaptureButton_Click_1(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(CaptureButton_Click_1), sender, e);
                return;
            }

            List<double> capturedSignal = new List<double>();

            double calculatedPeriod = double.Parse(lblPeriod.Text);
            double calculatedDutyCycle = double.Parse(lblDuty.Text);

            double highTime = (calculatedDutyCycle / 100.0) * calculatedPeriod;
            double lowTime = calculatedPeriod - highTime;

            double timeStep = 1.0;

            for (double t = 0; t < calculatedPeriod; t += timeStep)
            {
                if (t < highTime)
                {
                    capturedSignal.Add(ao_HighV);
                }
                else
                {
                    capturedSignal.Add(ao_LowV);
                }
            }

            if (capturedSignal.Count > 0)
            {
                CaptureWfg.PlotY(capturedSignal.ToArray());
            }
        }

        private void CaptureButton2_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(CaptureButton2_Click), sender, e);
                return;
            }

            List<double> capturedSignal = new List<double>();

            double calculatedPeriod = double.Parse(lblPeriod2.Text);
            double calculatedDutyCycle = double.Parse(lblDuty2.Text);

            double highTime = (calculatedDutyCycle / 100.0) * calculatedPeriod;
            double lowTime = calculatedPeriod - highTime;

            double timeStep = 1.0;

            for (double t = 0; t < calculatedPeriod; t += timeStep)
            {
                if (t < highTime)
                {
                    capturedSignal.Add(1.0);
                }
                else
                {
                    capturedSignal.Add(0.0);
                }
            }

            if (capturedSignal.Count > 0)
            {
                CaptureWfg2.PlotY(capturedSignal.ToArray());
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            StopMultimediaTimerAO();
            StopMultimediaTimerDO();
            writer.WriteSingleSample(true, 0);
            ContinuousWfg.ClearData();
            ContinuousWfg2.ClearData();
        }

        private void switch1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (!flagAO)
            {
                StartMultimediaTimerAO();
            }
            else
            {
                StopMultimediaTimerAO();
            }
        }

        private void switch2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (!flagDO)
            {
                StartMultimediaTimerDO();
            }
            else
            {
                StopMultimediaTimerDO();
            }
        }
    }
}
