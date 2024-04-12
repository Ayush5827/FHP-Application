namespace FHP_Application
{
    partial class AboutUsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUsForm));
            this.Aboutus_PicBox = new System.Windows.Forms.PictureBox();
            this.aboutUs_RtxtBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Aboutus_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Aboutus_PicBox
            // 
            this.Aboutus_PicBox.Image = ((System.Drawing.Image)(resources.GetObject("Aboutus_PicBox.Image")));
            this.Aboutus_PicBox.Location = new System.Drawing.Point(138, 12);
            this.Aboutus_PicBox.Name = "Aboutus_PicBox";
            this.Aboutus_PicBox.Size = new System.Drawing.Size(458, 99);
            this.Aboutus_PicBox.TabIndex = 0;
            this.Aboutus_PicBox.TabStop = false;
            this.Aboutus_PicBox.Click += new System.EventHandler(this.Aboutus_PicBox_Click);
            // 
            // aboutUs_RtxtBox
            // 
            this.aboutUs_RtxtBox.BackColor = System.Drawing.Color.Lavender;
            this.aboutUs_RtxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutUs_RtxtBox.Location = new System.Drawing.Point(-1, 161);
            this.aboutUs_RtxtBox.Name = "aboutUs_RtxtBox";
            this.aboutUs_RtxtBox.Size = new System.Drawing.Size(801, 288);
            this.aboutUs_RtxtBox.TabIndex = 1;
            this.aboutUs_RtxtBox.Text = "";
            this.aboutUs_RtxtBox.TextChanged += new System.EventHandler(this.aboutUs_RtxtBox_TextChanged);
            // 
            // AboutUsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutUs_RtxtBox);
            this.Controls.Add(this.Aboutus_PicBox);
            this.Name = "AboutUsForm";
            this.Text = "AboutUsForm";
            this.Load += new System.EventHandler(this.AboutUsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Aboutus_PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Aboutus_PicBox;
        private System.Windows.Forms.RichTextBox aboutUs_RtxtBox;
    }
}