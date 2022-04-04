namespace SBC.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "SBC";

        public const string BlobContainer = "upskillcontainertest";

        public class RolesNamesConstants
        {
            public const string AdministratorRoleName = "Administrator";
            public const string CompanyOwnerRoleName = "Owner";
            public const string CompanyEmployeeRoleName = "Employee";
        }

        public class ApplicationUserConstants
        {
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }

        public class ClientConstants
        {
            public const int TakeDefaultValue = 3;
        }

        public class CourseConstants
        {
            public const int CourseDurationInMonths = 3;
        }

        public class BusinessOwnerConstants
        {
            public const string OwnerAreaName = "BusinessOwner";
        }
    }
}
