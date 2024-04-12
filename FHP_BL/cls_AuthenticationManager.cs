using FHP_DL;
using FHP_VO;
using System.Collections.Generic;

namespace FHP_BL
{
    /// <summary>
    /// Handles the validation and role assignment for user-related operations.
    /// </summary>
    public class cls_AuthenticationManager
    {
        /// <summary>
        /// Object for reading user data.
        /// </summary>
        cls_UserRepository userData;

        /// <summary>
        /// Initializes a new instance of the <see cref="cls_AuthenticationManager"/> class.
        /// </summary>
        public cls_AuthenticationManager()
        {
            userData = new cls_UserRepository();
        }

        /// <summary>
        /// Sets the user role based on provided user credentials and retrieves user permissions.
        /// </summary>
        /// <param name="user">The user data to be validated.</param>
        /// <returns>True if the user is present and valid, false otherwise.</returns>
        private bool SetUserRole(cls_CredentialDataProp user)
        {
            bool isUserValid = false;
            try
            {
                // Check if the user exists and retrieve user data from the database
                isUserValid = userData.ReadUserDataFromDatabase(user);
            }
            catch
            {
                // Handle any exceptions
            }

            if (!isUserValid)
            {
                return false;
            }
            // Retrieve user permissions based on the user's role
            GetUserPermission(user);
            return true;
        }

        /// <summary>
        /// Validates if the user is present and sets the user role.
        /// </summary>
        /// <param name="user">The user data to be validated.</param>
        /// <returns>True if the user is present and valid, false otherwise.</returns>
        public bool isUserPresent(cls_CredentialDataProp user)
        {
            return SetUserRole(user);
        }

        /// <summary>
        /// Retrieves the user permissions based on the user's role.
        /// </summary>
        /// <param name="user">The user data for which permissions are retrieved.</param>
        /// <returns>A dictionary containing permission flags for various operations.</returns>
        public Dictionary<string, bool> GetUserPermission(cls_CredentialDataProp user)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();

            permissions.Add("CanDownGrade", false);
            permissions.Add("CanEdit", false);
            permissions.Add("CanDelete", false);
            permissions.Add("CanRead", false);
            permissions.Add("CanAddEmp", false);
            permissions.Add("CanCreateUsers", false);

            // Set permissions based on the user's role
            switch (user.UserRole)
            {
                case "SUPERADMIN":
                    permissions["CanDownGrade"] = true;
                    permissions["CanEdit"] = true;
                    permissions["CanDelete"] = true;
                    permissions["CanRead"] = true;
                    permissions["CanAddEmp"] = true;
                    permissions["CanCreateUsers"] = true;
                    break;
                case "ADMIN":
                    permissions["CanDownGrade"] = true;
                    permissions["CanEdit"] = true;
                    permissions["CanDelete"] = true;
                    permissions["CanRead"] = true;
                    permissions["CanAddEmp"] = true;
                    break;
                case "GUEST":
                    permissions["CanRead"] = true;
                    break;
                case "DEVELOPER":
                    permissions["CanEdit"] = true;
                    permissions["CanDelete"] = true;
                    permissions["CanRead"] = true;
                    permissions["CanAddEmp"] = true;
                    break;
                    // Add more cases for other roles if needed
            }

            return permissions;
        }
    }
}
