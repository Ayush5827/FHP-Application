using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public enum AboutUsSection
    {
        Overview,
        BusinessActivities,
        OurComprehensiveSoftware,
        OurBusiness
        // Add more sections as needed
    }

    public class StaticResources
    {
        public enum UserRole
        {
            ADMIN,
            DEVELOPER,
            SUPERADMIN,
            GUEST
        }
        //public enum UserTypes
        //{
        //    GUEST,
        //    ADMIN,
        //    SUPERADMIN,
        //    SELF
        //}
        public enum EditMode
        {
            add,
            edit,
            readOnly
        }
        public enum QualificationEnum
        {
            [Description("Pre Tenth")]
            PreTenth,
            [Description("Tenth Grade")]
            TenthGrade,
            [Description("Twelth Grade")]
            TwelfthGrade,
            [Description("Diploma")]
            Diploma,
            [Description("PG Diploma")]
            PGDiploma,
            [Description("B.Tech Mechanical")]
            BTechMechnical,
            [Description("B.Sc")]
            BSc,
            [Description("B.C.A")]
            BCA,
            [Description("BA")]
            BA,
            [Description("B.Tech CSE")]
            BTechCSE,
            [Description("B.Tech Civil")]
            BTechCivil,
            [Description("B.Tech IT")]
            BTechIT,
            [Description("B.E")]
            BE,
            [Description("M.Sc")]
            MSc,
            [Description("M.C.A")]
            MCA
        }

        public enum EmployeeOperationResult
        {
            [Description("Employee added successfully")]
            AddedSuccessfully,

            [Description("Employee deleted successfully")]
            DeletedSuccessfully,

            [Description("Employee updated successfully")]
            UpdatedSuccessfully,

            [Description("Are you Sure you want to delete this employee")]
            areYouSureWantToDelete,

            [Description("Logged in As Super Admin")]
            loggedInSuperAdmin,
            [Description("Logged in As Admin")]
            loggedInAdmin,
            [Description("Logged in As Self")]
            loggedInSelf,
            [Description("Logged in As Guest")]
            loggedInGuest,
            [Description("User not present!")]
            userNotPresent
        }
        public static string GetEnumValueAtIndex<TEnum>(byte index) where TEnum : Enum
        {
            TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }
            return enumValues[index].ToString();
        }
        public static string GetQualificationDescriptionAtIndex(byte index)
        {
            QualificationEnum[] enumValues = (QualificationEnum[])Enum.GetValues(typeof(QualificationEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            QualificationEnum enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                                          .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        public static List<string> GetQualificationDescriptions()
        {
            List<string> descriptions = new List<string>();

            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                string description = GetEnumDescription(qualification);
                descriptions.Add(description);
            }

            return descriptions;
        }
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        public static byte GetEnumIndexFromDescription(string description)
        {
            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                if (GetEnumDescription(qualification) == description)
                {
                    return (byte)qualification;
                }
            }
            return 0;
        }

        
            public enum ValidationMessage
        {
            [Description("First Name Field cannot be Empty")]
            FirstNameEmpty,

            [Description("Current Company Field cannot be Empty")]
            CurrentCompanyEmpty,

            [Description("Qualification Field cannot be Empty")]
            QualificationEmpty,

            [Description("First Name cannot be more than 50 characters")]
            FirstNameTooLong,

            [Description("Last Name cannot be more than 50 characters")]
            LastNameTooLong,

            [Description("Middle Name cannot be more than 25 characters")]
            MiddleNameTooLong,

            [Description("Current Address cannot be more than 500 characters")]
            CurrentAddressTooLong,

            [Description("Current Company cannot be more than 255 characters")]
            CurrentCompanyTooLong,

            [Description("Cannot Delete as the User don't have permissions other than read only")]
            ReadOnlyUserCannotDelete
        }
    

        public static byte GetValidationMessageAsByte(ValidationMessage message)
        {
            return (byte)message;
        }

        public static ValidationMessage GetValidationMessageFromByte(byte byteValue)
        {
            return (ValidationMessage)byteValue;
        }

        public static string GetDescriptionString(ValidationMessage message)
        {
            var enumType = typeof(ValidationMessage);
            var memberInfo = enumType.GetMember(message.ToString());

            if (memberInfo.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memberInfo[0], typeof(DescriptionAttribute));

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return "Unknown Validation Message Description";
        }

        //public enum EmployeeOperationResult
        //{
        //    [Description("Employee added successfully")]
        //    AddedSuccessfully,

        //    [Description("Employee deleted successfully")]
        //    DeletedSuccessfully,

        //    [Description("Employee updated successfully")]
        //    UpdatedSuccessfully
        //}

        public  string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }


        



    }


}

