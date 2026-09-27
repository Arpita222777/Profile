namespace BLOOD_MANAGEMENT_SYSREM
{
    partial class Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.EmpPassTb1 = new System.Windows.Forms.Label();
            this.EmpNameTb1 = new System.Windows.Forms.Label();
            this.EmpNameTb = new System.Windows.Forms.TextBox();
            this.EmployeeDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.EmpPassTb = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(785, 112);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(752, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 40);
            this.label10.TabIndex = 54;
            this.label10.Text = "Employees";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(586, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 46);
            this.button1.TabIndex = 59;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmpPassTb1
            // 
            this.EmpPassTb1.AutoSize = true;
            this.EmpPassTb1.BackColor = System.Drawing.Color.White;
            this.EmpPassTb1.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmpPassTb1.ForeColor = System.Drawing.Color.Red;
            this.EmpPassTb1.Location = new System.Drawing.Point(1035, 490);
            this.EmpPassTb1.Name = "EmpPassTb1";
            this.EmpPassTb1.Size = new System.Drawing.Size(113, 30);
            this.EmpPassTb1.TabIndex = 57;
            this.EmpPassTb1.Text = "Password";
            // 
            // EmpNameTb1
            // 
            this.EmpNameTb1.AutoSize = true;
            this.EmpNameTb1.BackColor = System.Drawing.Color.White;
            this.EmpNameTb1.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmpNameTb1.ForeColor = System.Drawing.Color.Red;
            this.EmpNameTb1.Location = new System.Drawing.Point(501, 480);
            this.EmpNameTb1.Name = "EmpNameTb1";
            this.EmpNameTb1.Size = new System.Drawing.Size(80, 31);
            this.EmpNameTb1.TabIndex = 56;
            this.EmpNameTb1.Text = "Name ";
            // 
            // EmpNameTb
            // 
            this.EmpNameTb.BackColor = System.Drawing.Color.White;
            this.EmpNameTb.Location = new System.Drawing.Point(497, 514);
            this.EmpNameTb.Multiline = true;
            this.EmpNameTb.Name = "EmpNameTb";
            this.EmpNameTb.Size = new System.Drawing.Size(247, 33);
            this.EmpNameTb.TabIndex = 55;
            // 
            // EmployeeDGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.EmployeeDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeDGV.ColumnHeadersHeight = 4;
            this.EmployeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmployeeDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeeDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.EmployeeDGV.Location = new System.Drawing.Point(359, 157);
            this.EmployeeDGV.Name = "EmployeeDGV";
            this.EmployeeDGV.RowHeadersVisible = false;
            this.EmployeeDGV.RowHeadersWidth = 51;
            this.EmployeeDGV.RowTemplate.Height = 24;
            this.EmployeeDGV.Size = new System.Drawing.Size(1031, 320);
            this.EmployeeDGV.TabIndex = 61;
            this.EmployeeDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.EmployeeDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.EmployeeDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.EmployeeDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.EmployeeDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.EmployeeDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.EmployeeDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.EmployeeDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.EmployeeDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.EmployeeDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.EmployeeDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.EmployeeDGV.ThemeStyle.HeaderStyle.Height = 4;
            this.EmployeeDGV.ThemeStyle.ReadOnly = false;
            this.EmployeeDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.EmployeeDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.EmployeeDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.EmployeeDGV.ThemeStyle.RowsStyle.Height = 24;
            this.EmployeeDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.EmployeeDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.EmployeeDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeDGV_CellContentClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(817, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 46);
            this.button2.TabIndex = 62;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1040, 572);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 46);
            this.button3.TabIndex = 63;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EmpPassTb
            // 
            this.EmpPassTb.BackColor = System.Drawing.Color.White;
            this.EmpPassTb.Location = new System.Drawing.Point(1040, 523);
            this.EmpPassTb.Multiline = true;
            this.EmpPassTb.Name = "EmpPassTb";
            this.EmpPassTb.Size = new System.Drawing.Size(247, 33);
            this.EmpPassTb.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(311, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1157, 62);
            this.panel2.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(287, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "BLOOD BANK MANAGEMENT SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(71, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employees";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(102, 566);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 35);
            this.label9.TabIndex = 15;
            this.label9.Text = "Logout";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkCyan;
            this.panel3.Location = new System.Drawing.Point(42, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 35);
            this.panel3.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 647);
            this.panel1.TabIndex = 52;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1468, 647);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.EmpPassTb);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EmpPassTb1);
            this.Controls.Add(this.EmpNameTb1);
            this.Controls.Add(this.EmpNameTb);
            this.Controls.Add(this.EmployeeDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label EmpPassTb1;
        private System.Windows.Forms.Label EmpNameTb1;
        private System.Windows.Forms.TextBox EmpNameTb;
        private Guna.UI2.WinForms.Guna2DataGridView EmployeeDGV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox EmpPassTb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}