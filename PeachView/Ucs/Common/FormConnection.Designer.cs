namespace PeachView.Ucs.Common
{
    partial class FormConnection
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
            this.ComboComPort = new System.Windows.Forms.ComboBox();
            this.ComboBaudrates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonDisConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ComboComPort
            // 
            this.ComboComPort.FormattingEnabled = true;
            this.ComboComPort.Location = new System.Drawing.Point(140, 33);
            this.ComboComPort.Name = "ComboComPort";
            this.ComboComPort.Size = new System.Drawing.Size(102, 20);
            this.ComboComPort.TabIndex = 0;
            this.ComboComPort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboComPort_MouseClick);
            // 
            // ComboBaudrates
            // 
            this.ComboBaudrates.FormattingEnabled = true;
            this.ComboBaudrates.Location = new System.Drawing.Point(140, 73);
            this.ComboBaudrates.Name = "ComboBaudrates";
            this.ComboBaudrates.Size = new System.Drawing.Size(102, 20);
            this.ComboBaudrates.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "ComPort";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(34, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baudrates";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(34, 104);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(100, 30);
            this.ButtonConnect.TabIndex = 4;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonDisConnect
            // 
            this.ButtonDisConnect.Location = new System.Drawing.Point(142, 104);
            this.ButtonDisConnect.Name = "ButtonDisConnect";
            this.ButtonDisConnect.Size = new System.Drawing.Size(100, 30);
            this.ButtonDisConnect.TabIndex = 5;
            this.ButtonDisConnect.Text = "DisConnect";
            this.ButtonDisConnect.UseVisualStyleBackColor = true;
            this.ButtonDisConnect.Click += new System.EventHandler(this.ButtonDisConnect_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(268, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connected Vehicles";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(268, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 301);
            this.panel1.TabIndex = 8;
            // 
            // FormConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 371);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ButtonDisConnect);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBaudrates);
            this.Controls.Add(this.ComboComPort);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnection";
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.FormConnection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboComPort;
        private System.Windows.Forms.ComboBox ComboBaudrates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonDisConnect;
        private System.Windows.Forms.Label label3;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Panel panel1;
    }
}