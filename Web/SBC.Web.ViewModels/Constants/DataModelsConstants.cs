namespace SBC.Web.ViewModels.Constants
{
    public static class DataModelsConstants
    {
        public class CoachDtoConstants
        {
            public const byte MinLengthName = 2;
            public const byte MaxLengthName = 25;
            public const string NameRegex = @"^[A-Z][a-z]+$";
            public const string NameRegexMessage = "The field Description must be a text of letters.";
            public const byte MinLengthDescription = 10;
            public const byte MaxLengthDescription = 140;
            public const byte MinCountAdd = 1;
            public const byte MinCountUpdate = 0;
        }
    }
}
