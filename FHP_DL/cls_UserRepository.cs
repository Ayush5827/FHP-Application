using System;
using System.Data.SqlClient;
using FHP_VO;

namespace FHP_DL
{
    public class cls_UserRepository
    {
        /// <summary>
        /// Sets the value of a user in the database.
        /// </summary>
        /// <param name="user">The user information to be inserted into the database.</param>
        public void SetValue(cls_CredentialDataProp user)
        {
            string connectionString = @"Data Source = AYUSH; DataBase = FHP; Trusted_Connection = true; TrustServerCertificate = true";

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string insertQuery = "INSERT INTO users(UserName, Password, UserRole) VALUES (@UserName,@Password,@UserRole)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@UserRole", user.UserRole);

                        cmd.ExecuteNonQuery();
                    }
                    cnn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DL_Excepions("Error while Inserting User!", ex);
            }
        }

        /// <summary>
        /// Reads user data from the database and authenticates the user.
        /// </summary>
        /// <param name="user">The user information to be authenticated.</param>
        /// <returns>True if authentication is successful, otherwise false.</returns>
        public bool ReadUserDataFromDatabase( cls_CredentialDataProp user)
        {
            try
            {
                string connectionString = @"Data Source = AYUSH; DataBase = FHP; Trusted_Connection = true; TrustServerCertificate = true";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UserName, Password, UserRole FROM UserCredentials WHERE UserName=@SerialNo";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@SerialNo", user.UserName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string password = reader["Password"].ToString();
                                string userRole = reader["UserRole"].ToString();

                                if (password == user.Password)
                                {
                                    user.UserRole = userRole;
                                    return true;
                                }
                                else
                                {
                                    user.ErrorMessage = "Credential Not Valid";
                                    return false;
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DL_Excepions("Error while Authenticating User!", ex);
            }
            return false;
        }

     
    }
}
