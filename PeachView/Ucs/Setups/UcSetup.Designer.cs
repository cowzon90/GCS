namespace PeachView.Ucs.Setups
{
    partial class UcSetup
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
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.ButtonCalibration = new System.Windows.Forms.Button();
            this.ButtonFirmwareInstall = new System.Windows.Forms.Button();
            this.PanelAction = new System.Windows.Forms.Panel();
            this.PanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(717, 100);
            this.PanelTop.TabIndex = 1;
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PanelMenu.Controls.Add(this.ButtonCalibration);
            this.PanelMenu.Controls.Add(this.ButtonFirmwareInstall);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 100);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(150, 449);
            this.PanelMenu.TabIndex = 0;
            // 
            // ButtonCalibration
            // 
            this.ButtonCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonCalibration.Location = new System.Drawing.Point(0, 60);
            this.ButtonCalibration.Name = "ButtonCalibration";
            this.ButtonCalibration.Size = new System.Drawing.Size(150, 60);
            this.ButtonCalibration.TabIndex = 1;
            this.ButtonCalibration.Text = "Calibration";
            this.ButtonCalibration.UseVisualStyleBackColor = true;
            // 
            // ButtonFirmwareInstall
            // 
            this.ButtonFirmwareInstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonFirmwareInstall.Location = new System.Drawing.Point(0, 0);
            this.ButtonFirmwareInstall.Name = "ButtonFirmwareInstall";
            this.ButtonFirmwareInstall.Size = new System.Drawing.Size(150, 60);
            this.ButtonFirmwareInstall.TabIndex = 0;
            this.ButtonFirmwareInstall.Text = " Install Firmware";
            this.ButtonFirmwareInstall.UseVisualStyleBackColor = true;
            // 
            // PanelAction
            // 
            this.PanelAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelAction.Location = new System.Drawing.Point(150, 100);
            this.PanelAction.Name = "PanelAction";
            this.PanelAction.Size = new System.Drawing.Size(567, 449);
            this.PanelAction.TabIndex = 2;
            // 
            // UcSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelAction);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.PanelTop);
            this.Name = "UcSetup";
            this.Size = new System.Drawing.Size(717, 549);
            this.Load += new System.EventHandler(this.UcSetup_Load);
            this.PanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Button ButtonCalibration;
        private System.Windows.Forms.Button ButtonFirmwareInstall;
        private System.Windows.Forms.Panel PanelAction;
    }
}
