namespace Week3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.switch1 = new NationalInstruments.UI.WindowsForms.Switch();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CaptureButton2 = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.LowEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.HighEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.DutyEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.PeriodEdit = new NationalInstruments.UI.WindowsForms.NumericEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.CaptureWfg = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis2 = new NationalInstruments.UI.XAxis();
            this.yAxis2 = new NationalInstruments.UI.YAxis();
            this.ContinuousWfg = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.CaptureWfg2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot3 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis3 = new NationalInstruments.UI.XAxis();
            this.yAxis3 = new NationalInstruments.UI.YAxis();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ContinuousWfg2 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot4 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis4 = new NationalInstruments.UI.XAxis();
            this.yAxis4 = new NationalInstruments.UI.YAxis();
            this.label20 = new System.Windows.Forms.Label();
            this.switch2 = new NationalInstruments.UI.WindowsForms.Switch();
            this.switch3 = new NationalInstruments.UI.WindowsForms.Switch();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDuty2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblFrequency2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblPeriod2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureWfg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinuousWfg)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureWfg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinuousWfg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // switch1
            // 
            this.switch1.Location = new System.Drawing.Point(879, 633);
            this.switch1.Name = "switch1";
            this.switch1.OffColor = System.Drawing.Color.Yellow;
            this.switch1.OnColor = System.Drawing.Color.DeepSkyBlue;
            this.switch1.Size = new System.Drawing.Size(118, 96);
            this.switch1.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalSlide3D;
            this.switch1.TabIndex = 3;
            this.switch1.StateChanged += new NationalInstruments.UI.ActionEventHandler(this.switch1_StateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(876, 730);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Start/Stop (AO)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CaptureButton2);
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.LowEdit);
            this.groupBox1.Controls.Add(this.HighEdit);
            this.groupBox1.Controls.Add(this.DutyEdit);
            this.groupBox1.Controls.Add(this.PeriodEdit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ApplyButton);
            this.groupBox1.Controls.Add(this.CaptureButton);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(879, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 372);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // CaptureButton2
            // 
            this.CaptureButton2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CaptureButton2.Location = new System.Drawing.Point(171, 327);
            this.CaptureButton2.Name = "CaptureButton2";
            this.CaptureButton2.Size = new System.Drawing.Size(75, 39);
            this.CaptureButton2.TabIndex = 18;
            this.CaptureButton2.Text = "Capture(D0)";
            this.CaptureButton2.UseVisualStyleBackColor = true;
            this.CaptureButton2.Click += new System.EventHandler(this.CaptureButton2_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ResetButton.Location = new System.Drawing.Point(22, 282);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 39);
            this.ResetButton.TabIndex = 17;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // LowEdit
            // 
            this.LowEdit.Location = new System.Drawing.Point(100, 244);
            this.LowEdit.Name = "LowEdit";
            this.LowEdit.Size = new System.Drawing.Size(120, 25);
            this.LowEdit.TabIndex = 16;
            // 
            // HighEdit
            // 
            this.HighEdit.Location = new System.Drawing.Point(100, 184);
            this.HighEdit.Name = "HighEdit";
            this.HighEdit.Size = new System.Drawing.Size(120, 25);
            this.HighEdit.TabIndex = 15;
            // 
            // DutyEdit
            // 
            this.DutyEdit.Location = new System.Drawing.Point(100, 126);
            this.DutyEdit.Name = "DutyEdit";
            this.DutyEdit.Size = new System.Drawing.Size(120, 25);
            this.DutyEdit.TabIndex = 14;
            // 
            // PeriodEdit
            // 
            this.PeriodEdit.Location = new System.Drawing.Point(100, 68);
            this.PeriodEdit.Name = "PeriodEdit";
            this.PeriodEdit.Size = new System.Drawing.Size(120, 25);
            this.PeriodEdit.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(8, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "LowVolt(V)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(6, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "HighVolt(V)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(18, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "듀티(%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(14, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "주기(ms)";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ApplyButton.Location = new System.Drawing.Point(171, 280);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 39);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click_1);
            // 
            // CaptureButton
            // 
            this.CaptureButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CaptureButton.Location = new System.Drawing.Point(21, 327);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(75, 39);
            this.CaptureButton.TabIndex = 2;
            this.CaptureButton.Text = "Capture(A0)";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click_1);
            // 
            // CaptureWfg
            // 
            this.CaptureWfg.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CaptureWfg.Location = new System.Drawing.Point(74, 12);
            this.CaptureWfg.Name = "CaptureWfg";
            this.CaptureWfg.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot2});
            this.CaptureWfg.Size = new System.Drawing.Size(447, 168);
            this.CaptureWfg.TabIndex = 21;
            this.CaptureWfg.UseColorGenerator = true;
            this.CaptureWfg.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis2});
            this.CaptureWfg.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis2});
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.XAxis = this.xAxis2;
            this.waveformPlot2.YAxis = this.yAxis2;
            // 
            // ContinuousWfg
            // 
            this.ContinuousWfg.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ContinuousWfg.Location = new System.Drawing.Point(73, 206);
            this.ContinuousWfg.Name = "ContinuousWfg";
            this.ContinuousWfg.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1});
            this.ContinuousWfg.Size = new System.Drawing.Size(751, 168);
            this.ContinuousWfg.TabIndex = 20;
            this.ContinuousWfg.UseColorGenerator = true;
            this.ContinuousWfg.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.ContinuousWfg.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.HistoryCapacity = 10000;
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // xAxis1
            // 
            this.xAxis1.Mode = NationalInstruments.UI.AxisMode.StripChart;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblDuty);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblFrequency);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblPeriod);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(74, 592);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 86);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameter(AO)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(644, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "%";
            // 
            // lblDuty
            // 
            this.lblDuty.AutoSize = true;
            this.lblDuty.Location = new System.Drawing.Point(575, 41);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(16, 15);
            this.lblDuty.TabIndex = 7;
            this.lblDuty.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(494, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "듀티";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(415, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Hz";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(344, 41);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(16, 15);
            this.lblFrequency.TabIndex = 4;
            this.lblFrequency.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "주파수";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "ms";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(112, 41);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(16, 15);
            this.lblPeriod.TabIndex = 1;
            this.lblPeriod.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "주기";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(830, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "(s)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(527, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "(ms)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(30, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 23;
            this.label14.Text = "(V)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(31, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 16);
            this.label15.TabIndex = 24;
            this.label15.Text = "(V)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(605, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 16);
            this.label16.TabIndex = 27;
            this.label16.Text = "(V)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(1101, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 16);
            this.label17.TabIndex = 26;
            this.label17.Text = "(ms)";
            // 
            // CaptureWfg2
            // 
            this.CaptureWfg2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CaptureWfg2.Location = new System.Drawing.Point(648, 12);
            this.CaptureWfg2.Name = "CaptureWfg2";
            this.CaptureWfg2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot3});
            this.CaptureWfg2.Size = new System.Drawing.Size(447, 168);
            this.CaptureWfg2.TabIndex = 25;
            this.CaptureWfg2.UseColorGenerator = true;
            this.CaptureWfg2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis3});
            this.CaptureWfg2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis3});
            // 
            // waveformPlot3
            // 
            this.waveformPlot3.XAxis = this.xAxis3;
            this.waveformPlot3.YAxis = this.yAxis3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(29, 398);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 16);
            this.label18.TabIndex = 30;
            this.label18.Text = "(V)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(829, 554);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 16);
            this.label19.TabIndex = 28;
            this.label19.Text = "(s)";
            // 
            // ContinuousWfg2
            // 
            this.ContinuousWfg2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ContinuousWfg2.Location = new System.Drawing.Point(72, 398);
            this.ContinuousWfg2.Name = "ContinuousWfg2";
            this.ContinuousWfg2.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot4});
            this.ContinuousWfg2.Size = new System.Drawing.Size(751, 168);
            this.ContinuousWfg2.TabIndex = 29;
            this.ContinuousWfg2.UseColorGenerator = true;
            this.ContinuousWfg2.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis4});
            this.ContinuousWfg2.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis4});
            // 
            // waveformPlot4
            // 
            this.waveformPlot4.HistoryCapacity = 10000;
            this.waveformPlot4.XAxis = this.xAxis4;
            this.waveformPlot4.YAxis = this.yAxis4;
            // 
            // xAxis4
            // 
            this.xAxis4.Mode = NationalInstruments.UI.AxisMode.StripChart;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(1022, 730);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 15);
            this.label20.TabIndex = 32;
            this.label20.Text = "Start/Stop (DO)";
            // 
            // switch2
            // 
            this.switch2.Location = new System.Drawing.Point(1025, 633);
            this.switch2.Name = "switch2";
            this.switch2.OffColor = System.Drawing.Color.Yellow;
            this.switch2.OnColor = System.Drawing.Color.DeepSkyBlue;
            this.switch2.Size = new System.Drawing.Size(118, 96);
            this.switch2.SwitchStyle = NationalInstruments.UI.SwitchStyle.HorizontalSlide3D;
            this.switch2.TabIndex = 31;
            this.switch2.StateChanged += new NationalInstruments.UI.ActionEventHandler(this.switch2_StateChanged);
            // 
            // switch3
            // 
            this.switch3.Location = new System.Drawing.Point(800, 652);
            this.switch3.Name = "switch3";
            this.switch3.Size = new System.Drawing.Size(53, 77);
            this.switch3.SwitchStyle = NationalInstruments.UI.SwitchStyle.VerticalToggle3D;
            this.switch3.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(789, 732);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 15);
            this.label21.TabIndex = 33;
            this.label21.Text = "AO / DO";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.lblDuty2);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.lblFrequency2);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.lblPeriod2);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(74, 695);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(704, 86);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameter(DO)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(644, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 15);
            this.label22.TabIndex = 8;
            this.label22.Text = "%";
            // 
            // lblDuty2
            // 
            this.lblDuty2.AutoSize = true;
            this.lblDuty2.Location = new System.Drawing.Point(575, 41);
            this.lblDuty2.Name = "lblDuty2";
            this.lblDuty2.Size = new System.Drawing.Size(16, 15);
            this.lblDuty2.TabIndex = 7;
            this.lblDuty2.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(494, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 15);
            this.label24.TabIndex = 6;
            this.label24.Text = "듀티";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(415, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 15);
            this.label25.TabIndex = 5;
            this.label25.Text = "Hz";
            // 
            // lblFrequency2
            // 
            this.lblFrequency2.AutoSize = true;
            this.lblFrequency2.Location = new System.Drawing.Point(344, 41);
            this.lblFrequency2.Name = "lblFrequency2";
            this.lblFrequency2.Size = new System.Drawing.Size(16, 15);
            this.lblFrequency2.TabIndex = 4;
            this.lblFrequency2.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(249, 41);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 15);
            this.label27.TabIndex = 3;
            this.label27.Text = "주파수";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(179, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(28, 15);
            this.label28.TabIndex = 2;
            this.label28.Text = "ms";
            // 
            // lblPeriod2
            // 
            this.lblPeriod2.AutoSize = true;
            this.lblPeriod2.Location = new System.Drawing.Point(112, 41);
            this.lblPeriod2.Name = "lblPeriod2";
            this.lblPeriod2.Size = new System.Drawing.Size(16, 15);
            this.lblPeriod2.TabIndex = 1;
            this.lblPeriod2.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(32, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 15);
            this.label30.TabIndex = 0;
            this.label30.Text = "주기";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 791);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.switch3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.switch2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.ContinuousWfg2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.CaptureWfg2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CaptureWfg);
            this.Controls.Add(this.ContinuousWfg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.switch1);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.switch1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LowEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureWfg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinuousWfg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureWfg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinuousWfg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Switch switch1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private NationalInstruments.UI.WindowsForms.NumericEdit LowEdit;
        private NationalInstruments.UI.WindowsForms.NumericEdit HighEdit;
        private NationalInstruments.UI.WindowsForms.NumericEdit DutyEdit;
        private NationalInstruments.UI.WindowsForms.NumericEdit PeriodEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CaptureButton;
        private NationalInstruments.UI.WindowsForms.WaveformGraph CaptureWfg;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.XAxis xAxis2;
        private NationalInstruments.UI.YAxis yAxis2;
        private NationalInstruments.UI.WindowsForms.WaveformGraph ContinuousWfg;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private NationalInstruments.UI.WindowsForms.WaveformGraph CaptureWfg2;
        private NationalInstruments.UI.WaveformPlot waveformPlot3;
        private NationalInstruments.UI.XAxis xAxis3;
        private NationalInstruments.UI.YAxis yAxis3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private NationalInstruments.UI.WindowsForms.WaveformGraph ContinuousWfg2;
        private NationalInstruments.UI.WaveformPlot waveformPlot4;
        private NationalInstruments.UI.XAxis xAxis4;
        private NationalInstruments.UI.YAxis yAxis4;
        private System.Windows.Forms.Button CaptureButton2;
        private System.Windows.Forms.Label label20;
        private NationalInstruments.UI.WindowsForms.Switch switch2;
        private NationalInstruments.UI.WindowsForms.Switch switch3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblDuty2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblFrequency2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblPeriod2;
        private System.Windows.Forms.Label label30;
    }
}

