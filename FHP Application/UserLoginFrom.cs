//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static FHP_VO.Employee;
//using FHP_VO;
//using Resources;
//using static Resources.StaticResources;
//using FHP_BL;
//using FHP_DL;
//using System.Data.SqlTypes;

//namespace FHP_Application
//{
//     public partial class UserLoginFrom : Form
//    {
//        Frm_EmpDetails gridview=new Frm_EmpDetails();
//        private AuthenticationManager authManager;

//        public UserLoginFrom()
//        {
//            InitializeComponent();


//            //string directory = AppDomain.CurrentDomain.BaseDirectory;
//            // string filePath = Path.Combine(directory, "UserCredential.txt");

//            //authManager = new AuthenticationManager(filePath);
//        }

//        private void UserId_txtBox_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void lbl_UserID_Click(object sender, EventArgs e)
//        {

//        }

//        private void LoginBtn_Click(object sender, EventArgs e)
//        {
//            string directory = AppDomain.CurrentDomain.BaseDirectory;
//            string filePath = Path.Combine(directory, "UserCredentials.txt");

//            authManager = new AuthenticationManager(filePath);



//            string username = UserId_txtBox.Text;
//            string password = PasswordTxtBox.Text;

//            User authenticatedUser = authManager.Authenticate(username, password);

//            if (authenticatedUser != null)
//            {
//                // Authentication successful

//                // Create an instance of the appropriate main form based on the user's role
//                switch (authenticatedUser.Role)
//                {
//                    case UserRole.admin:
//                        //Frm_EmpDetails adminForm = new Frm_EmpDetails(authenticatedUser);
//                        //adminForm.Show();
//                        Frm_EmpDetails superAdminForm = new Frm_EmpDetails();
//                        superAdminForm.Show();
//                       // superAdminForm.Role.Visible = true;
//                       // superAdminForm.Role.Text = "SuperAdminLogin";
//                        break;

//                    case UserRole.Developer:
//                        Frm_EmpDetails developerForm = new Frm_EmpDetails();
//                         developerForm.Show();
//                        break;
//                    case UserRole.superadmin:
//                       // SuperAdminForm superAdminForm = new SuperAdminForm(authenticatedUser);
//                        //superAdminForm.Show();
//                        break;
//                    case UserRole.guest:
//                        Frm_EmpDetails guestForm = new Frm_EmpDetails();
//                        //guestForm.menu_New.Enabled = false;
//                        //guestForm.menu_Update.Enabled = false;
//                        //guestForm.menu_Delete.Enabled = false;
//                        guestForm.SetButtonAccessibility(UserRole.guest);
//                        //guestForm.SetMenuItemsEnabled(false); // Disable menu items

//                        guestForm.Show();

//                         break;
//                    default:
//                        MessageBox.Show("Unknown role.");
//                        break;
//                }

//                // Hide the login form
//                this.Close();
//            }
//            else
//            {
//                MessageBox.Show("Invalid username or password. Please try again.");
//            }

//        }

//        private void PasswordTxtBox_TextChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}


using FHP_BL;
using FHP_VO;
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
using static FHP_VO.cls_EmployeeProp;
using static Resources.StaticResources;

namespace FHP_Application
{
    /// <summary>
    /// Represents the user login form.
    /// </summary>
    public partial class UserLoginFrom : Form
    {
         private bool isPasswordVisible = false;
        private Image eyeIconOpen = Properties.Resources.minEye1; // Add your eye icon image for visible password
        private Image eyeIconClosed = Properties.Resources.crossEyeIcon2;

        /// <summary>
        /// Represents the current user.
        /// </summary>
        cls_CredentialDataProp currentUser;

        /// <summary>
        /// Object for user validation.
        /// </summary>
        cls_AuthenticationManager validateUser;


        /// <summary>
        /// flg for checking whether user is valid or not
        /// </summary>
        bool userValid;

        /// <summary>
        /// Dictionary containing the current user's permissions, indicating access rights for various operations.
        /// </summary>
        Dictionary<string, bool> currentUserPermissions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Frm_UserLogin"/> class.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <param name="validateUser">The user validation object.</param>
        /// <param name="resource">The resource management object.</param>
        public UserLoginFrom()
        {
            InitializeComponent();
            currentUser = new cls_CredentialDataProp();
            validateUser = new cls_AuthenticationManager();
            PcBox_eyeIcon.Image = eyeIconClosed;



        }

        private void InitializePasswordEyeIcon()
        {
            PictureBox eyeIcon = new PictureBox
            {
                Image = Properties.Resources.minEye1, // Add your eye icon images for open and closed states
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right,
                Padding = new Padding(3),
                Visible = false
            };
            eyeIcon.Click += EyeIcon_Click;

            // Position the eye icon next to the password TextBox
            eyeIcon.Location = new Point(PasswordTxtBox.Right - eyeIcon.Width - 5, PasswordTxtBox.Top + (PasswordTxtBox.Height - eyeIcon.Height) / 2);

            Controls.Add(eyeIcon);
        }

        
        /// <summary>
        /// Handles the Click event of the login button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            currentUser.UserName = UserId_txtBox.Text;
            currentUser.Password = PasswordTxtBox.Text;
           // currentUser.UserRole = UserType_comboBox.SelectedItem.ToString();

            bool isUserPresent = validateUser.isUserPresent(currentUser);

            if (isUserPresent)
            {
                userValid = true;
                currentUserPermissions = validateUser.GetUserPermission(currentUser);

                Frm_EmpDetails mainView = new Frm_EmpDetails(currentUserPermissions, currentUser);
                mainView.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show(currentUser.ErrorMessage, "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                currentUser.ErrorMessage = string.Empty; //making error messageEmpty so that user can reenter credentials
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the user login form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void UserLoginFrom_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!userValid)
            {
                // Prompt the user if they really want to exit
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    userValid = true;
                    Application.Exit();

                }
            }

        }

        private void lbl_UserId_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Password_Click(object sender, EventArgs e)
        {

        }

        private void UserId_txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EyeIcon_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            // Update TextBox PasswordChar property based on visibility
            PasswordTxtBox.PasswordChar = isPasswordVisible ? '\0' : '*';

            // Change eye icon image based on visibility
            PcBox_eyeIcon.Image = isPasswordVisible ? eyeIconOpen : eyeIconClosed;

        }

        private void UserLoginFrom_Load(object sender, EventArgs e)
        {
           



        }

        private void lbl_UserType_Click(object sender, EventArgs e)
        {

        }

        private void UserType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UserType_comboBox.DataSource = Enum.GetValues(typeof(UserTypes));
            

        }

        private void Login_PictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}