using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FHP_VO;
using System.Windows.Forms;

namespace FHP_DL
{
    public class cls_FileHandling
    {
        private static string connectionString = @"Data Source=AYUSH;DataBase=FHP;Trusted_Connection=true;TrustServerCertificate=true";

        /// <summary>
        /// Adds employee information into the SQL database.
        /// </summary>
        /// <param name="employee">The employee object containing information to be added.</param>
        public static void AddEmployeeInfoIntoFile(cls_EmployeeProp employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
    MERGE INTO Employees AS target
    USING (VALUES (@SerialNo, @Prefix, @FirstName, @MiddleName, @LastName, @Education, @JoiningDate, @CurrentCompany, @CurrentAddress, @DOB)) AS source (SerialNo, Prefix, FirstName, MiddleName, LastName, Education, JoiningDate, CurrentCompany, CurrentAddress, DOB)
    ON (target.SerialNo = source.SerialNo)
    WHEN MATCHED THEN
        UPDATE SET 
            Prefix = source.Prefix,
            FirstName = source.FirstName,
            MiddleName = source.MiddleName,
            LastName = source.LastName,
            Education = source.Education,
            JoiningDate = source.JoiningDate,
            CurrentCompany = source.CurrentCompany,
            CurrentAddress = source.CurrentAddress,
            DOB = source.DOB
    WHEN NOT MATCHED THEN
        INSERT (SerialNo, Prefix, FirstName, MiddleName, LastName, Education, JoiningDate, CurrentCompany, CurrentAddress, DOB)
        VALUES (source.SerialNo, source.Prefix, source.FirstName, source.MiddleName, source.LastName, source.Education, source.JoiningDate, source.CurrentCompany, source.CurrentAddress, source.DOB);
";
                    //string query = "INSERT INTO Employees (SerialNo, Prefix, FirstName, MiddleName, LastName, Education, JoiningDate, CurrentCompany, CurrentAddress, DOB) " +
                    //               "VALUES (@SerialNo, @Prefix, @FirstName, @MiddleName, @LastName, @Education, @JoiningDate, @CurrentCompany, @CurrentAddress, @DOB)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SerialNo", employee.SerialNo);
                        command.Parameters.AddWithValue("@Prefix", employee.Prefix);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@Education", employee.Education);
                        command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                        command.Parameters.AddWithValue("@CurrentCompany", employee.CurrentCompany);
                        command.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
                        command.Parameters.AddWithValue("@DOB", employee.DOB);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves all employees from the SQL database.
        /// </summary>
        /// <returns>A list of Employee objects containing all employees.</returns>
        public static List<cls_EmployeeProp> GetAllEmployee()
        {
            List<cls_EmployeeProp> employees = new List<cls_EmployeeProp>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cls_EmployeeProp employee = new cls_EmployeeProp();
                                employee.SerialNo = (long)reader["SerialNo"];
                                employee.Prefix = reader["Prefix"].ToString();
                                employee.FirstName = reader["FirstName"].ToString();
                                employee.MiddleName = reader["MiddleName"].ToString();
                                employee.LastName = reader["LastName"].ToString();
                                employee.Education = (byte)reader["Education"];
                                employee.JoiningDate = (DateTime)reader["JoiningDate"];
                                employee.CurrentCompany = reader["CurrentCompany"].ToString();
                                employee.CurrentAddress = reader["CurrentAddress"].ToString();
                                employee.DOB = (DateTime)reader["DOB"];
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }

        public static  cls_EmployeeProp GetEmployeeById(int id)
        {
            cls_EmployeeProp employee = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE SerialNo = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new cls_EmployeeProp
                    {
                        SerialNo = Convert.ToInt32(reader["SerialNo"]),
                        Prefix = reader["Prefix"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Education = (byte)reader["Education"],
                        CurrentAddress = reader["CurrentAddress"].ToString(),
                        CurrentCompany = reader["CurrentCompany"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"]),
                        JoiningDate = Convert.ToDateTime(reader["JoiningDate"])
                    };
                }

                reader.Close();
            }

            return employee;
        }

        /// <summary>
        /// Deletes an employee record from the SQL database.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee object to be deleted.</param>
        //public void DeleteEmployeeFromDatabase(cls_EmployeeProp empDataToBeDelete)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string query = "DELETE FROM Employees WHERE SerialNo = @SerialNo";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@SerialNo", empDataToBeDelete.SerialNo);
        //                int rowsAffected = command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static void DeleteEmployees(List<int> ids)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var id in ids)
                {
                    string query = "DELETE FROM Employees WHERE SerialNo = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        /// <summary>
        /// Updates an employee record in the SQL database.
        /// </summary>
        /// <param name="employee">The updated employee object.</param>
        public static void UpdateEntry(cls_EmployeeProp employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Employees
                                     SET Prefix = @Prefix,
                                         FirstName = @FirstName,
                                         MiddleName = @MiddleName,
                                         LastName = @LastName,
                                         Education = @Education,
                                         JoiningDate = @JoiningDate,
                                         CurrentCompany = @CurrentCompany,
                                         CurrentAddress = @CurrentAddress,
                                         DOB = @DOB
                                     WHERE SerialNo = @SerialNo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SerialNo", employee.SerialNo);
                        command.Parameters.AddWithValue("@Prefix", employee.Prefix);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@Education", employee.Education);
                        command.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                        command.Parameters.AddWithValue("@CurrentCompany", employee.CurrentCompany);
                        command.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
                        command.Parameters.AddWithValue("@DOB", employee.DOB);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided SerialNo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
