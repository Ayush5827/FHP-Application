using FHP_Application.Properties;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 using static Resources.StaticResources;
using System.Windows.Forms.VisualStyles;

namespace FHP_Application
{
    public partial class AboutUsForm : Form
    {
        StaticResources resource;
        public AboutUsForm(StaticResources resource)
        {
            InitializeComponent();
            this.resource = resource;
            //DisplayAboutUsSection(AboutUsSection.Overview);
            //DisplayAboutUsSection(AboutUsSection.BusinessActivities);
            //DisplayAboutUsSection(AboutUsSection.OurComprehensiveSoftware);
            //DisplayAboutUsSection(AboutUsSection.OurBusiness);
            DisplayAboutUsSection(AboutUsSection.Overview);
            DisplayAboutUsSection(AboutUsSection.OurComprehensiveSoftware);
            DisplayAboutUsSection(AboutUsSection.OurBusiness);
        }

        private void AboutUsForm_Load(object sender, EventArgs e)
        {

        }

        private void Aboutus_PicBox_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void DisplayAboutUsSection(AboutUsSection section)
        {
            switch (section)
            {
                case AboutUsSection.Overview:
                    DisplayContent("About Us", bold: true, color: Color.Red);
                     DisplayContent("Headquartered in Mohali, India the company was incorporated in the year 1999. Today with over 20 years of experience, we are one of the fastest growing companies in the marine IT field serving many top shipping companies around the globe.");
                    DisplayContent("");
                    DisplayContent("Our comprehensive and integrated Ship Management Software titled “SMMS – Ship Maintenance & Management System” has been implemented on more than 1500 vessels worldwide.");
                    DisplayContent("");
                    break;
                case AboutUsSection.OurComprehensiveSoftware:
                    DisplayContent("Our Business", bold: true, color: Color.Red);
                    DisplayBulletedContent(new string[]
                    {
                    "Development of Software Applications",
                    "Creation of PMS & Inventory Databases for Vessels",
                    "24x7 Technical Support",
                    "On Site Implementations and Trainings",
                    "Remote and On-board I.T. Services",
                    "Documents Digitization"
                    });
                     break;
                
            }
        }

        private void DisplayContent(string content, bool bold = false, Color? color = null)
        {
            aboutUs_RtxtBox.SelectionFont = new Font(aboutUs_RtxtBox.Font, bold ? FontStyle.Bold : FontStyle.Regular);
            aboutUs_RtxtBox.SelectionColor = color ?? Color.Black; // Default color is black if not specified

            aboutUs_RtxtBox.AppendText(content + "\n"); // Add double newline characters after each content
            aboutUs_RtxtBox.SelectionIndent = 20; // Adjust spacing as needed
            aboutUs_RtxtBox.AppendText(" \u2022 ");
            // Reset font style and color to defaults
            aboutUs_RtxtBox.SelectionFont = aboutUs_RtxtBox.Font;
            aboutUs_RtxtBox.SelectionColor = aboutUs_RtxtBox.ForeColor;
        }
        private void DisplayBulletedContent(string[] content, bool bold = false, Color? color = null)
        {
            foreach (string item in content)
            {
                aboutUs_RtxtBox.AppendText("\n"); // Add space before starting every line

                aboutUs_RtxtBox.SelectionIndent = 20; // Adjust spacing as needed
                aboutUs_RtxtBox.AppendText(" \u2022 "); // Append bullet character with space before it
                DisplayContent(item, bold, color); // Display each item with specified style
                aboutUs_RtxtBox.AppendText(Environment.NewLine); // Add a new line after each item
            }
            aboutUs_RtxtBox.SelectionBullet = false; // Dis
        }
        private void aboutUs_RtxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
