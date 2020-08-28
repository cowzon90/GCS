using System;

namespace PeachView.Ucs.Configs
{
    partial class UcParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcParameters));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.TextSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pTreeListView1 = new PeachView.Components.TreeListView.pTreeListView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonSave);
            this.panel1.Controls.Add(this.ButtonSearch);
            this.panel1.Controls.Add(this.TextSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 50);
            this.panel1.TabIndex = 0;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonSearch.FlatAppearance.BorderSize = 0;
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSearch.Location = new System.Drawing.Point(491, 14);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 30);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextSearch
            // 
            this.TextSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextSearch.Location = new System.Drawing.Point(366, 20);
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.Size = new System.Drawing.Size(119, 21);
            this.TextSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Parameter Tree";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pTreeListView1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 474);
            this.panel2.TabIndex = 2;
            // 
            // pTreeListView1
            // 
            this.pTreeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTreeListView1.FullRowSelect = true;
            this.pTreeListView1.GridLines = true;
            this.pTreeListView1.HideSelection = false;
            this.pTreeListView1.Location = new System.Drawing.Point(0, 0);
            this.pTreeListView1.MultiSelect = false;
            this.pTreeListView1.Name = "pTreeListView1";
            this.pTreeListView1.Parameters = null;
            this.pTreeListView1.Size = new System.Drawing.Size(647, 474);
            this.pTreeListView1.TabIndex = 4;
            this.pTreeListView1.UseCompatibleStateImageBehavior = false;
            this.pTreeListView1.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(159, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "TODO : Parameter 차별화";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(511, 299);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(136, 175);
            this.dataGridView1.TabIndex = 0;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ButtonSave.FlatAppearance.BorderSize = 0;
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSave.Location = new System.Drawing.Point(569, 14);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 30);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // UcParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UcParameters";
            this.Size = new System.Drawing.Size(647, 524);
            this.Load += new System.EventHandler(this.UcParameters_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox TextSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private Components.TreeListView.pTreeListView pTreeListView1;
        private System.Windows.Forms.Button ButtonSave;
    }
}
