using FHP_DL;
using FHP_VO;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FHP_VO.cls_EmployeeProp;
using static Resources.StaticResources;

namespace FHP_BL
{
    


    public class cls_DataProcessing
    {
        cls_FileHandling fileHandler;

        public cls_EmployeeProp employee;
        public List<cls_EmployeeProp> employeesList;
        StaticResources resource;

        public cls_DataProcessing( )
        {
            //this.employeesList = FileHandler.GetAllEmployee();
            fileHandler = new cls_FileHandling();

        }
        public cls_DataProcessing(cls_EmployeeProp employee)
        {
            this.employee = employee;
            this.employeesList = cls_FileHandling.GetAllEmployee();
        }

        public bool SaveIntoFile(cls_EmployeeProp employee)
        {
            if (isValid(employee))
            {
                if (employee.editMode == 1)
                {
                    cls_FileHandling.AddEmployeeInfoIntoFile(employee);

                } // Adding a new Record

                else if (employee.editMode == 2)
                {
                    cls_FileHandling.UpdateEntry(employee);
                } // Updating a present Record

                return true;

            } // if employee has valid details

            return false;
        }
        private bool isValid(cls_EmployeeProp employee)
        {
            bool isValid = true;

            //--------------- Validating Empty fields--------------\\
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrWhiteSpace(employee.FirstName))
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.FirstNameEmpty);
            }

            else if (string.IsNullOrEmpty(employee.CurrentCompany) || string.IsNullOrWhiteSpace(employee.CurrentCompany))
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.CurrentCompanyEmpty);
            }

            else if (employee.Education == 0)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.QualificationEmpty);
            }

            //-----------Validating fields length-------------\\

            else if (employee.FirstName.Length > 50)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.FirstNameTooLong);
            }

            else if (employee.LastName.Length > 50)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.LastNameTooLong);
            }

            else if (employee.MiddleName.Length > 25)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.MiddleNameTooLong);
            }

            else if (employee.CurrentAddress.Length > 500)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.CurrentAddressTooLong);

            }

            else if (employee.CurrentCompany.Length > 255)
            {
                isValid = false;
                employee.ValidationMessage = StaticResources.GetValidationMessageAsByte(ValidationMessage.CurrentCompanyTooLong);

            }

            return isValid;


        }
        public List<cls_EmployeeProp> GetEmployees()
        {
            return cls_FileHandling.GetAllEmployee();
        }

        /// <summary>
        /// Deletes an employee data from the file.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee data to be deleted.</param>
        /// <param name="resource">Resource object for additional functionality.</param>
        /// <returns>True if the employee data is deleted successfully, otherwise false.</returns>
        public bool DeleteEmployee(cls_EmployeeProp empDataToBeDelete, StaticResources resource)
        {
            if (empDataToBeDelete.editMode != 3)
            {
                empDataToBeDelete.isDeleted = true;
                fileHandler.DeleteEmployeeFromDatabase(empDataToBeDelete);
                return true;

            } // Means the user is not readOnly user 

            empDataToBeDelete.ValidationMessage = (byte)StaticResources.ValidationMessage.ReadOnlyUserCannotDelete;
            return false;        // returning false means that user is readOnly user cannot delete data
        }
    }
}
