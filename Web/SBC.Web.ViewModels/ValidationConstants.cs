namespace SBC.Web.ViewModels
{
    public static class ValidationConstants
    {
        public class ApplicationUser
        {
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }

        public class Coach
        {
            public const int MinLengthName = 2;

            public const int MaxLengthName = 25;

            public const string NameRegex = @"^[A-Z][a-z]+$";

            public const string NameRegexMessage = "The field Description must be a text of letters.";

            public const int MinLengthDescription = 2;

            public const int MaxLengthDescription = 200;

            public const int MinPricePerSession = 0;

            public const int MinCountAdd = 1;

            public const int MinCountUpdate = 0;
        }

        public class Course
        {
            public const int RangeMinValue = 1;
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 2000;
            public const int TitleMinvalue = 1;
            public const int TitleMaxvalue = 100;
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
