using  FHP_Application.Properties;
using FHP_BL;
using FHP_DL;
using FHP_VO;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Resources.StaticResources;

namespace FHP_Application
{

    public partial class Frm_EmpDetails : Form { 



         DataGridViewRow selectedRow;                            //--------Represents the selected Row
        cls_EmployeeProp employee;                                     //---------Represents an employee data ---[VO]----
        cls_DataProcessing dataProcess;                           //--------- Object of  Business Layer where my data is going to be process ---[BL]---
        List<cls_EmployeeProp> employees;                            //---------- List of Employees(Value Object) which will hold data for multiple employees
        Dictionary<string, bool> currentUserPermissions;
        cls_CredentialDataProp currentUser;
        StaticResources resource;
        Dictionary<string, string> filterRowValues;


        public Frm_EmpDetails(Dictionary<string, bool> currentUserPermissions, cls_CredentialDataProp currentUser)
        {
            InitializeComponent();
            //InitializeDataGridView();
            dgv_EmployeeData.EditMode = DataGridViewEditMode.EditOnEnter; // Set EditMode to EditOnEnter


            this.currentUser = currentUser;
            this.currentUserPermissions = currentUserPermissions;

            //-------------------Setting user------------------\\
            if (currentUser.UserRole == "SUPERADMIN")
            {
                lbl_role.Text = "Welcome SuperAdmin";

            }

            else if (currentUser.UserRole == "ADMIN")
            {
                lbl_role.Text = "Welcome Admin";
            }

            else if (currentUser.UserRole == "GUEST")
            {
                lbl_role.Text = "Welcome Guest";
            }
            else if (currentUser.UserRole == "SELF")
            {
                lbl_role.Text = "Welcome Developer";

            }

            //-------------Hiding fields according to user role-------------\\
            foreach (var kvp in currentUserPermissions)
            {
                string key = kvp.Key;
                bool havePermission = currentUserPermissions[key];

                if (key == "CanEdit" && havePermission == false)
                {
                    menu_Update.Visible = false;
                }

                else if (key == "CanAddEmp" && havePermission == false)
                {
                    menu_New.Visible = false;
                }

                else if (key == "CanDelete" && havePermission == false)
                {
                    menu_Delete.Visible = false;
                }
            }
            //----------Adding filter row----------\\
            dgv_EmployeeData.Rows.Add();
            DataGridViewRow filterRow = dgv_EmployeeData.Rows[0];
            dgv_EmployeeData.Rows[0].ReadOnly = false;


            resource = new StaticResources();
            dataProcess = new cls_DataProcessing();                 // Creating object of dataProcessing(Business Layer) it will read if there is any data in file     
            this.employees = dataProcess.GetEmployees();       //  Getting employees list
            if (employees != null && employees.Count > 0)
            {
                RenderEmployees(employees);
            }
            lbl_Status.Text = $"Total Records -> {employees.Count}";

            filterRowValues = new Dictionary<string, string>();


        }

       

      
        private void menu_New_Click(object sender, EventArgs e)
        {
            employee = new cls_EmployeeProp();       //-----Creating instance of new employee
            if (selectedRow != null)
            {
                int lastSecondRowIndex = dgv_EmployeeData.Rows.Count - 2;

                if (lastSecondRowIndex < 0)
                {
                    employee.SerialNo = 1;

                } // Means there are no records

                else
                {
                    int serialNoColumnIndex = dgv_EmployeeData.Columns["SerialNo"].Index;
                    if (serialNoColumnIndex != -1)
                    {
                        object serialNoValue = dgv_EmployeeData.Rows[lastSecondRowIndex].Cells[serialNoColumnIndex].Value;

                        if (serialNoValue != null)
                        {

                            int serialNo = Convert.ToInt32(serialNoValue);
                            employee.SerialNo = serialNo + 1;
                            Console.WriteLine($"SerialNo of last second row: {serialNo}");
                        }

                    }
                } // means there are some records


                //--------------Passing control to EditAdd Model form For adding employee ------------------\\

                Frm_EditAdd editAddModel = new Frm_EditAdd(employee, dataProcess,resource, "Add");
                editAddModel.ShowDialog();


                //-------------Refreshing the Grid View After Add---------------\\

                this.employees = dataProcess.GetEmployees();                       // Getting list of employees
                RenderEmployees(employees);                                      // rendering employees in DGV
            }
        }



