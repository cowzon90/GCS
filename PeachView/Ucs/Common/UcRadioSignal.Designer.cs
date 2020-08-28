namespace PeachView.Ucs.Common
{
    partial class UcRadioSignal
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
            this.LabelRssi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelRssi
            // 
            this.LabelRssi.Location = new System.Drawing.Point(26, 70);
            this.LabelRssi.Name = "LabelRssi";
            this.LabelRssi.Size = new System.Drawing.Size(100, 23);
            this.LabelRssi.TabIndex = 0;
            this.LabelRssi.Text = "label1";
            this.LabelRssi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Signal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcRadioSignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelRssi);
            this.Name = "UcRadioSignal";
            this.Load += new System.EventHandler(this.UcRadioSignal_Load);
            this.Resize += new System.EventHandler(this.UcRadioSignal_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelRssi;
        private System.Windows.Forms.Label label1;
    }
}
