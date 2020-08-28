namespace PeachView
{
    partial class PeachGS
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
            this.ButtonSetup = new System.Windows.Forms.Button();
            this.ButtonConfig = new System.Windows.Forms.Button();
            this.ButtonMonitor = new System.Windows.Forms.Button();
            this.ButtonConnection = new System.Windows.Forms.Button();
            this.LabelPeachCI = new System.Windows.Forms.Label();
            this.LabelVehicleStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonSetup
            // 
            this.ButtonSetup.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSetup.Location = new System.Drawing.Point(269, 12);
            this.ButtonSetup.Name = "ButtonSetup";
            this.ButtonSetup.Size = new System.Drawing.Size(80, 75);
            this.ButtonSetup.TabIndex = 2;
            this.ButtonSetup.Text = "Setup";
            this.ButtonSetup.UseVisualStyleBackColor = true;
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.Location = new System.Drawing.Point(369, 12);
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(80, 75);
            this.ButtonConfig.TabIndex = 5;
            this.ButtonConfig.Text = "Config";
            this.ButtonConfig.UseVisualStyleBackColor = true;
            // 
            // ButtonMonitor
            // 
            this.ButtonMonitor.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonMonitor.ForeColor = System.Drawing.Color.Black;
            this.ButtonMonitor.Location = new System.Drawing.Point(169, 12);
            this.ButtonMonitor.Name = "ButtonMonitor";
            this.ButtonMonitor.Size = new System.Drawing.Size(80, 75);
            this.ButtonMonitor.TabIndex = 1;
            this.ButtonMonitor.Text = "Monitor";
            this.ButtonMonitor.UseVisualStyleBackColor = false;
            // 
            // ButtonConnection
            // 
            this.ButtonConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonConnection.Location = new System.Drawing.Point(794, 12);
            this.ButtonConnection.Name = "ButtonConnection";
            this.ButtonConnection.Size = new System.Drawing.Size(80, 75);
            this.ButtonConnection.TabIndex = 3;
            this.ButtonConnection.Text = "Connection";
            this.ButtonConnection.UseVisualStyleBackColor = true;
            this.ButtonConnection.Click += new System.EventHandler(this.ButtonConnection_Click);
            // 
            // LabelPeachCI
            // 
            this.LabelPeachCI.BackColor = System.Drawing.SystemColors.Control;
            this.LabelPeachCI.Location = new System.Drawing.Point(9, 12);
            this.LabelPeachCI.Name = "LabelPeachCI";
            this.LabelPeachCI.Size = new System.Drawing.Size(140, 75);
            this.LabelPeachCI.TabIndex = 1;
            // 
            // LabelVehicleStatus
            // 
            this.LabelVehicleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelVehicleStatus.Location = new System.Drawing.Point(498, 12);
            this.LabelVehicleStatus.Name = "LabelVehicleStatus";
            this.LabelVehicleStatus.Size = new System.Drawing.Size(290, 75);
            this.LabelVehicleStatus.TabIndex = 6;
            this.LabelVehicleStatus.Text = "VehicleStatus";
            this.LabelVehicleStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PeachGS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(887, 726);
            this.Controls.Add(this.LabelPeachCI);
            this.Controls.Add(this.LabelVehicleStatus);
            this.Controls.Add(this.ButtonMonitor);
            this.Controls.Add(this.ButtonSetup);
            this.Controls.Add(this.ButtonConnection);
            this.Controls.Add(this.ButtonConfig);
            this.Name = "PeachGS";
            this.Text = "PeachGS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PeachGS_FormClosed);
            this.Load += new System.EventHandler(this.PeachGS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonSetup;
        private System.Windows.Forms.Button ButtonConfig;
        private System.Windows.Forms.Button ButtonMonitor;
        private System.Windows.Forms.Button ButtonConnection;
        private System.Windows.Forms.Label LabelPeachCI;
        private System.Windows.Forms.Label LabelVehicleStatus;
    }
}