namespace GAMMA
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
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnSpeedToggle = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCyclePhase = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblRustStatus = new System.Windows.Forms.Label();
            this.grpGammaSettings = new System.Windows.Forms.GroupBox();
            this.lblDefaultMarker = new System.Windows.Forms.Label();
            this.btnResetNight = new System.Windows.Forms.Button();
            this.btnResetDay = new System.Windows.Forms.Button();
            this.btnResetGamma = new System.Windows.Forms.Button();
            this.lblNightValue = new System.Windows.Forms.Label();
            this.lblDayValue = new System.Windows.Forms.Label();
            this.trackNightGamma = new System.Windows.Forms.TrackBar();
            this.lblNightGamma = new System.Windows.Forms.Label();
            this.trackDayGamma = new System.Windows.Forms.TrackBar();
            this.lblDayGamma = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.grpRustDetection = new System.Windows.Forms.GroupBox();
            this.grpTimeSettings = new System.Windows.Forms.GroupBox();
            this.lblCurrentServerTime = new System.Windows.Forms.Label();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.lblColon1 = new System.Windows.Forms.Label();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpGammaSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackNightGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDayGamma)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.grpRustDetection.SuspendLayout();
            this.grpTimeSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(16, 15);
            this.btnToggle.Margin = new System.Windows.Forms.Padding(4);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(200, 62);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "START";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnSpeedToggle
            // 
            this.btnSpeedToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSpeedToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeedToggle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeedToggle.ForeColor = System.Drawing.Color.White;
            this.btnSpeedToggle.Location = new System.Drawing.Point(230, 15);
            this.btnSpeedToggle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpeedToggle.Name = "btnSpeedToggle";
            this.btnSpeedToggle.Size = new System.Drawing.Size(120, 62);
            this.btnSpeedToggle.TabIndex = 7;
            this.btnSpeedToggle.Text = "1x SPEED";
            this.btnSpeedToggle.UseVisualStyleBackColor = false;
            this.btnSpeedToggle.Click += new System.EventHandler(this.btnSpeedToggle_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblStatus.Location = new System.Drawing.Point(370, 37);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 23);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Stopped";
            // 
            // lblCyclePhase
            // 
            this.lblCyclePhase.AutoSize = true;
            this.lblCyclePhase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCyclePhase.Location = new System.Drawing.Point(20, 31);
            this.lblCyclePhase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCyclePhase.Name = "lblCyclePhase";
            this.lblCyclePhase.Size = new System.Drawing.Size(89, 20);
            this.lblCyclePhase.TabIndex = 0;
            this.lblCyclePhase.Text = "Cycle Phase:";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeRemaining.Location = new System.Drawing.Point(20, 62);
            this.lblTimeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(120, 20);
            this.lblTimeRemaining.TabIndex = 1;
            this.lblTimeRemaining.Text = "Time Remaining:";
            // 
            // lblRustStatus
            // 
            this.lblRustStatus.AutoSize = true;
            this.lblRustStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRustStatus.Location = new System.Drawing.Point(20, 31);
            this.lblRustStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRustStatus.Name = "lblRustStatus";
            this.lblRustStatus.Size = new System.Drawing.Size(84, 20);
            this.lblRustStatus.TabIndex = 0;
            this.lblRustStatus.Text = "Rust Status:";
            // 
            // grpGammaSettings
            // 
            this.grpGammaSettings.Controls.Add(this.lblDefaultMarker);
            this.grpGammaSettings.Controls.Add(this.btnResetNight);
            this.grpGammaSettings.Controls.Add(this.btnResetDay);
            this.grpGammaSettings.Controls.Add(this.btnResetGamma);
            this.grpGammaSettings.Controls.Add(this.lblNightValue);
            this.grpGammaSettings.Controls.Add(this.lblDayValue);
            this.grpGammaSettings.Controls.Add(this.trackNightGamma);
            this.grpGammaSettings.Controls.Add(this.lblNightGamma);
            this.grpGammaSettings.Controls.Add(this.trackDayGamma);
            this.grpGammaSettings.Controls.Add(this.lblDayGamma);
            this.grpGammaSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGammaSettings.Location = new System.Drawing.Point(16, 98);
            this.grpGammaSettings.Margin = new System.Windows.Forms.Padding(4);
            this.grpGammaSettings.Name = "grpGammaSettings";
            this.grpGammaSettings.Padding = new System.Windows.Forms.Padding(4);
            this.grpGammaSettings.Size = new System.Drawing.Size(467, 230);
            this.grpGammaSettings.TabIndex = 2;
            this.grpGammaSettings.TabStop = false;
            this.grpGammaSettings.Text = "Gamma Settings";
            // 
            // lblDefaultMarker
            // 
            this.lblDefaultMarker.AutoSize = true;
            this.lblDefaultMarker.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultMarker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDefaultMarker.Location = new System.Drawing.Point(12, 155);
            this.lblDefaultMarker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultMarker.Name = "lblDefaultMarker";
            this.lblDefaultMarker.Size = new System.Drawing.Size(244, 19);
            this.lblDefaultMarker.TabIndex = 11;
            this.lblDefaultMarker.Text = "💡 Default gamma is at position 128";
            // 
            // btnResetNight
            // 
            this.btnResetNight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnResetNight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetNight.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetNight.ForeColor = System.Drawing.Color.White;
            this.btnResetNight.Location = new System.Drawing.Point(340, 130);
            this.btnResetNight.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetNight.Name = "btnResetNight";
            this.btnResetNight.Size = new System.Drawing.Size(60, 25);
            this.btnResetNight.TabIndex = 10;
            this.btnResetNight.Text = "Default";
            this.btnResetNight.UseVisualStyleBackColor = false;
            this.btnResetNight.Click += new System.EventHandler(this.btnResetNight_Click);
            // 
            // btnResetDay
            // 
            this.btnResetDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnResetDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetDay.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDay.ForeColor = System.Drawing.Color.White;
            this.btnResetDay.Location = new System.Drawing.Point(340, 85);
            this.btnResetDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetDay.Name = "btnResetDay";
            this.btnResetDay.Size = new System.Drawing.Size(60, 25);
            this.btnResetDay.TabIndex = 9;
            this.btnResetDay.Text = "Default";
            this.btnResetDay.UseVisualStyleBackColor = false;
            this.btnResetDay.Click += new System.EventHandler(this.btnResetDay_Click);
            // 
            // btnResetGamma
            // 
            this.btnResetGamma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnResetGamma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetGamma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGamma.ForeColor = System.Drawing.Color.White;
            this.btnResetGamma.Location = new System.Drawing.Point(12, 180);
            this.btnResetGamma.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetGamma.Name = "btnResetGamma";
            this.btnResetGamma.Size = new System.Drawing.Size(100, 35);
            this.btnResetGamma.TabIndex = 8;
            this.btnResetGamma.Text = "Reset Gamma";
            this.btnResetGamma.UseVisualStyleBackColor = false;
            this.btnResetGamma.Click += new System.EventHandler(this.btnResetGamma_Click);
            // 
            // lblNightValue
            // 
            this.lblNightValue.AutoSize = true;
            this.lblNightValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblNightValue.Location = new System.Drawing.Point(413, 105);
            this.lblNightValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNightValue.Name = "lblNightValue";
            this.lblNightValue.Size = new System.Drawing.Size(27, 20);
            this.lblNightValue.TabIndex = 5;
            this.lblNightValue.Text = "64";
            // 
            // lblDayValue
            // 
            this.lblDayValue.AutoSize = true;
            this.lblDayValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblDayValue.Location = new System.Drawing.Point(413, 31);
            this.lblDayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDayValue.Name = "lblDayValue";
            this.lblDayValue.Size = new System.Drawing.Size(36, 20);
            this.lblDayValue.TabIndex = 4;
            this.lblDayValue.Text = "128";
            // 
            // trackNightGamma
            // 
            this.trackNightGamma.Location = new System.Drawing.Point(133, 98);
            this.trackNightGamma.Margin = new System.Windows.Forms.Padding(4);
            this.trackNightGamma.Maximum = 255;
            this.trackNightGamma.Minimum = 1;
            this.trackNightGamma.Name = "trackNightGamma";
            this.trackNightGamma.Size = new System.Drawing.Size(267, 56);
            this.trackNightGamma.TabIndex = 3;
            this.trackNightGamma.TickFrequency = 25;
            this.trackNightGamma.Value = 64;
            this.trackNightGamma.ValueChanged += new System.EventHandler(this.trackNightGamma_ValueChanged);
            // 
            // lblNightGamma
            // 
            this.lblNightGamma.AutoSize = true;
            this.lblNightGamma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNightGamma.Location = new System.Drawing.Point(20, 105);
            this.lblNightGamma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNightGamma.Name = "lblNightGamma";
            this.lblNightGamma.Size = new System.Drawing.Size(105, 20);
            this.lblNightGamma.TabIndex = 2;
            this.lblNightGamma.Text = "Night Gamma:";
            // 
            // trackDayGamma
            // 
            this.trackDayGamma.Location = new System.Drawing.Point(133, 25);
            this.trackDayGamma.Margin = new System.Windows.Forms.Padding(4);
            this.trackDayGamma.Maximum = 255;
            this.trackDayGamma.Minimum = 1;
            this.trackDayGamma.Name = "trackDayGamma";
            this.trackDayGamma.Size = new System.Drawing.Size(267, 56);
            this.trackDayGamma.TabIndex = 1;
            this.trackDayGamma.TickFrequency = 25;
            this.trackDayGamma.Value = 128;
            this.trackDayGamma.ValueChanged += new System.EventHandler(this.trackDayGamma_ValueChanged);
            // 
            // lblDayGamma
            // 
            this.lblDayGamma.AutoSize = true;
            this.lblDayGamma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayGamma.Location = new System.Drawing.Point(20, 31);
            this.lblDayGamma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDayGamma.Name = "lblDayGamma";
            this.lblDayGamma.Size = new System.Drawing.Size(94, 20);
            this.lblDayGamma.TabIndex = 0;
            this.lblDayGamma.Text = "Day Gamma:";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblTimeRemaining);
            this.grpStatus.Controls.Add(this.lblCyclePhase);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(16, 431);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(4);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(4);
            this.grpStatus.Size = new System.Drawing.Size(467, 105);
            this.grpStatus.TabIndex = 4;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Cycle Status";
            // 
            // grpRustDetection
            // 
            this.grpRustDetection.Controls.Add(this.lblRustStatus);
            this.grpRustDetection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRustDetection.Location = new System.Drawing.Point(16, 554);
            this.grpRustDetection.Margin = new System.Windows.Forms.Padding(4);
            this.grpRustDetection.Name = "grpRustDetection";
            this.grpRustDetection.Padding = new System.Windows.Forms.Padding(4);
            this.grpRustDetection.Size = new System.Drawing.Size(467, 74);
            this.grpRustDetection.TabIndex = 5;
            this.grpRustDetection.TabStop = false;
            this.grpRustDetection.Text = "Game Detection";
            // 
            // grpTimeSettings
            // 
            this.grpTimeSettings.Controls.Add(this.lblCurrentServerTime);
            this.grpTimeSettings.Controls.Add(this.btnSetTime);
            this.grpTimeSettings.Controls.Add(this.txtMinute);
            this.grpTimeSettings.Controls.Add(this.lblColon1);
            this.grpTimeSettings.Controls.Add(this.txtHour);
            this.grpTimeSettings.Controls.Add(this.lblServerTime);
            this.grpTimeSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimeSettings.Location = new System.Drawing.Point(16, 308);
            this.grpTimeSettings.Margin = new System.Windows.Forms.Padding(4);
            this.grpTimeSettings.Name = "grpTimeSettings";
            this.grpTimeSettings.Padding = new System.Windows.Forms.Padding(4);
            this.grpTimeSettings.Size = new System.Drawing.Size(467, 105);
            this.grpTimeSettings.TabIndex = 3;
            this.grpTimeSettings.TabStop = false;
            this.grpTimeSettings.Text = "Game Time Settings";
            // 
            // lblCurrentServerTime
            // 
            this.lblCurrentServerTime.AutoSize = true;
            this.lblCurrentServerTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentServerTime.Location = new System.Drawing.Point(20, 68);
            this.lblCurrentServerTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentServerTime.Name = "lblCurrentServerTime";
            this.lblCurrentServerTime.Size = new System.Drawing.Size(118, 20);
            this.lblCurrentServerTime.TabIndex = 5;
            this.lblCurrentServerTime.Text = "Current: 12:00:00";
            // 
            // btnSetTime
            // 
            this.btnSetTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSetTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetTime.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTime.ForeColor = System.Drawing.Color.White;
            this.btnSetTime.Location = new System.Drawing.Point(240, 27);
            this.btnSetTime.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(67, 31);
            this.btnSetTime.TabIndex = 4;
            this.btnSetTime.Text = "SET";
            this.btnSetTime.UseVisualStyleBackColor = false;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // txtMinute
            // 
            this.txtMinute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinute.Location = new System.Drawing.Point(187, 27);
            this.txtMinute.Margin = new System.Windows.Forms.Padding(4);
            this.txtMinute.MaxLength = 2;
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(39, 30);
            this.txtMinute.TabIndex = 3;
            this.txtMinute.Text = "00";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblColon1
            // 
            this.lblColon1.AutoSize = true;
            this.lblColon1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColon1.Location = new System.Drawing.Point(167, 31);
            this.lblColon1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColon1.Name = "lblColon1";
            this.lblColon1.Size = new System.Drawing.Size(15, 23);
            this.lblColon1.TabIndex = 2;
            this.lblColon1.Text = ":";
            // 
            // txtHour
            // 
            this.txtHour.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.Location = new System.Drawing.Point(120, 27);
            this.txtHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtHour.MaxLength = 2;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(39, 30);
            this.txtHour.TabIndex = 1;
            this.txtHour.Text = "00";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblServerTime
            // 
            this.lblServerTime.AutoSize = true;
            this.lblServerTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerTime.Location = new System.Drawing.Point(20, 31);
            this.lblServerTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(70, 20);
            this.lblServerTime.TabIndex = 0;
            this.lblServerTime.Text = "Set Time:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblVersion.Location = new System.Drawing.Point(420, 12);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(46, 19);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "v1.3.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(507, 652);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.grpRustDetection);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpTimeSettings);
            this.Controls.Add(this.grpGammaSettings);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSpeedToggle);
            this.Controls.Add(this.btnToggle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAMMA - Rust Day/Night Cycle";
            this.grpGammaSettings.ResumeLayout(false);
            this.grpGammaSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackNightGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackDayGamma)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpRustDetection.ResumeLayout(false);
            this.grpRustDetection.PerformLayout();
            this.grpTimeSettings.ResumeLayout(false);
            this.grpTimeSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnSpeedToggle;
        private System.Windows.Forms.Button btnResetGamma;
        private System.Windows.Forms.Button btnResetDay;
        private System.Windows.Forms.Button btnResetNight;
        private System.Windows.Forms.Label lblDefaultMarker;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCyclePhase;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label lblRustStatus;
        private System.Windows.Forms.GroupBox grpGammaSettings;
        private System.Windows.Forms.Label lblDayGamma;
        private System.Windows.Forms.TrackBar trackDayGamma;
        private System.Windows.Forms.Label lblNightGamma;
        private System.Windows.Forms.TrackBar trackNightGamma;
        private System.Windows.Forms.Label lblDayValue;
        private System.Windows.Forms.Label lblNightValue;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.GroupBox grpRustDetection;
        private System.Windows.Forms.GroupBox grpTimeSettings;
        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label lblColon1;
        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.Button btnSetTime;
        private System.Windows.Forms.Label lblCurrentServerTime;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Timer timer1;
    }
}

