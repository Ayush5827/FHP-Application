using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resources.StaticResources;
 namespace FHP_VO
{

    //public class user
    //{
    //    public string username { get; set; }
    //    public string password { get; set; }
    //    public int Role { get; set; }
    //    //StaticResources UserRole;
    //}
    public class cls_EmployeeProp
    {
        public long SerialNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Prefix { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentCompany { get; set; }
        public byte editMode { get; set; }
        public bool isDeleted { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DOB { get; set; }
        public byte Education { get; set; }

        public byte ValidationMessage { get; set; }
        public cls_EmployeeProp()
        {
            isDeleted = false;
            editMode = 1;

        }
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public UserRole Role { get; set; }
        }




    }
}
