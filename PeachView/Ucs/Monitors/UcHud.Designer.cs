namespace PeachView.Ucs.Monitors
{
    partial class UcHud
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
            this.LabelLeft = new System.Windows.Forms.Label();
            this.LabelRight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelLeft
            // 
            this.LabelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelLeft.Location = new System.Drawing.Point(0, 0);
            this.LabelLeft.Name = "LabelLeft";
            this.LabelLeft.Size = new System.Drawing.Size(250, 250);
            this.LabelLeft.TabIndex = 0;
            this.LabelLeft.Text = "label1";
            // 
            // LabelRight
            // 
            this.LabelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelRight.Location = new System.Drawing.Point(250, 0);
            this.LabelRight.Name = "LabelRight";
            this.LabelRight.Size = new System.Drawing.Size(250, 250);
            this.LabelRight.TabIndex = 1;
            this.LabelRight.Text = "label2";
            // 
            // UcHud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LabelRight);
            this.Controls.Add(this.LabelLeft);
            this.Name = "UcHud";
            this.Size = new System.Drawing.Size(500, 250);
            this.Load += new System.EventHandler(this.UcHud__Load);
            this.Resize += new System.EventHandler(this.UcHud__Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelLeft;
        private System.Windows.Forms.Label LabelRight;
    }
}
