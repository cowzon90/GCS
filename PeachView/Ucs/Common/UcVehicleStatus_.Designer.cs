namespace PeachView.Ucs.Common
{
    partial class UcVehicleStatus_
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelGPS = new System.Windows.Forms.Label();
            this.LabelRC = new System.Windows.Forms.Label();
            this.LabelBattery = new System.Windows.Forms.Label();
            this.LabelMavVersion = new System.Windows.Forms.Label();
            this.LabelAutopilot = new System.Windows.Forms.Label();
            this.LabelArmed = new System.Windows.Forms.Label();
            this.LabelCompId = new System.Windows.Forms.Label();
            this.LabelSysId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.LabelRC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelBattery, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelGPS, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1183, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelGPS
            // 
            this.LabelGPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelGPS.Location = new System.Drawing.Point(239, 0);
            this.LabelGPS.Name = "LabelGPS";
            this.LabelGPS.Size = new System.Drawing.Size(230, 200);
            this.LabelGPS.TabIndex = 7;
            this.LabelGPS.Text = "GPS";
            this.LabelGPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelRC
            // 
            this.LabelRC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelRC.Location = new System.Drawing.Point(3, 0);
            this.LabelRC.Name = "LabelRC";
            this.LabelRC.Size = new System.Drawing.Size(230, 200);
            this.LabelRC.TabIndex = 6;
            this.LabelRC.Text = "RC signal";
            this.LabelRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBattery
            // 
            this.LabelBattery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelBattery.Location = new System.Drawing.Point(475, 0);
            this.LabelBattery.Name = "LabelBattery";
            this.LabelBattery.Size = new System.Drawing.Size(230, 200);
            this.LabelBattery.TabIndex = 8;
            this.LabelBattery.Text = "Battery";
            this.LabelBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelMavVersion
            // 
            this.LabelMavVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelMavVersion.Location = new System.Drawing.Point(190, 152);
            this.LabelMavVersion.Name = "LabelMavVersion";
            this.LabelMavVersion.Size = new System.Drawing.Size(276, 42);
            this.LabelMavVersion.TabIndex = 9;
            this.LabelMavVersion.Text = "Mavlink V.";
            this.LabelMavVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelAutopilot
            // 
            this.LabelAutopilot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelAutopilot.Location = new System.Drawing.Point(190, 114);
            this.LabelAutopilot.Name = "LabelAutopilot";
            this.LabelAutopilot.Size = new System.Drawing.Size(276, 38);
            this.LabelAutopilot.TabIndex = 8;
            this.LabelAutopilot.Text = "Autopilot";
            this.LabelAutopilot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelArmed
            // 
            this.LabelArmed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelArmed.Location = new System.Drawing.Point(190, 76);
            this.LabelArmed.Name = "LabelArmed";
            this.LabelArmed.Size = new System.Drawing.Size(276, 38);
            this.LabelArmed.TabIndex = 7;
            this.LabelArmed.Text = "Armed";
            this.LabelArmed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelCompId
            // 
            this.LabelCompId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelCompId.Location = new System.Drawing.Point(190, 38);
            this.LabelCompId.Name = "LabelCompId";
            this.LabelCompId.Size = new System.Drawing.Size(276, 38);
            this.LabelCompId.TabIndex = 6;
            this.LabelCompId.Text = "COMP ID";
            this.LabelCompId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelSysId
            // 
            this.LabelSysId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSysId.Location = new System.Drawing.Point(190, 0);
            this.LabelSysId.Name = "LabelSysId";
            this.LabelSysId.Size = new System.Drawing.Size(276, 38);
            this.LabelSysId.TabIndex = 5;
            this.LabelSysId.Text = "SYS ID";
            this.LabelSysId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 42);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mavlink V.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 38);
            this.label4.TabIndex = 3;
            this.label4.Text = "Autopilot";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "Armed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "COMP ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "SYS ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.LabelMavVersion, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LabelAutopilot, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.LabelSysId, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.LabelArmed, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LabelCompId, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(711, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(469, 194);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // UcVehicleStatus_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcVehicleStatus_";
            this.Size = new System.Drawing.Size(1183, 200);
            this.Load += new System.EventHandler(this.UcVehicleStatus__Load);
            this.Resize += new System.EventHandler(this.UcVehicleStatus__Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelBattery;
        private System.Windows.Forms.Label LabelGPS;
        private System.Windows.Forms.Label LabelRC;
        private System.Windows.Forms.Label LabelMavVersion;
        private System.Windows.Forms.Label LabelAutopilot;
        private System.Windows.Forms.Label LabelArmed;
        private System.Windows.Forms.Label LabelCompId;
        private System.Windows.Forms.Label LabelSysId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
