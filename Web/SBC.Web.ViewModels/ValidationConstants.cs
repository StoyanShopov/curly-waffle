namespace SBC.Web.ViewModels
{
    public static class ValidationConstants
    {
        public class ApplicationUser
        {
            public const int FullnameMinLength = 3;
            public const int FullnameMaxLength = 30;
            public const int ProfileSummaryMaxLength = 100;
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }
    }
}
