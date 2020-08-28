namespace PeachView.Ucs.Configs
{
    partial class UcConfig
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonGSConfig = new System.Windows.Forms.Button();
            this.ButtonParameter = new System.Windows.Forms.Button();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel2.Controls.Add(this.ButtonGSConfig);
            this.panel2.Controls.Add(this.ButtonParameter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 523);
            this.panel2.TabIndex = 1;
            // 
            // ButtonGSConfig
            // 
            this.ButtonGSConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonGSConfig.Location = new System.Drawing.Point(0, 60);
            this.ButtonGSConfig.Name = "ButtonGSConfig";
            this.ButtonGSConfig.Size = new System.Drawing.Size(150, 60);
            this.ButtonGSConfig.TabIndex = 1;
            this.ButtonGSConfig.Text = "GS Config";
            this.ButtonGSConfig.UseVisualStyleBackColor = true;
            // 
            // ButtonParameter
            // 
            this.ButtonParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonParameter.Location = new System.Drawing.Point(0, 0);
            this.ButtonParameter.Name = "ButtonParameter";
            this.ButtonParameter.Size = new System.Drawing.Size(150, 60);
            this.ButtonParameter.TabIndex = 0;
            this.ButtonParameter.Text = "Parameter";
            this.ButtonParameter.UseVisualStyleBackColor = true;
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.SystemColors.Control;
            this.PanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(150, 100);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(550, 523);
            this.PanelMain.TabIndex = 2;
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.SystemColors.Control;
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(700, 100);
            this.PanelTop.TabIndex = 0;
            // 
            // UcConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelTop);
            this.Name = "UcConfig";
            this.Size = new System.Drawing.Size(700, 623);
            this.Load += new System.EventHandler(this.UcConfig_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ButtonParameter;
        private System.Windows.Forms.Button ButtonGSConfig;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelTop;
    }
}
