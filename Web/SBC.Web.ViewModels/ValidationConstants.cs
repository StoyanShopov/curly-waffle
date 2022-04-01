namespace SBC.Web.ViewModels
{
    public static class ValidationConstants
    {
        public class ApplicationUser
        {
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }

        public class Lecture
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 3;
            public const int DescriptionMaxLength = 250;
            public const int DescriptionMinLength = 5;
        }

        public class Resource
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 3;
            public const int SizeMinLength = 1;
            public const int SizeMaxLength = int.MaxValue;
        }
    }
}
