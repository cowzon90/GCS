namespace PeachView.Ucs.Common
{
    partial class FormInputText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelText = new System.Windows.Forms.Label();
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.Location = new System.Drawing.Point(28, 13);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(38, 12);
            this.LabelText.TabIndex = 0;
            this.LabelText.Text = "label1";
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Location = new System.Drawing.Point(30, 41);
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.Size = new System.Drawing.Size(100, 21);
            this.TextBoxInput.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(157, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(233, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormInputText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 114);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBoxInput);
            this.Controls.Add(this.LabelText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInputText";
            this.Text = "FormInputText";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.TextBox TextBoxInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}