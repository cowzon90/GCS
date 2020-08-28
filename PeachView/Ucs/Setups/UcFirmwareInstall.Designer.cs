namespace PeachView.Ucs.Setups
{
    partial class UcFirmwareInstall
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
            this.RButtonDefault = new System.Windows.Forms.RadioButton();
            this.RButtonCustom = new System.Windows.Forms.RadioButton();
            this.ButtonLoadFile = new System.Windows.Forms.Button();
            this.ComBoDefault = new System.Windows.Forms.ComboBox();
            this.ButtonUpLoad = new System.Windows.Forms.Button();
            this.RichTextProgress = new System.Windows.Forms.RichTextBox();
            this.PanelDefault = new System.Windows.Forms.Panel();
            this.RButtonPx4 = new System.Windows.Forms.RadioButton();
            this.RButtonArdupilot = new System.Windows.Forms.RadioButton();
            this.PanelCustom = new System.Windows.Forms.Panel();
            this.TextFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelDefault.SuspendLayout();
            this.PanelCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // RButtonDefault
            // 
            this.RButtonDefault.Location = new System.Drawing.Point(35, 23);
            this.RButtonDefault.Name = "RButtonDefault";
            this.RButtonDefault.Size = new System.Drawing.Size(104, 24);
            this.RButtonDefault.TabIndex = 0;
            this.RButtonDefault.TabStop = true;
            this.RButtonDefault.Text = "Default";
            this.RButtonDefault.UseVisualStyleBackColor = true;
            // 
            // RButtonCustom
            // 
            this.RButtonCustom.Location = new System.Drawing.Point(35, 172);
            this.RButtonCustom.Name = "RButtonCustom";
            this.RButtonCustom.Size = new System.Drawing.Size(104, 24);
            this.RButtonCustom.TabIndex = 1;
            this.RButtonCustom.TabStop = true;
            this.RButtonCustom.Text = "Custom";
            this.RButtonCustom.UseVisualStyleBackColor = true;
            // 
            // ButtonLoadFile
            // 
            this.ButtonLoadFile.Location = new System.Drawing.Point(392, 14);
            this.ButtonLoadFile.Name = "ButtonLoadFile";
            this.ButtonLoadFile.Size = new System.Drawing.Size(75, 21);
            this.ButtonLoadFile.TabIndex = 2;
            this.ButtonLoadFile.Text = "Load..";
            this.ButtonLoadFile.UseVisualStyleBackColor = true;
            // 
            // ComBoDefault
            // 
            this.ComBoDefault.FormattingEnabled = true;
            this.ComBoDefault.Location = new System.Drawing.Point(140, 16);
            this.ComBoDefault.Name = "ComBoDefault";
            this.ComBoDefault.Size = new System.Drawing.Size(121, 20);
            this.ComBoDefault.TabIndex = 3;
            // 
            // ButtonUpLoad
            // 
            this.ButtonUpLoad.Location = new System.Drawing.Point(35, 336);
            this.ButtonUpLoad.Name = "ButtonUpLoad";
            this.ButtonUpLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpLoad.TabIndex = 4;
            this.ButtonUpLoad.Text = "Upload";
            this.ButtonUpLoad.UseVisualStyleBackColor = true;
            // 
            // RichTextProgress
            // 
            this.RichTextProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RichTextProgress.BackColor = System.Drawing.Color.White;
            this.RichTextProgress.Location = new System.Drawing.Point(35, 365);
            this.RichTextProgress.Name = "RichTextProgress";
            this.RichTextProgress.Size = new System.Drawing.Size(472, 119);
            this.RichTextProgress.TabIndex = 6;
            this.RichTextProgress.Text = "";
            // 
            // PanelDefault
            // 
            this.PanelDefault.Controls.Add(this.label4);
            this.PanelDefault.Controls.Add(this.RButtonPx4);
            this.PanelDefault.Controls.Add(this.RButtonArdupilot);
            this.PanelDefault.Controls.Add(this.ComBoDefault);
            this.PanelDefault.Location = new System.Drawing.Point(35, 53);
            this.PanelDefault.Name = "PanelDefault";
            this.PanelDefault.Size = new System.Drawing.Size(472, 100);
            this.PanelDefault.TabIndex = 7;
            // 
            // RButtonPx4
            // 
            this.RButtonPx4.Location = new System.Drawing.Point(17, 43);
            this.RButtonPx4.Name = "RButtonPx4";
            this.RButtonPx4.Size = new System.Drawing.Size(104, 24);
            this.RButtonPx4.TabIndex = 10;
            this.RButtonPx4.TabStop = true;
            this.RButtonPx4.Text = "PX4";
            this.RButtonPx4.UseVisualStyleBackColor = true;
            // 
            // RButtonArdupilot
            // 
            this.RButtonArdupilot.Location = new System.Drawing.Point(17, 13);
            this.RButtonArdupilot.Name = "RButtonArdupilot";
            this.RButtonArdupilot.Size = new System.Drawing.Size(104, 24);
            this.RButtonArdupilot.TabIndex = 9;
            this.RButtonArdupilot.TabStop = true;
            this.RButtonArdupilot.Text = "ArduPilot";
            this.RButtonArdupilot.UseVisualStyleBackColor = true;
            // 
            // PanelCustom
            // 
            this.PanelCustom.Controls.Add(this.TextFileName);
            this.PanelCustom.Controls.Add(this.label2);
            this.PanelCustom.Controls.Add(this.label1);
            this.PanelCustom.Controls.Add(this.TextPath);
            this.PanelCustom.Controls.Add(this.ButtonLoadFile);
            this.PanelCustom.Location = new System.Drawing.Point(35, 202);
            this.PanelCustom.Name = "PanelCustom";
            this.PanelCustom.Size = new System.Drawing.Size(472, 100);
            this.PanelCustom.TabIndex = 8;
            // 
            // TextFileName
            // 
            this.TextFileName.Location = new System.Drawing.Point(118, 50);
            this.TextFileName.Name = "TextFileName";
            this.TextFileName.Size = new System.Drawing.Size(268, 21);
            this.TextFileName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "File Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextPath
            // 
            this.TextPath.Location = new System.Drawing.Point(118, 14);
            this.TextPath.Name = "TextPath";
            this.TextPath.Size = new System.Drawing.Size(268, 21);
            this.TextPath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(136, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "TODO : Progress bar building";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(279, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "TODO : Firmware data";
            this.label4.Visible = false;
            // 
            // UcFirmwareInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PanelCustom);
            this.Controls.Add(this.PanelDefault);
            this.Controls.Add(this.RichTextProgress);
            this.Controls.Add(this.ButtonUpLoad);
            this.Controls.Add(this.RButtonCustom);
            this.Controls.Add(this.RButtonDefault);
            this.Name = "UcFirmwareInstall";
            this.Size = new System.Drawing.Size(738, 615);
            this.Load += new System.EventHandler(this.UcFirmwareInstall_Load);
            this.PanelDefault.ResumeLayout(false);
            this.PanelCustom.ResumeLayout(false);
            this.PanelCustom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton RButtonDefault;
        private System.Windows.Forms.RadioButton RButtonCustom;
        private System.Windows.Forms.Button ButtonLoadFile;
        private System.Windows.Forms.ComboBox ComBoDefault;
        private System.Windows.Forms.Button ButtonUpLoad;
        private System.Windows.Forms.RichTextBox RichTextProgress;
        private System.Windows.Forms.Panel PanelDefault;
        private System.Windows.Forms.RadioButton RButtonPx4;
        private System.Windows.Forms.RadioButton RButtonArdupilot;
        private System.Windows.Forms.Panel PanelCustom;
        private System.Windows.Forms.TextBox TextFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
