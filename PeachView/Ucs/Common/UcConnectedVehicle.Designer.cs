﻿namespace PeachView.Ucs.Common
{
    partial class UcConnectedVehicle
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
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.LabelLogo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 110);
            this.label4.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(131, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(100, 112);
            this.listBox1.TabIndex = 8;
            // 
            // LabelLogo
            // 
            this.LabelLogo.AutoSize = true;
            this.LabelLogo.BackColor = System.Drawing.Color.Aqua;
            this.LabelLogo.ForeColor = System.Drawing.Color.Red;
            this.LabelLogo.Location = new System.Drawing.Point(35, 60);
            this.LabelLogo.Name = "LabelLogo";
            this.LabelLogo.Size = new System.Drawing.Size(74, 12);
            this.LabelLogo.TabIndex = 9;
            this.LabelLogo.Text = "Firmware CI";
            // 
            // UcConnectedVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelLogo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Name = "UcConnectedVehicle";
            this.Size = new System.Drawing.Size(250, 140);
            this.Load += new System.EventHandler(this.UcConnectedVehicle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label LabelLogo;
    }
}
