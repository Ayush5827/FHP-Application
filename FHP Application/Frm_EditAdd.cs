using FHP_Application.Properties;
using FHP_BL;
using FHP_VO;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Resources.StaticResources;

namespace FHP_Application
{
    public partial class Frm_EditAdd : Form
    {
        cls_EmployeeProp employee;
        StaticResources resource;


        public Frm_EditAdd(cls_EmployeeProp employee, cls_DataProcessing dataProcessing, StaticResources resource, string openMode, [Optional] Dictionary<string, bool> userPermissions, [Optional] List<cls_EmployeeProp> employees)
        {
            InitializeComponent();

            this.employee = employee;

            if (employee.editMode == 1)
            {
                btn_Add.Enabled = true;
                btn_Edit.Enabled = false;
            } // editMode = Add

            else if (employee.editMode == 2)
            {
                btn_Add.Enabled = false;
                btn_Edit.Enabled = true;

                //------------------Showing Fields That can be edited----------------\\
                ShowingFields(employee);

            }  // editMode=Edit

            //------------- AddingDrop Down List for Qualification --------------\\
            foreach (QualificationEnum value in Enum.GetValues(typeof(QualificationEnum)))
            {
                var descriptionAttribute = (DescriptionAttribute[])value.GetType().GetField(value.ToString())
                                                               .GetCustomAttributes(typeof(DescriptionAttribute), false);
                string description = descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : value.ToString();
                comboBox_Qualification.Items.Add(description);
            }

            //------------------Serial Number Read Only Field---------------------\\
            txtBox_SerialNoEditAdd.Text = employee.SerialNo.ToString();

          

        }

        private void Form_Model_EditAdd_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {


            //-------------Setting properties--------------\\

            TakingInputsFromUser(employee);

            cls_DataProcessing dataProcessing = new cls_DataProcessing();

            //-------------Checking if data is valid or not----------------\\
            bool isValid = dataProcessing.SaveIntoFile(employee);

            if (isValid)
            {
                EmployeeOperationResult result = EmployeeOperationResult.AddedSuccessfully;
                MessageBox.Show(resource.GetDescription(result), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            } // if data is valid

            else
            {
                ValidationMessage retrievedMessage = StaticResources.GetValidationMessageFromByte(employee.ValidationMessage);
                MessageBox.Show(StaticResources.GetDescriptionString(retrievedMessage), "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void Form_Model_EditAdd_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }

        private void lbl_JoiningDate_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            TakingInputsFromUser(employee);

            cls_DataProcessing dataProcessing = new cls_DataProcessing();

            //-------------Checking if data is valid or not----------------\\
            bool isValid = dataProcessing.SaveIntoFile(employee);

            if (isValid)
            {
                EmployeeOperationResult result = EmployeeOperationResult.UpdatedSuccessfully;
                MessageBox.Show(resource.GetDescription(result), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            } // if data is valid

            else
            {
                ValidationMessage retrievedMessage = StaticResources.GetValidationMessageFromByte(employee.ValidationMessage);
                MessageBox.Show(StaticResources.GetDescriptionString(retrievedMessage), "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

        }
        private void ShowingFields(cls_EmployeeProp employee)
        {
            txtBox_PrefixEditAdd.Text = employee.Prefix;
            txtBox_FirstNameEditAdd.Text =employee.FirstName;
            txtBox_MiddleNameEditAdd.Text = employee.MiddleName;
            txtBox_LastNameEditAdd.Text = employee.LastName;
            txtBox_CurrentCompanyEditAdd.Text = employee.CurrentCompany;
            txtBox_CurrentAddressEditAdd.Text = employee.CurrentAddress;
            comboBox_Qualification.Text = StaticResources.GetQualificationDescriptionAtIndex(Convert.ToByte(employee.Education - 1));
            date_DOB.Text = employee.DOB.ToString("dd-MM-yyyy"); 
            date_Joining.Text = employee.JoiningDate.ToString("dd-MM-yyyy");

        }

        private void TakingInputsFromUser(cls_EmployeeProp employee)
        {
            employee.FirstName = txtBox_FirstNameEditAdd.Text;
            employee.MiddleName = txtBox_MiddleNameEditAdd.Text;
            employee.LastName = txtBox_LastNameEditAdd.Text;
            employee.Prefix = txtBox_PrefixEditAdd.Text;
            employee.DOB = date_DOB.Value;
            employee.JoiningDate = date_Joining.Value;
            employee.CurrentAddress = txtBox_CurrentAddressEditAdd.Text;
            employee.CurrentCompany = txtBox_CurrentCompanyEditAdd.Text;
            employee.Education = (byte)comboBox_Qualification.SelectedIndex;

        }

        
    }
}
