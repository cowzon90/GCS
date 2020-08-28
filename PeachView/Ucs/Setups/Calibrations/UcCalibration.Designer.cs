namespace PeachView.Ucs.Setups.Calibrations
{
    partial class UcCalibration
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonAccel = new System.Windows.Forms.Button();
            this.ButtonCompass = new System.Windows.Forms.Button();
            this.ButtonRadio = new System.Windows.Forms.Button();
            this.ButtonESC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonAccel
            // 
            this.ButtonAccel.Location = new System.Drawing.Point(25, 15);
            this.ButtonAccel.Name = "ButtonAccel";
            this.ButtonAccel.Size = new System.Drawing.Size(75, 50);
            this.ButtonAccel.TabIndex = 0;
            this.ButtonAccel.Text = "Accel";
            this.ButtonAccel.UseVisualStyleBackColor = true;
            // 
            // ButtonCompass
            // 
            this.ButtonCompass.Location = new System.Drawing.Point(116, 15);
            this.ButtonCompass.Name = "ButtonCompass";
            this.ButtonCompass.Size = new System.Drawing.Size(75, 50);
            this.ButtonCompass.TabIndex = 1;
            this.ButtonCompass.Text = "Compass";
            this.ButtonCompass.UseVisualStyleBackColor = true;
            // 
            // ButtonRadio
            // 
            this.ButtonRadio.Location = new System.Drawing.Point(209, 15);
            this.ButtonRadio.Name = "ButtonRadio";
            this.ButtonRadio.Size = new System.Drawing.Size(75, 50);
            this.ButtonRadio.TabIndex = 2;
            this.ButtonRadio.Text = "Radio";
            this.ButtonRadio.UseVisualStyleBackColor = true;
            // 
            // ButtonESC
            // 
            this.ButtonESC.Location = new System.Drawing.Point(304, 15);
            this.ButtonESC.Name = "ButtonESC";
            this.ButtonESC.Size = new System.Drawing.Size(75, 50);
            this.ButtonESC.TabIndex = 3;
            this.ButtonESC.Text = "ESC";
            this.ButtonESC.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonAccel);
            this.panel1.Controls.Add(this.ButtonCompass);
            this.panel1.Controls.Add(this.ButtonESC);
            this.panel1.Controls.Add(this.ButtonRadio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 80);
            this.panel1.TabIndex = 0;
            // 
            // PanelMain
            // 
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 80);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(676, 445);
            this.PanelMain.TabIndex = 1;
            // 
            // UcCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel1);
            this.Name = "UcCalibration";
            this.Size = new System.Drawing.Size(676, 525);
            this.Load += new System.EventHandler(this.UcCalibrationMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonAccel;
        private System.Windows.Forms.Button ButtonCompass;
        private System.Windows.Forms.Button ButtonRadio;
        private System.Windows.Forms.Button ButtonESC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PanelMain;
    }
}
