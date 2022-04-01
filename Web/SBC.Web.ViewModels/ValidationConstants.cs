namespace SBC.Web.ViewModels
{
    public static class ValidationConstants
    {
        public class ApplicationUser
        {
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }

        public class course
        {
            public const int RangeMinValue = 1;
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 2000;
            public const int TitleMinvalue = 1;
            public const int TitleMaxvalue = 100;

        }
    }
}