        private void menu_Update_Click(object sender, EventArgs e)
        {

            int employeeCountInList = selectedRow.Index - 1;                            // index of that row [starting from 0]

            cls_EmployeeProp empDataToBeUpdate = employees[employeeCountInList];
            empDataToBeUpdate.editMode = 2;                                          // Setting the edit mode to 2 [Update]

            //--------------Passing control to EditAdd Model form For Updating employee ------------------\\
            Frm_EditAdd editAddModel = new Frm_EditAdd(empDataToBeUpdate, dataProcess, resource, "Edit", currentUserPermissions);
            editAddModel.ShowDialog();

            //-------------Refreshing the Grid View After Update---------------\\

            this.employees = dataProcess.GetEmployees();                       // Getting list of employees
            RenderEmployees(employees);
        }



        private void menu_Delete_Click(object sender, EventArgs e)
        {
            StaticResources.EmployeeOperationResult resultOp = StaticResources.EmployeeOperationResult.areYouSureWantToDelete;
            DialogResult confirmationResult = MessageBox.Show(resource.GetDescription(resultOp), "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (confirmationResult == DialogResult.Yes)
            {

                int employeeCountInList = selectedRow.Index - 1;                            // index of that row [starting from 0]
                cls_EmployeeProp empDataToBeDelete = employees[employeeCountInList];

                bool isEmployeeDeleted = dataProcess.DeleteEmployee(empDataToBeDelete,resource);

                if (isEmployeeDeleted)
                {
                    StaticResources.EmployeeOperationResult result = StaticResources.EmployeeOperationResult.DeletedSuccessfully;
                    MessageBox.Show(resource.GetDescription(result), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } // if employee is deleted successfully

                else
                {
                    StaticResources.ValidationMessage retrievedMessage = StaticResources.GetValidationMessageFromByte(employee.ValidationMessage);
                    _ = MessageBox.Show(StaticResources.GetDescriptionString(retrievedMessage), "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //-------------Refreshing the Grid View After Deltee---------------\\

                this.employees = dataProcess.GetEmployees();                       // Getting list of employees
                RenderEmployees(employees);                                 // Setting the isDeleted Property=true




            }
        }

        private void menu_View_Click(object sender, EventArgs e)
        {
            int employeeCountInList = selectedRow.Index - 1;
            cls_EmployeeProp empToBeViewed = employees[employeeCountInList];
            empToBeViewed.editMode = 3;

            //--------------Passing control to Details Edit/Add Model form For Viewing the  employee ------------------\\
            Frm_EditAdd frmEditAddForView = new Frm_EditAdd(empToBeViewed, dataProcess, resource, "View", employees: employees);
            frmEditAddForView.ShowDialog();
        }
        private void dgv_EmployeeData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedRow = dgv_EmployeeData.Rows[e.RowIndex]; // here selectRow is intialized with the row that user selects

            if (e.RowIndex == dgv_EmployeeData.RowCount - 1)
            {
                menu_New.Enabled = true;

                menu_View.Enabled = false;
                menu_Update.Enabled = false;
                menu_Delete.Enabled = false;
            } // this checks that whether this is the last row of employee table or not

            else if(e.RowIndex!=-1)
            {
                menu_View.Enabled = true;
                menu_Update.Enabled = true;
                menu_Delete.Enabled = true;

            }


           
        }

        private void RenderEmployees(List<cls_EmployeeProp> employees, [Optional] string colorCells)
        {
            for (int rowIdx = dgv_EmployeeData.Rows.Count - 2; rowIdx > 0; rowIdx--)
            {
                dgv_EmployeeData.Rows.RemoveAt(rowIdx);
            }

            dgv_EmployeeData.RowTemplate.Height = 50;

            for (int employeeNumber = 0; employeeNumber < employees.Count; employeeNumber++)
            {
                dgv_EmployeeData.Rows.Add();
                dgv_EmployeeData.Rows[employeeNumber + 1].ReadOnly = true;


                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[0].Value = employees[employeeNumber].SerialNo;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[1].Value = employees[employeeNumber].Prefix;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[2].Value = employees[employeeNumber].FirstName;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[3].Value = employees[employeeNumber].MiddleName;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[4].Value = employees[employeeNumber].LastName;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[5].Value = StaticResources.GetQualificationDescriptionAtIndex(employees[employeeNumber].Education);
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[6].Value = employees[employeeNumber].JoiningDate.ToString("dd-MM-yyyy");
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[7].Value = employees[employeeNumber].CurrentCompany;
                dgv_EmployeeData.Rows[employeeNumber + 1].Cells[8].Value = employees[employeeNumber].CurrentAddress;

                if (employees[employeeNumber].DOB != DateTimePicker.MinimumDateTime)
                {

                    dgv_EmployeeData.Rows[employeeNumber + 1].Cells[9].Value = employees[employeeNumber].DOB.ToString("dd-MM-yyyy");
                }

                else
                {
                    dgv_EmployeeData.Rows[employeeNumber + 1].Cells[9].Value = "";
                }


                //-------Coloring Cells if text Found
                if (colorCells != null)
                {
                    for (int colIdx = 0; colIdx < dgv_EmployeeData.Columns.Count; colIdx++)
                    {
                        string cellValue = dgv_EmployeeData.Rows[employeeNumber + 1].Cells[colIdx].Value?.ToString()?.ToLower();

                        if (!string.IsNullOrEmpty(cellValue) && cellValue.Contains(SearchFilter_txtBox.Text.ToLower().Trim()))
                        {
                            dgv_EmployeeData.Rows[employeeNumber + 1].Cells[colIdx].Style.BackColor = Color.Yellow; // Highlight color
                        }
                    }
                }
            }

            dgv_EmployeeData.Rows[dgv_EmployeeData.Rows.Count - 1].ReadOnly = true;

            lbl_Status.Text = $"Total records -> {employees.Count}";
        }


        private void dgv_EmployeeData_SelectionChanged(object sender, EventArgs e)
        {
            bool anyCellSelected = dgv_EmployeeData.SelectedCells.Count > 0 &&
                         dgv_EmployeeData.SelectedCells[0].ColumnIndex != -1;

            if (dgv_EmployeeData.SelectedRows.Count > 1)
            {
                menu_Delete.Enabled = true;

            } // if user selects multiple row 
            else
            {
                menu_Delete.Enabled = false;
                menu_New.Enabled = false;
                menu_View.Enabled = false;
                menu_Update.Enabled = false;

            }  
        }

        private void aBOUTUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUs = new AboutUsForm(resource);
            aboutUs.ShowDialog();
        }

        private void lbl_Status_Click(object sender, EventArgs e)
        {

        }

        private void lbl_role__Click(object sender, EventArgs e)
        {

        }

        private void filterSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgv_EmployeeData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dgv_EmployeeData.RowCount - 1 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                e.Graphics.FillRectangle(new SolidBrush(Color.Green), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }


                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            } // for last Row

            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {

                e.Graphics.FillRectangle(new SolidBrush(Color.SteelBlue), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            } // for col header row

            if (e.ColumnIndex == -1 && e.RowIndex >= 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.SteelBlue), e.CellBounds);
                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;

            }  // for row header row

            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.SlateGray), e.CellBounds);

                using (Pen p = new Pen(Color.White, 1))
                {
                    e.Graphics.DrawRectangle(p, e.CellBounds);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;

            }// for filter row

        }    // Event For Painting the Cell Header's and Last row
        private void dgv_EmployeeData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex == 0)
            {
                // Get the column name
                string columnName = dgv_EmployeeData.Columns[e.ColumnIndex].Name;

                // Get the entered value
                string enteredValue = dgv_EmployeeData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Update or add the value in the dictionary
                if (filterRowValues.ContainsKey(columnName))
                {
                    filterRowValues[columnName] = enteredValue;
                }
                else
                {
                    filterRowValues.Add(columnName, enteredValue);
                }


                ApplyFilter(filterRowValues);
            }

        }
        private void dgv_EmployeeData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                dgv_EmployeeData.CurrentCell = dgv_EmployeeData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgv_EmployeeData.BeginEdit(true);

            }
        }
        private void dgv_EmployeeData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                dgv_EmployeeData.CurrentCell = dgv_EmployeeData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgv_EmployeeData.BeginEdit(true);
                dgv_EmployeeData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Or handle the value accordingly

            }
        }
        private void btn_clearFilterAndSearch_Click(object sender, EventArgs e)
        {
            SearchFilter_txtBox.Text = "";

            if (dgv_EmployeeData.Rows.Count > 0)
            {
                DataGridViewRow firstRow = dgv_EmployeeData.Rows[0];
                foreach (DataGridViewCell cell in firstRow.Cells)
                {
                    cell.Value = ""; // Set cell value to null or an empty string
                }
            }
            RenderEmployees(employees);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            string textToBeSearched = SearchFilter_txtBox.Text.ToLower();
            textToBeSearched = textToBeSearched.Trim();


            List<cls_EmployeeProp> searchedEmployees = employees
                .Where(employee =>
                {
                    return employee != null &&
                           employee.GetType().GetProperties()
                               .Any(property =>
                               {
                                   if (property.Name == "Education" && property.PropertyType == typeof(byte))
                                   {
                                       var value = (byte)property.GetValue(employee, null);
                                       var qualificationDescription = StaticResources.GetQualificationDescriptionAtIndex((byte)(value));
                                       return qualificationDescription.ToLower().IndexOf(textToBeSearched) >= 0;
                                   }
                                   else
                                   {
                                       var value = property.GetValue(employee, null);
                                       return value != null && value.ToString().ToLower().IndexOf(textToBeSearched) >= 0;
                                   }
                               });
                })
                .ToList();
            if (!string.IsNullOrWhiteSpace(textToBeSearched) || !string.IsNullOrEmpty(textToBeSearched))
            {
                RenderEmployees(searchedEmployees, "color cells");
            }
        }
        private void dgv_EmployeeData_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int employeeCountInList = selectedRow.Index - 1;
            cls_EmployeeProp empToBeViewed = employees[employeeCountInList];

            //--------------Passing control to Details Views Model form For Updating employee ------------------\\
            Frm_ReadonlyDetails viewDetails = new Frm_ReadonlyDetails(this.employees, empToBeViewed, resource);
            viewDetails.ShowDialog();
        }   
        private void menu_aboutUs_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUs = new AboutUsForm(resource);
            aboutUs.ShowDialog();
        }

        //---------------------------------Member Functions ----------------------------------\\

        /// <summary>
        /// Applies the specified filter criteria to the list of employees and renders the filtered results.
        /// </summary>
        /// <param name="filterRow">A dictionary representing filter criteria where the key is the column name and the value is the filter value.</param>
        private void ApplyFilter(Dictionary<string, string> filterRow)
        {
            List<cls_EmployeeProp> filteredEmployees = employees.Where(employee =>
            {
                foreach (var kvp in filterRow)
                {
                    var propertyValue = "";

                    if (kvp.Key == "Qualification")
                    {
                        propertyValue = StaticResources.GetQualificationDescriptionAtIndex(employee.Education); ;

                    }
                    else
                    {

                        propertyValue = employee.GetType().GetProperty(kvp.Key)?.GetValue(employee, null)?.ToString() ?? "";

                    }
                    //------ Checking if  the property value contains value entered in filter row
                    if (kvp.Value != null && !propertyValue.ToLower().Contains(kvp.Value.ToLower()))
                    {
                        return false; // if no value were matched
                    }
                }
                return true; // if filter Conditions matched
            }).ToList();

            RenderEmployees(filteredEmployees);
        }

        private void btn_searchRecords_Click(object sender, EventArgs e)
        {
            SearchFilter_txtBox.Text = "";

            if (dgv_EmployeeData.Rows.Count > 0)
            {
                DataGridViewRow firstRow = dgv_EmployeeData.Rows[0];
                foreach (DataGridViewCell cell in firstRow.Cells)
                {
                    cell.Value = ""; // Set cell value to null or an empty string
                }
            }
            RenderEmployees(employees);
        }

        private void SearchFilter_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_EmployeeData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void Frm_EmpDetails_Load(object sender, EventArgs e)
        {
            // Initialization code for the form
            //AddSearchRowToDataGridView(dgv_EmployeeData);

        }


        //private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    // Clear the filter when the DataGridView data binding is complete
        //    DataGridView dataGridView = (DataGridView)sender;
        //    dataGridView.Rows[0].Cells.Cast<DataGridViewCell>().ToList().ForEach(c => c.Value = null);
        //    (dataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
        //}
        private void dgv_EmployeeData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;

            if (textBox != null)
            {
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            //----------Handling filter after user enter three characters------------\\
            const int triggerLength = 3;
            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Text.Length >= triggerLength)
            {
                SendKeys.Send("{ENTER}");
                int rowIndex = dgv_EmployeeData.CurrentCell.RowIndex;
                int columnIndex = dgv_EmployeeData.CurrentCell.ColumnIndex;

                string columnName = dgv_EmployeeData.Columns[columnIndex].Name;
                string enteredValue = dgv_EmployeeData.Rows[rowIndex].Cells[columnIndex].Value?.ToString();

                if (filterRowValues.ContainsKey(columnName))
                {
                    filterRowValues[columnName] = enteredValue;
                }
                else
                {
                    filterRowValues.Add(columnName, enteredValue);
                }

                ApplyFilter(filterRowValues);

            }
        }
    }

}
