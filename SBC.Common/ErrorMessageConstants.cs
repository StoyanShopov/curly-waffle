namespace SBC.Common
{
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public static class ErrorMessageConstants
    {
        public class Client
        {
            public const string AdminDowngrade = "The user is " + AdministratorRoleName + ". Cannot downgrade to " + CompanyOwnerRoleName + " role.";

            public const string AlreadyOwner = "The user is already an " + CompanyOwnerRoleName + ".";

            public const string EmailExists = "There is no user with the given '{0}' and '{1}'.";

            public const string OwnerExists = "The user's company '{0}' has already a owner.";
        }

        public class Company
        {
            public const string ExistsByName = "The company's name '{0}' already exists.";

            public const string ExistsByEmail = "The company's email '{0}' already exists.";
        }

        public class User
        {
            public const string CompanyExists = "Company '{0}' is not registered.";

            public const string EmailExists = "Email '{0}' is already taken.";

            public const string InvalidPassOrEmail = "Password/Email is invalid!";

            public const string NotExistsUser = "User does not exist.";
        }
    }
}
