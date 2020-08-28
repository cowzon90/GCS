namespace PeachView.Ucs.Monitors
{
    partial class UcMonitor
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
            this.ButtonTakeOff = new System.Windows.Forms.Button();
            this.LabelFlightPlan = new System.Windows.Forms.Label();
            this.ButtonLand = new System.Windows.Forms.Button();
            this.ButtonRTL = new System.Windows.Forms.Button();
            this.LabelPlanTab = new System.Windows.Forms.Label();
            this.LabelHud = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonTakeOff
            // 
            this.ButtonTakeOff.Location = new System.Drawing.Point(20, 143);
            this.ButtonTakeOff.Name = "ButtonTakeOff";
            this.ButtonTakeOff.Size = new System.Drawing.Size(75, 75);
            this.ButtonTakeOff.TabIndex = 0;
            this.ButtonTakeOff.Text = "Take off";
            this.ButtonTakeOff.UseVisualStyleBackColor = true;
            this.ButtonTakeOff.Click += new System.EventHandler(this.ButtonTakeOff_Click);
            // 
            // LabelFlightPlan
            // 
            this.LabelFlightPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelFlightPlan.Location = new System.Drawing.Point(750, 140);
            this.LabelFlightPlan.Name = "LabelFlightPlan";
            this.LabelFlightPlan.Size = new System.Drawing.Size(140, 300);
            this.LabelFlightPlan.TabIndex = 7;
            this.LabelFlightPlan.Text = "Fight Plan";
            // 
            // ButtonLand
            // 
            this.ButtonLand.Location = new System.Drawing.Point(20, 236);
            this.ButtonLand.Name = "ButtonLand";
            this.ButtonLand.Size = new System.Drawing.Size(75, 75);
            this.ButtonLand.TabIndex = 8;
            this.ButtonLand.Text = "Land";
            this.ButtonLand.UseVisualStyleBackColor = true;
            this.ButtonLand.Click += new System.EventHandler(this.ButtonLand_Click);
            // 
            // ButtonRTL
            // 
            this.ButtonRTL.Location = new System.Drawing.Point(20, 326);
            this.ButtonRTL.Name = "ButtonRTL";
            this.ButtonRTL.Size = new System.Drawing.Size(75, 75);
            this.ButtonRTL.TabIndex = 9;
            this.ButtonRTL.Text = "RTL";
            this.ButtonRTL.UseVisualStyleBackColor = true;
            this.ButtonRTL.Click += new System.EventHandler(this.ButtonRTL_Click);
            // 
            // LabelPlanTab
            // 
            this.LabelPlanTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPlanTab.Location = new System.Drawing.Point(875, 140);
            this.LabelPlanTab.Name = "LabelPlanTab";
            this.LabelPlanTab.Size = new System.Drawing.Size(20, 300);
            this.LabelPlanTab.TabIndex = 11;
            this.LabelPlanTab.Text = "flight plan";
            this.LabelPlanTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelHud
            // 
            this.LabelHud.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LabelHud.BackColor = System.Drawing.Color.Transparent;
            this.LabelHud.Location = new System.Drawing.Point(331, 500);
            this.LabelHud.Name = "LabelHud";
            this.LabelHud.Size = new System.Drawing.Size(300, 150);
            this.LabelHud.TabIndex = 12;
            this.LabelHud.Text = "label1";
            // 
            // UcMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LabelHud);
            this.Controls.Add(this.LabelPlanTab);
            this.Controls.Add(this.ButtonRTL);
            this.Controls.Add(this.ButtonLand);
            this.Controls.Add(this.LabelFlightPlan);
            this.Controls.Add(this.ButtonTakeOff);
            this.Name = "UcMonitor";
            this.Size = new System.Drawing.Size(895, 660);
            this.Load += new System.EventHandler(this.UcMonitor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonTakeOff;
        private System.Windows.Forms.Label LabelFlightPlan;
        private System.Windows.Forms.Button ButtonLand;
        private System.Windows.Forms.Button ButtonRTL;
        private System.Windows.Forms.Label LabelPlanTab;
        private System.Windows.Forms.Label LabelHud;
    }
}
