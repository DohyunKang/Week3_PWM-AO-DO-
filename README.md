
# PWM Capture and Measurement Project

## 설명
이 프로젝트는 PWM 신호를 생성하고, AO (Analog Output)와 DO (Digital Output)에서 발생하는 PWM 신호를 AI (Analog Input)로 읽어 실시간으로 그래프에 표시하는 기능을 제공합니다. 또한, 주기와 듀티 사이클을 측정하여 실시간으로 시각화하고, 캡처 기능을 통해 특정 시점의 신호를 기록할 수 있습니다.

## 기능
- **AO 및 DO 기반 PWM 생성**: 사용자가 설정한 주기와 듀티 사이클에 맞춰 PWM 신호를 생성합니다.
- **실시간 신호 측정 및 시각화**: 생성된 PWM 신호를 AI로 읽어 실시간으로 그래프에 표시합니다.
- **주기 및 듀티 사이클 측정**: PWM 신호의 주기, 듀티 사이클을 실시간으로 계산하여 UI에 표시합니다.
- **캡처 기능**: 실시간 그래프 데이터를 캡처하여 별도의 그래프에 표시하고 분석할 수 있습니다.
- **설정값 기반 커서 표시**: 사용자가 설정한 주기와 듀티 사이클 값을 기준으로 커서를 표시하여 신호 분석을 지원합니다.

## UI

### Main UI 화면

<img width="500" alt="MainUI" src="https://github.com/user-attachments/assets/72964dd2-02e0-40e6-9e28-875b48e7e1e9">

### PWM 신호 작동 화면

![PWM_AO - AI   DO - AI](https://github.com/user-attachments/assets/42a7549b-f357-424a-9e95-a297beb12cc2)

## 설치 방법

1. 이 저장소를 클론합니다:
   ```bash
   git clone https://github.com/your-username/pwm-capture-project.git


2. Visual Studio에서 프로젝트를 엽니다.
3. 필요한 NI DAQmx 드라이버가 설치되어 있는지 확인합니다.
4. 프로젝트를 빌드하고 실행합니다.

## 사용 방법

1. **주기 및 듀티 설정**: 주기(Period)와 듀티(Duty Cycle), 그리고 High Voltage와 Low Voltage 값을 설정합니다.
2. **Apply 버튼**: 설정한 주기와 듀티 값을 적용합니다.
3. **Start 버튼**: PWM 신호 생성을 시작합니다. 설정된 값에 따라 실시간으로 그래프에 신호가 나타납니다.
4. **Capture 버튼**: 현재의 PWM 신호를 캡처하여 별도의 그래프에 표시합니다.
5. **Reset 버튼**: 모든 그래프 데이터를 초기화하고 신호 생성을 중지합니다.
6. **실시간 측정**: 주기, 주파수, 듀티 사이클을 실시간으로 UI에 표시합니다.
7. **커서 분석**: 캡처된 신호에서 커서를 설정하여 이론적인 주기와 듀티 사이클을 시각적으로 확인할 수 있습니다.

## 주요 코드

### PWM 신호 생성 및 측정

```csharp
private async System.Threading.Tasks.Task GeneratePWMAndReadAIAsync()
{
    lastPwmTime = DateTime.Now;

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
}
```

## 요구 사항
- **Visual Studio 2019 이상**
- **NI DAQmx 드라이버**
- **National Instruments 하드웨어 (AI, AO, DO 지원)**

## 참고 문서
- [NI 공식 문서](https://www.ni.com)
- [Measurement & Automation Explorer (MAX) 사용법](https://www.ni.com/ko-kr/support/downloads/software-products/download.ni-measurement-automation-explorer-(max).html)
- [PWM 신호의 원리와 활용](https://example.com)

## 주의 사항
- AI 신호를 제대로 읽어오려면 하드웨어 연결 상태와 NI MAX 설정이 올바르게 되어 있는지 확인하세요.
- 캡처 버튼을 사용할 때 신호의 잡음이나 노이즈로 인해 오차가 발생할 수 있으니, 오실로스코프를 통해 실제 신호를 병행하여 확인하는 것이 좋습니다.

## 기여 방법
1. 프로젝트를 포크합니다.
2. 새로운 기능을 개발하거나 버그를 수정합니다.
3. 변경 사항을 커밋하고 푸시합니다.
4. 풀 리퀘스트를 생성합니다.

```
