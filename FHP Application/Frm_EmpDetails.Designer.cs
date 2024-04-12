using System.Windows.Forms;

namespace FHP_Application
{
    partial class Frm_EmpDetails
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
            this.dgv_EmployeeData = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_New = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_role = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SearchFilter_txtBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JoiningDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_EmployeeData
            // 
            this.dgv_EmployeeData.AllowUserToOrderColumns = true;
            this.dgv_EmployeeData.BackgroundColor = System.Drawing.Color.White;
            this.dgv_EmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmployeeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNo,
            this.Prefix,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.Qualification,
            this.JoiningDate,
            this.CurrentCompany,
            this.CurrentAddress,
            this.DOB});
            this.dgv_EmployeeData.Location = new System.Drawing.Point(3, 73);
            this.dgv_EmployeeData.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_EmployeeData.Name = "dgv_EmployeeData";
            this.dgv_EmployeeData.RowHeadersWidth = 51;
            this.dgv_EmployeeData.Size = new System.Drawing.Size(1483, 677);
            this.dgv_EmployeeData.TabIndex = 0;
            this.dgv_EmployeeData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmployeeData_CellContentClick);
            this.dgv_EmployeeData.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_EmployeeData_RowHeaderMouseClick);
            this.dgv_EmployeeData.SelectionChanged += new System.EventHandler(this.dgv_EmployeeData_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_New,
            this.menu_Update,
            this.menu_Delete,
            this.menu_View,
            this.aBOUTUSToolStripMenuItem,
            this.filterSearchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1487, 36);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_New
            // 
            this.menu_New.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_New.Enabled = false;
            this.menu_New.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_New.Name = "menu_New";
            this.menu_New.Size = new System.Drawing.Size(73, 32);
            this.menu_New.Text = "NEW";
            this.menu_New.Click += new System.EventHandler(this.menu_New_Click);
            // 
            // menu_Update
            // 
            this.menu_Update.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_Update.Enabled = false;
            this.menu_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Update.Name = "menu_Update";
            this.menu_Update.Size = new System.Drawing.Size(103, 32);
            this.menu_Update.Text = "UPDATE";
            this.menu_Update.Click += new System.EventHandler(this.menu_Update_Click);
            // 
            // menu_Delete
            // 
            this.menu_Delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_Delete.Enabled = false;
            this.menu_Delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_Delete.Name = "menu_Delete";
            this.menu_Delete.Size = new System.Drawing.Size(96, 32);
            this.menu_Delete.Text = "DELETE";
            this.menu_Delete.Click += new System.EventHandler(this.menu_Delete_Click);
            // 
            // menu_View
            // 
            this.menu_View.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menu_View.Enabled = false;
            this.menu_View.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_View.ForeColor = System.Drawing.Color.Black;
            this.menu_View.Name = "menu_View";
            this.menu_View.Size = new System.Drawing.Size(76, 32);
            this.menu_View.Text = "VIEW";
            this.menu_View.Click += new System.EventHandler(this.menu_View_Click);
            // 
            // aBOUTUSToolStripMenuItem
            // 
            this.aBOUTUSToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.aBOUTUSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aBOUTUSToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aBOUTUSToolStripMenuItem.Name = "aBOUTUSToolStripMenuItem";
            this.aBOUTUSToolStripMenuItem.Size = new System.Drawing.Size(117, 32);
            this.aBOUTUSToolStripMenuItem.Text = "ABOUT US";
            this.aBOUTUSToolStripMenuItem.Click += new System.EventHandler(this.aBOUTUSToolStripMenuItem_Click);
            // 
            // filterSearchToolStripMenuItem
            // 
            this.filterSearchToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.filterSearchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterSearchToolStripMenuItem.Name = "filterSearchToolStripMenuItem";
            this.filterSearchToolStripMenuItem.Size = new System.Drawing.Size(134, 32);
            this.filterSearchToolStripMenuItem.Text = "Filter/Search";
            this.filterSearchToolStripMenuItem.Click += new System.EventHandler(this.filterSearchToolStripMenuItem_Click);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(682, 0);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(157, 20);
            this.lbl_Status.TabIndex = 5;
            this.lbl_Status.Text = "Total Records -> ";
            this.lbl_Status.Click += new System.EventHandler(this.lbl_Status_Click);
            // 
            // lbl_role
            // 
            this.lbl_role.AutoSize = true;
            this.lbl_role.BackColor = System.Drawing.Color.White;
            this.lbl_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_role.Location = new System.Drawing.Point(1115, 9);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(86, 20);
            this.lbl_role.TabIndex = 6;
            this.lbl_role.Text = "Welcome";
            this.lbl_role.Click += new System.EventHandler(this.lbl_role__Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(838, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search/Filter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_searchRecords_Click);
            // 
            // SearchFilter_txtBox
            // 
            this.SearchFilter_txtBox.Location = new System.Drawing.Point(998, 28);
            this.SearchFilter_txtBox.Multiline = true;
            this.SearchFilter_txtBox.Name = "SearchFilter_txtBox";
            this.SearchFilter_txtBox.Size = new System.Drawing.Size(124, 35);
            this.SearchFilter_txtBox.TabIndex = 8;
            this.SearchFilter_txtBox.TextChanged += new System.EventHandler(this.SearchFilter_txtBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1138, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // SerialNo
            // 
            this.SerialNo.HeaderText = "S No.";
            this.SerialNo.MinimumWidth = 6;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Width = 50;
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.MinimumWidth = 6;
            this.Prefix.Name = "Prefix";
            this.Prefix.ReadOnly = true;
            this.Prefix.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.Width = 125;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Middle Name";
            this.MiddleName.MinimumWidth = 6;
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.Width = 125;
            // 
            // Qualification
            // 
            this.Qualification.HeaderText = "Qualification";
            this.Qualification.MinimumWidth = 6;
            this.Qualification.Name = "Qualification";
            this.Qualification.Width = 180;
            // 
            // JoiningDate
            // 
            this.JoiningDate.HeaderText = "Joining Date";
            this.JoiningDate.MinimumWidth = 6;
            this.JoiningDate.Name = "JoiningDate";
            this.JoiningDate.ReadOnly = true;
            this.JoiningDate.Width = 125;
            // 
            // CurrentCompany
            // 
            this.CurrentCompany.HeaderText = "Current Company";
            this.CurrentCompany.MinimumWidth = 6;
            this.CurrentCompany.Name = "CurrentCompany";
            this.CurrentCompany.Width = 125;
            // 
            // CurrentAddress
            // 
            this.CurrentAddress.HeaderText = "Current Address";
            this.CurrentAddress.MinimumWidth = 6;
            this.CurrentAddress.Name = "CurrentAddress";
            this.CurrentAddress.Width = 250;
            // 
            // DOB
            // 
            this.DOB.HeaderText = "DOB";
            this.DOB.MinimumWidth = 6;
            this.DOB.Name = "DOB";
            this.DOB.Width = 125;
            // 
            // Frm_EmpDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 742);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SearchFilter_txtBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_role);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.dgv_EmployeeData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_EmpDetails";
            this.Text = "FHP";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmployeeData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleNameq;
        private System.Windows.Forms.DataGridView dgv_EmployeeData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem menu_New;
        public System.Windows.Forms.ToolStripMenuItem menu_Update;
        public System.Windows.Forms.ToolStripMenuItem menu_Delete;
        public System.Windows.Forms.ToolStripMenuItem menu_View;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ToolStripMenuItem aBOUTUSToolStripMenuItem;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.ToolStripMenuItem filterSearchToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SearchFilter_txtBox;
        private Button button2;
        private DataGridViewTextBoxColumn SerialNo;
        private DataGridViewTextBoxColumn Prefix;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn Qualification;
        private DataGridViewTextBoxColumn JoiningDate;
        private DataGridViewTextBoxColumn CurrentCompany;
        private DataGridViewTextBoxColumn CurrentAddress;
        private DataGridViewTextBoxColumn DOB;
    }
}

