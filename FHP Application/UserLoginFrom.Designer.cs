namespace FHP_Application
{
    partial class UserLoginFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginFrom));
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.UserId_txtBox = new System.Windows.Forms.TextBox();
            this.PasswordTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PcBox_eyeIcon = new System.Windows.Forms.PictureBox();
            this.Login_PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PcBox_eyeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserId.Location = new System.Drawing.Point(82, 219);
            this.lbl_UserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(144, 29);
            this.lbl_UserId.TabIndex = 0;
            this.lbl_UserId.Text = "User Name";
            this.lbl_UserId.Click += new System.EventHandler(this.lbl_UserId_Click);
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(82, 309);
            this.lbl_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(128, 29);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password";
            this.lbl_Password.Click += new System.EventHandler(this.lbl_Password_Click);
            // 
            // UserId_txtBox
            // 
            this.UserId_txtBox.Location = new System.Drawing.Point(259, 216);
            this.UserId_txtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserId_txtBox.Multiline = true;
            this.UserId_txtBox.Name = "UserId_txtBox";
            this.UserId_txtBox.Size = new System.Drawing.Size(338, 51);
            this.UserId_txtBox.TabIndex = 2;
            this.UserId_txtBox.TextChanged += new System.EventHandler(this.UserId_txtBox_TextChanged);
            // 
            // PasswordTxtBox
            // 
            this.PasswordTxtBox.Location = new System.Drawing.Point(259, 296);
            this.PasswordTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTxtBox.Multiline = true;
            this.PasswordTxtBox.Name = "PasswordTxtBox";
            this.PasswordTxtBox.Size = new System.Drawing.Size(338, 52);
            this.PasswordTxtBox.TabIndex = 3;
            this.PasswordTxtBox.TextChanged += new System.EventHandler(this.PasswordTxtBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(368, 392);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PcBox_eyeIcon
            // 
            this.PcBox_eyeIcon.ErrorImage = null;
            this.PcBox_eyeIcon.Image = ((System.Drawing.Image)(resources.GetObject("PcBox_eyeIcon.Image")));
            this.PcBox_eyeIcon.Location = new System.Drawing.Point(556, 309);
            this.PcBox_eyeIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PcBox_eyeIcon.Name = "PcBox_eyeIcon";
            this.PcBox_eyeIcon.Size = new System.Drawing.Size(27, 21);
            this.PcBox_eyeIcon.TabIndex = 5;
            this.PcBox_eyeIcon.TabStop = false;
            this.PcBox_eyeIcon.Click += new System.EventHandler(this.EyeIcon_Click);
            // 
            // Login_PictureBox
            // 
            this.Login_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("Login_PictureBox.Image")));
            this.Login_PictureBox.Location = new System.Drawing.Point(368, 65);
            this.Login_PictureBox.Name = "Login_PictureBox";
            this.Login_PictureBox.Size = new System.Drawing.Size(123, 129);
            this.Login_PictureBox.TabIndex = 6;
            this.Login_PictureBox.TabStop = false;
            this.Login_PictureBox.Click += new System.EventHandler(this.Login_PictureBox_Click);
            // 
            // UserLoginFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(827, 505);
            this.Controls.Add(this.Login_PictureBox);
            this.Controls.Add(this.PcBox_eyeIcon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordTxtBox);
            this.Controls.Add(this.UserId_txtBox);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_UserId);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserLoginFrom";
            this.Text = "UserLoginFrom";
            this.Load += new System.EventHandler(this.UserLoginFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PcBox_eyeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Login_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox UserId_txtBox;
        private System.Windows.Forms.TextBox PasswordTxtBox;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.PictureBox PcBox_eyeIcon;
        private System.Windows.Forms.PictureBox Login_PictureBox;
    }
}