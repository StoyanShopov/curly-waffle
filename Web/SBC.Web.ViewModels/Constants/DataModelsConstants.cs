namespace SBC.Web.ViewModels.Constants
{
    public static class DataModelsConstants
    {
        public class CoachDtoConstants
        {
            public const int MinLengthName = 2;
            public const int MaxLengthName = 25;
            public const string NameRegex = @"^[A-Z][a-z]+$";
            public const string NameRegexMessage = "The field Description must be a text of letters.";
            public const int MinLengthDescription = 10;
            public const int MaxLengthDescription = 200;
            public const int MinCountAdd = 1;
            public const int MinCountUpdate = 0;
        }
    }
}
