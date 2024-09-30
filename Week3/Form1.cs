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

        private double appliedPeriod;
        private double appliedDutyCycle;

        private NationalInstruments.UI.XYCursor captureCursor;

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
            if (!flagAO)
            {
                flagAO = true;
                System.Threading.Tasks.Task.Run(() => GeneratePWMAndReadAIAsync());
            }
        }

        // DO -> AI 데이터 처리 시작
        private void StartMultimediaTimerDO()
        {
            if (!flagDO)
            {
                flagDO = true;
                System.Threading.Tasks.Task.Run(() => GenerateDigitalPWM());
            }
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
            lastPwmTime = DateTime.Now; // 시작할 때 시간을 초기화

            double totalHighTime = 0;  // 누적 high time을 저장
            double totalLowTime = 0;   // 누적 low time을 저장
            DateTime highStartTime = DateTime.Now;
            DateTime lowStartTime = DateTime.Now;

            while (flagAO)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - lastPwmTime;
                double elapsedSeconds = deltaTime.TotalSeconds;

                ao_pwmElapsed += elapsedSeconds;
                lastPwmTime = currentTime;

                // PWM 신호 생성 (고정된 파라미터로 신호를 만듦)
                if (ao_highTime == 0)
                {
                    writer.WriteSingleSample(true, ao_LowV);
                    totalHighTime = 0;
                    totalLowTime = 1000 / ao_frequency;  // 전체 주기를 Low 상태로 설정

                    // 입력된 값으로 UI 업데이트
                    UpdateUI1(totalLowTime, 0, ao_frequency);
                }
                else if (ao_lowTime == 0)
                {
                    writer.WriteSingleSample(true, ao_HighV);
                    totalHighTime = 1000 / ao_frequency;  // 전체 주기를 High 상태로 설정
                    totalLowTime = 0;

                    // 입력된 값으로 UI 업데이트
                    UpdateUI1(totalHighTime, 100, ao_frequency);
                }
                else if (ao_pwmStateHigh && ao_pwmElapsed >= ao_highTime)
                {
                    writer.WriteSingleSample(true, ao_LowV);
                    ao_pwmStateHigh = false;
                    ao_pwmElapsed = 0;
                    lowStartTime = DateTime.Now;  // Low 상태 시작 시점 기록
                }
                else if (!ao_pwmStateHigh && ao_pwmElapsed >= ao_lowTime)
                {
                    writer.WriteSingleSample(true, ao_HighV);
                    ao_pwmStateHigh = true;
                    ao_pwmElapsed = 0;
                    highStartTime = DateTime.Now;  // High 상태 시작 시점 기록
                }

                // AI 신호 측정 (실제 신호에서 rising/falling edge 탐지)
                double inputVoltage = analogReader.ReadSingleSample();

                // Rising edge 감지: low에서 high로 변환될 때
                if (previousVoltage <= (ao_LowV + 0.1) && inputVoltage >= (ao_HighV - 0.1))
                {
                    // Falling edge가 있었을 경우 low time 계산
                    if (lowStartTime != DateTime.MinValue)
                    {
                        TimeSpan lowTimeSpan = currentTime - lowStartTime;
                        totalLowTime = lowTimeSpan.TotalMilliseconds;
                    }

                    highStartTime = currentTime;  // Rising edge에서 high 시작
                }
                // Falling edge 감지: high에서 low로 변환될 때
                else if (previousVoltage >= (ao_HighV - 0.1) && inputVoltage <= (ao_LowV + 0.1))
                {
                    // Rising edge가 있었을 경우 high time 계산
                    if (highStartTime != DateTime.MinValue)
                    {
                        TimeSpan highTimeSpan = currentTime - highStartTime;
                        totalHighTime = highTimeSpan.TotalMilliseconds;
                    }

                    lowStartTime = currentTime;  // Falling edge에서 low 시작
                }

                // 실제 주기와 듀티 계산
                if (totalHighTime > 0 && totalLowTime > 0)
                {
                    double period = totalHighTime + totalLowTime;  // 주기 계산
                    double actualDutyCycle = (totalHighTime / period) * 100;  // 듀티 사이클 계산
                    double calculatedFrequency = 1000 / period;  // 주파수 계산

                    // UI에 표시
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblPeriod.Text = period.ToString("F2");
                        lblFrequency.Text = calculatedFrequency.ToString("F2");
                        lblDuty.Text = actualDutyCycle.ToString("F2");
                    });
                }

                previousVoltage = inputVoltage;

                // 실시간 그래프 업데이트
                this.Invoke((MethodInvoker)delegate
                {
                    ContinuousWfg.PlotYAppend(inputVoltage, elapsedSeconds);
                });

                await System.Threading.Tasks.Task.Delay(1);
            }

            lastPwmTime = DateTime.Now;
        }

        private void UpdateUI1(double period, double duty, double frequency)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblPeriod.Text = period.ToString("F2");
                lblFrequency.Text = frequency.ToString("F2");
                lblDuty.Text = duty.ToString("F2");  // 계산된 Duty가 아니라 입력된 Duty 그대로 표시
            });
        }


        // DO 신호 생성 및 AI 신호 측정 로직
        private async System.Threading.Tasks.Task GenerateDigitalPWM()
        {
            lastPwmTime = DateTime.Now; // 시작할 때 시간을 초기화

            double totalHighTime = 0;  // 누적 high time을 저장
            double totalLowTime = 0;   // 누적 low time을 저장
            DateTime highStartTime = DateTime.Now;
            DateTime lowStartTime = DateTime.Now;

            while (flagDO)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - lastPwmTime;
                double elapsedSeconds = deltaTime.TotalSeconds;

                do_pwmElapsed += elapsedSeconds;
                lastPwmTime = currentTime;

                // PWM 신호 생성
                if (do_highTime == 0)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, false);

                    totalHighTime = 0;
                    totalLowTime = 1000 / do_frequency;  // 전체 주기를 Low 상태로 설정

                    // 입력된 값으로 UI 업데이트
                    UpdateUI2(totalLowTime, 0, do_frequency);
                }
                else if (do_lowTime == 0)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, true);

                    totalHighTime = 1000 / do_frequency;  // 전체 주기를 High 상태로 설정
                    totalLowTime = 0;

                    // 입력된 값으로 UI 업데이트
                    UpdateUI2(totalHighTime,100, do_frequency);
                }
                else if (do_pwmStateHigh && do_pwmElapsed >= do_highTime)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, false);  // Low 상태로 전환
                    do_pwmStateHigh = false;
                    do_pwmElapsed = 0;
                    lowStartTime = DateTime.Now;  // Low 상태 시작 시점 기록
                }
                else if (!do_pwmStateHigh && do_pwmElapsed >= do_lowTime)
                {
                    digitalWriter.WriteSingleSampleSingleLine(true, true);  // High 상태로 전환
                    do_pwmStateHigh = true;
                    do_pwmElapsed = 0;
                    highStartTime = DateTime.Now;  // High 상태 시작 시점 기록
                }

                // AI 신호 측정
                double inputVoltage = digitalReader.ReadSingleSample();

                // 신호에서 rising edge (low to high) 감지
                if (previousVoltage <= (do_LowV + 0.1) && inputVoltage >= (do_HighV - 0.1))
                {
                    TimeSpan lowTimeSpan = currentTime - lowStartTime;
                    totalLowTime = lowTimeSpan.TotalMilliseconds;
                    highStartTime = currentTime;  // high 시작
                }
                // 신호에서 falling edge (high to low) 감지
                else if (previousVoltage >= (do_HighV - 0.1) && inputVoltage <= (do_LowV + 0.1))
                {
                    TimeSpan highTimeSpan = currentTime - highStartTime;
                    totalHighTime = highTimeSpan.TotalMilliseconds;
                    lowStartTime = currentTime;  // low 시작
                }

                // rising edge와 falling edge 모두 감지된 경우 주기 및 듀티 계산
                if (totalHighTime > 0 && totalLowTime > 0)
                {
                    double period = totalHighTime + totalLowTime;  // 주기 계산
                    double actualDutyCycle = (totalHighTime / period) * 100;  // 듀티 사이클 계산
                    double calculatedFrequency = 1000 / period;  // 주파수 계산

                    // 주기, 주파수, 듀티 사이클을 라벨에 표시
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblPeriod2.Text = period.ToString("F2");
                        lblFrequency2.Text = calculatedFrequency.ToString("F2");
                        lblDuty2.Text = actualDutyCycle.ToString("F2");
                    });
                }

                previousVoltage = inputVoltage;

                // 그래프 업데이트
                this.Invoke((MethodInvoker)delegate
                {
                    ContinuousWfg2.PlotYAppend(inputVoltage, elapsedSeconds);
                });

                await System.Threading.Tasks.Task.Delay(1);
            }

            lastPwmTime = DateTime.Now;
        }

        private void UpdateUI2(double period, double duty, double frequency)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lblPeriod2.Text = period.ToString("F2");
                lblFrequency2.Text = frequency.ToString("F2");
                lblDuty2.Text = duty.ToString("F2");  // 계산된 Duty가 아니라 입력된 Duty 그대로 표시
            });
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
                    HighVDO = 3.3;
                    LowVDO = 0;

                    lblPeriod2.Text = (1000 / frequencyDO).ToString("F2");
                    lblFrequency2.Text = frequencyDO.ToString("F2");
                    lblDuty2.Text = dutyCycleDO.ToString("F2");

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

                    // Apply된 주기와 듀티 저장
                    appliedPeriod = (double)PeriodEdit.Value;
                    appliedDutyCycle = (double)DutyEdit.Value;
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

            // 실시간 계산된 주기 및 듀티 사이클 값 사용 (캡처 버튼을 누른 당시의 값)
            double capturedPeriod = double.Parse(lblPeriod.Text);  // 캡처 버튼을 눌렀을 때의 실시간 주기
            double capturedDutyCycle = double.Parse(lblDuty.Text); // 캡처 버튼을 눌렀을 때의 실시간 듀티 사이클

            // highTime과 lowTime 계산 (실시간 측정값 기반)
            double capturedHighTime = (capturedDutyCycle / 100.0) * capturedPeriod;
            double capturedLowTime = capturedPeriod - capturedHighTime;

            // 실시간 데이터 기반의 PWM 신호 생성
            List<double> capturedSignal = new List<double>();
            double timeStep = 1.0; // 타임스텝(해상도)

            // 한 주기의 PWM 신호 생성
            for (double t = 0; t < capturedPeriod; t += timeStep)
            {
                if (t < capturedHighTime)
                {
                    capturedSignal.Add(ao_HighV);  // High 상태 (실시간 주기 및 듀티 사이클 기반)
                }
                else
                {
                    capturedSignal.Add(ao_LowV);   // Low 상태 (실시간 주기 및 듀티 사이클 기반)
                }
            }

            // 캡처된 신호를 그래프에 표시
            if (capturedSignal.Count > 0)
            {
                CaptureWfg.ClearData();  // 기존 데이터를 지우고
                CaptureWfg.PlotY(capturedSignal.ToArray());  // 새로운 실시간 측정 기반 신호 그리기
            }

            // ---- 커서 설정 (설정된 주기/듀티 사이클 값 기준) ----
            if (CaptureWfg.Cursors.Count > 0)
            {
                CaptureWfg.Cursors.Clear();  // 기존 커서 제거
            }

            var cursor = new NationalInstruments.UI.XYCursor(CaptureWfg.Plots[0]);
            CaptureWfg.Cursors.Add(cursor);

            // 기존 커서가 있는지 확인하고, 있으면 위치만 업데이트
            if (cursor == null)
            {
                captureCursor = new NationalInstruments.UI.XYCursor(CaptureWfg.Plots[0]);
                CaptureWfg.Cursors.Add(cursor);  // 처음에 한 번만 추가
                captureCursor.Color = System.Drawing.Color.Red;  // 커서 색상 설정
            }

            // 커서는 이론적인 설정값에 기반해서 찍음
            double theoreticalHighTime = (double)PeriodEdit.Value * (DutyEdit.Value / 100); // 설정값 기반
            cursor.XPosition = theoreticalHighTime;  // ontime 지점
            cursor.YPosition = ao_HighV;  // 설정된 HighV

            cursor.Color = System.Drawing.Color.Red;  // 커서 색상 설정

            // MessageBox로 실시간 측정값과 설정값 비교
            MessageBox.Show(string.Format("PeriodEdit Value: {0}\nDutyEdit Value: {1}\nTheoretical High Time: {2}",
                    PeriodEdit.Value, DutyEdit.Value, theoreticalHighTime), "Debug Info");
            MessageBox.Show(string.Format("실시간 Period: {0}\n실시간 DutyCycle: {1}\ncaptured High Time: {2}",
                            capturedPeriod, capturedDutyCycle, capturedHighTime), "Captured Info");
        }

        private void CaptureButton2_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(CaptureButton2_Click), sender, e);
                return;
            }

            // 실시간 계산된 주기 및 듀티 사이클 값 사용 (캡처 버튼을 누른 당시의 값)
            double capturedPeriod = double.Parse(lblPeriod2.Text);  // 캡처 버튼을 눌렀을 때의 실시간 주기
            double capturedDutyCycle = double.Parse(lblDuty2.Text); // 캡처 버튼을 눌렀을 때의 실시간 듀티 사이클

            // highTime과 lowTime 계산 (실시간 측정값 기반)
            double capturedHighTime = (capturedDutyCycle / 100.0) * capturedPeriod;
            double capturedLowTime = capturedPeriod - capturedHighTime;

            // 실시간 데이터 기반의 PWM 신호 생성
            List<double> capturedSignal = new List<double>();
            double timeStep = 1.0; // 타임스텝(해상도)

            // 한 주기의 PWM 신호 생성
            for (double t = 0; t < capturedPeriod; t += timeStep)
            {
                if (t < capturedHighTime)
                {
                    capturedSignal.Add(3.3);  // High 상태 (실시간 주기 및 듀티 사이클 기반)
                }
                else
                {
                    capturedSignal.Add(0.0);   // Low 상태 (실시간 주기 및 듀티 사이클 기반)
                }
            }

            // 캡처된 신호를 그래프에 표시
            if (capturedSignal.Count > 0)
            {
                CaptureWfg2.ClearData();  // 기존 데이터를 지우고
                CaptureWfg2.PlotY(capturedSignal.ToArray());  // 새로운 실시간 측정 기반 신호 그리기
            }

            // ---- 커서 설정 (설정된 주기/듀티 사이클 값 기준) ----
            if (CaptureWfg2.Cursors.Count > 0)
            {
                CaptureWfg2.Cursors.Clear();  // 기존 커서 제거
            }

            var cursor = new NationalInstruments.UI.XYCursor(CaptureWfg2.Plots[0]);
            CaptureWfg2.Cursors.Add(cursor);

            // 기존 커서가 있는지 확인하고, 있으면 위치만 업데이트
            if (cursor == null)
            {
                cursor = new NationalInstruments.UI.XYCursor(CaptureWfg2.Plots[0]);
                CaptureWfg2.Cursors.Add(cursor);  // 처음에 한 번만 추가
                cursor.Color = System.Drawing.Color.Red;  // 커서 색상 설정
            }

            // 커서는 이론적인 설정값에 기반해서 찍음
            double theoreticalHighTime = (double)PeriodEdit.Value * (DutyEdit.Value / 100); // 설정값 기반
            cursor.XPosition = theoreticalHighTime;  // ontime 지점
            cursor.YPosition = 3.3;  // 설정된 High 값

            cursor.Color = System.Drawing.Color.Red;  // 커서 색상 설정

            // MessageBox로 실시간 측정값과 설정값 비교
            MessageBox.Show(string.Format("PeriodEdit Value: {0}\nDutyEdit Value: {1}\nTheoretical High Time: {2}",
                    PeriodEdit.Value, DutyEdit.Value, theoreticalHighTime), "Debug Info");
            MessageBox.Show(string.Format("실시간 Period: {0}\n실시간 DutyCycle: {1}\ncaptured High Time: {2}",
                            capturedPeriod, capturedDutyCycle, capturedHighTime), "Captured Info");
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            StopMultimediaTimerAO();
            StopMultimediaTimerDO();
            writer.WriteSingleSample(true, 0);
            ContinuousWfg.ClearData();
            ContinuousWfg2.ClearData();
            CaptureWfg.ClearData();
            CaptureWfg2.ClearData();
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
