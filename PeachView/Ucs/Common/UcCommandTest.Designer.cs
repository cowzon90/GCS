namespace PeachView.Ucs.Common
{
    partial class UcCommandTest
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
            this.ButtonArm = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonTakeOff = new System.Windows.Forms.Button();
            this.ButtonLand = new System.Windows.Forms.Button();
            this.ButtonRTL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonArm
            // 
            this.ButtonArm.Location = new System.Drawing.Point(24, 27);
            this.ButtonArm.Name = "ButtonArm";
            this.ButtonArm.Size = new System.Drawing.Size(100, 30);
            this.ButtonArm.TabIndex = 0;
            this.ButtonArm.Text = "Arm";
            this.ButtonArm.UseVisualStyleBackColor = true;
            this.ButtonArm.Click += new System.EventHandler(this.ButtonArm_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(539, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(215, 232);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Force Arm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonArm_Click);
            // 
            // ButtonTakeOff
            // 
            this.ButtonTakeOff.Location = new System.Drawing.Point(24, 74);
            this.ButtonTakeOff.Name = "ButtonTakeOff";
            this.ButtonTakeOff.Size = new System.Drawing.Size(100, 30);
            this.ButtonTakeOff.TabIndex = 3;
            this.ButtonTakeOff.Text = "Take off";
            this.ButtonTakeOff.UseVisualStyleBackColor = true;
            this.ButtonTakeOff.Click += new System.EventHandler(this.ButtonTakeOff_Click);
            // 
            // ButtonLand
            // 
            this.ButtonLand.Location = new System.Drawing.Point(24, 123);
            this.ButtonLand.Name = "ButtonLand";
            this.ButtonLand.Size = new System.Drawing.Size(100, 30);
            this.ButtonLand.TabIndex = 4;
            this.ButtonLand.Text = "Land";
            this.ButtonLand.UseVisualStyleBackColor = true;
            this.ButtonLand.Click += new System.EventHandler(this.ButtonLand_Click);
            // 
            // ButtonRTL
            // 
            this.ButtonRTL.Location = new System.Drawing.Point(24, 172);
            this.ButtonRTL.Name = "ButtonRTL";
            this.ButtonRTL.Size = new System.Drawing.Size(100, 30);
            this.ButtonRTL.TabIndex = 5;
            this.ButtonRTL.Text = "RTL";
            this.ButtonRTL.UseVisualStyleBackColor = true;
            this.ButtonRTL.Click += new System.EventHandler(this.ButtonRTL_Click);
            // 
            // UcCommandTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonRTL);
            this.Controls.Add(this.ButtonLand);
            this.Controls.Add(this.ButtonTakeOff);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ButtonArm);
            this.Name = "UcCommandTest";
            this.Size = new System.Drawing.Size(768, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonArm;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonTakeOff;
        private System.Windows.Forms.Button ButtonLand;
        private System.Windows.Forms.Button ButtonRTL;
    }
}
