namespace lab1
{
    partial class AdminShowUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminShowUsers));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.LoginDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurNameDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlockDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginDG,
            this.PassDG,
            this.NameDG,
            this.SurNameDG,
            this.CityDG,
            this.StatusDG,
            this.BlockDG});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 236);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(663, 173);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(90, 35);
            this.btnWrite.TabIndex = 6;
            this.btnWrite.Text = "Write to file";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(663, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LoginDG
            // 
            this.LoginDG.HeaderText = "Login";
            this.LoginDG.Name = "LoginDG";
            // 
            // PassDG
            // 
            this.PassDG.HeaderText = "Password";
            this.PassDG.Name = "PassDG";
            // 
            // NameDG
            // 
            this.NameDG.HeaderText = "Name";
            this.NameDG.Name = "NameDG";
            // 
            // SurNameDG
            // 
            this.SurNameDG.HeaderText = "SurName";
            this.SurNameDG.Name = "SurNameDG";
            // 
            // CityDG
            // 
            this.CityDG.HeaderText = "City";
            this.CityDG.Name = "CityDG";
            // 
            // StatusDG
            // 
            this.StatusDG.HeaderText = "Status";
            this.StatusDG.Name = "StatusDG";
            this.StatusDG.Width = 50;
            // 
            // BlockDG
            // 
            this.BlockDG.HeaderText = "Block";
            this.BlockDG.Name = "BlockDG";
            this.BlockDG.Width = 50;
            // 
            // AdminShowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 260);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminShowUsers";
            this.Text = "Show All Users";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurNameDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockDG;
    }
}