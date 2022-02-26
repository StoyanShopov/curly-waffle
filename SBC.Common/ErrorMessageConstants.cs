namespace SBC.Common
{
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public class ErrorMessageConstants
    {
        #region Client Service

        public const string EmailExists = "There is no user with the given '{0}' and '{1}'.";

        public const string OwnerExists = "The user's company '{0}' has already a owner.";

        public const string AdminDowngrade = "The user is " + AdministratorRoleName + ". Cannot downgrade to " + CompanyOwnerRoleName + " role.";

        public const string AlreadyOwner = "The user is already an " + CompanyOwnerRoleName + ".";

        #endregion

        #region Company Service

        public const string ExistsByName = "The company's name '{0}' already exists.";

        public const string ExistsByEmail = "The company's email '{0}' already exists.";

        #endregion
    }
}
