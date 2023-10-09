namespace ScreenVideoRecorder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            RecordStopVideo_Bt = new Button();
            TotalLengthValue_Lb = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            SingleVideoLengthValue_Tb = new TextBox();
            SingleVideoLength_Lb = new Label();
            VideoLength_Tm = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            TimeOfDay_Sts = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RecordStopVideo_Bt
            // 
            RecordStopVideo_Bt.Location = new Point(12, 12);
            RecordStopVideo_Bt.Name = "RecordStopVideo_Bt";
            RecordStopVideo_Bt.Size = new Size(281, 77);
            RecordStopVideo_Bt.TabIndex = 0;
            RecordStopVideo_Bt.Text = "Start Recording";
            RecordStopVideo_Bt.UseVisualStyleBackColor = true;
            RecordStopVideo_Bt.Click += RecordStopVideo_Bt_Click;
            // 
            // TotalLengthValue_Lb
            // 
            TotalLengthValue_Lb.BackColor = Color.FromArgb(224, 224, 224);
            TotalLengthValue_Lb.BorderStyle = BorderStyle.FixedSingle;
            TotalLengthValue_Lb.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TotalLengthValue_Lb.Location = new Point(153, 92);
            TotalLengthValue_Lb.Name = "TotalLengthValue_Lb";
            TotalLengthValue_Lb.RightToLeft = RightToLeft.No;
            TotalLengthValue_Lb.Size = new Size(140, 23);
            TotalLengthValue_Lb.TabIndex = 83;
            TotalLengthValue_Lb.Text = "00:00:00";
            TotalLengthValue_Lb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(224, 224, 224);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 92);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(140, 23);
            label4.TabIndex = 82;
            label4.Text = "Total Length";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(SingleVideoLengthValue_Tb);
            groupBox1.Controls.Add(SingleVideoLength_Lb);
            groupBox1.Location = new Point(304, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 84;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configure";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(126, 59);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 84;
            label6.Text = "dak.";
            // 
            // SingleVideoLengthValue_Tb
            // 
            SingleVideoLengthValue_Tb.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SingleVideoLengthValue_Tb.Location = new Point(76, 51);
            SingleVideoLengthValue_Tb.Name = "SingleVideoLengthValue_Tb";
            SingleVideoLengthValue_Tb.Size = new Size(44, 23);
            SingleVideoLengthValue_Tb.TabIndex = 83;
            SingleVideoLengthValue_Tb.Text = "1";
            SingleVideoLengthValue_Tb.TextAlign = HorizontalAlignment.Center;
            // 
            // SingleVideoLength_Lb
            // 
            SingleVideoLength_Lb.BackColor = Color.FromArgb(224, 224, 224);
            SingleVideoLength_Lb.BorderStyle = BorderStyle.FixedSingle;
            SingleVideoLength_Lb.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SingleVideoLength_Lb.Location = new Point(6, 24);
            SingleVideoLength_Lb.Name = "SingleVideoLength_Lb";
            SingleVideoLength_Lb.RightToLeft = RightToLeft.No;
            SingleVideoLength_Lb.Size = new Size(188, 23);
            SingleVideoLength_Lb.TabIndex = 81;
            SingleVideoLength_Lb.Text = "Single Video Length (min)";
            SingleVideoLength_Lb.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VideoLength_Tm
            // 
            VideoLength_Tm.Interval = 1000;
            VideoLength_Tm.Tick += VideoLength_Tm_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { TimeOfDay_Sts });
            statusStrip1.Location = new Point(0, 121);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(516, 26);
            statusStrip1.TabIndex = 85;
            statusStrip1.Text = "statusStrip1";
            // 
            // TimeOfDay_Sts
            // 
            TimeOfDay_Sts.BackColor = SystemColors.Control;
            TimeOfDay_Sts.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TimeOfDay_Sts.Name = "TimeOfDay_Sts";
            TimeOfDay_Sts.Size = new Size(115, 21);
            TimeOfDay_Sts.Text = " Time: 21:54:12";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(516, 147);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox1);
            Controls.Add(TotalLengthValue_Lb);
            Controls.Add(label4);
            Controls.Add(RecordStopVideo_Bt);
            Name = "Form1";
            Text = "Kingdom Video Recorder v1.02";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RecordStopVideo_Bt;
        private Label TotalLengthValue_Lb;
        private Label label4;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox SingleVideoLengthValue_Tb;
        private Label SingleVideoLength_Lb;
        private System.Windows.Forms.Timer VideoLength_Tm;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel TimeOfDay_Sts;
    }
}