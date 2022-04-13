namespace SBC.Common
{
    using static SBC.Common.GlobalConstants.RolesNamesConstants;

    public static class ErrorConstants
    {
        public class BlobMessages
        {
            public const string FileIsNull = "File is null.";

            public const string BlobNotFound = "Blob not found.";
        }

        public class Client
        {
            public const string AdminDowngrade = "The user is " + AdministratorRoleName + ". Cannot downgrade to " + CompanyOwnerRoleName + " role.";

            public const string AlreadyOwner = "The user is already an " + CompanyOwnerRoleName + ".";

            public const string EmailExists = "There is no user with the given '{0}' and '{1}'.";

            public const string OwnerExists = "The user's company '{0}' has already a owner.";
        }

        public class CompanyConstants
        {
            public const string ExistsByName = "The company's name '{0}' already exists.";

            public const string ExistsByEmail = "The company's email '{0}' already exists.";

            public const string NotExistsByFullName = "User with this '{0}' doesn't exist.";

            public const string AlreadyAddedToACompany = "This user is already added to a company.";

            public const string NotExistsByEmail = "User with this '{0}' doesn't exist.";
        }

        public class CoachesConstants
        {
            public const string CoachDoesNotExist = "Coach with id:{0} does not exists!";
            public const string CoachAlreadyExists = "Coach with this Calendly-URL:{0} already exists!";
            public const string CoachLangAndCategoriesFieldShouldNotBeEmpty = "Language and Category field should not be empty!";
        }

        public class LanguagesConstants
        {
            public const string LanguageNotExist = "Language does not exist!";
        }

        public class CategoriesConstants
        {
            public const string CategoryDoesNotExist = "Category does not exist!";
        }

        public class CoursesMessages
        {
            public const string CourseAlreadyExist = "Course already exist!";
            public const string CourseDoesNotExist = "Course doesn't exist!";
            public const string CourseNotFound = "Course not found!";
            public const string CourseIdIsNull = "Id is null!";
        }

        public class LecturesMessages
        {
            public const string LectureAlreadyExist = "Lecture already exist!.";
            public const string LectureDoesNotExist = "Lecture doesn't exist!";
            public const string LectureNotFound = "Lecture not found!";
        }

        public class ResourcesMessages
        {
            public const string ResourceAlreadyExist = "Resource already exist!";
            public const string ResourceDoesNotExist = "Resource doesn't exist!";
            public const string ResourceNotFound = "Resource not found!";
        }

        public class User
        {
            public const string CompanyExists = "Company '{0}' is not registered.";

            public const string EmailExists = "Email '{0}' is already taken.";

            public const string InvalidPassOrEmail = "Password/Email is invalid!";

            public const string NotExistsUser = "User does not exist.";
        }

        public class Employee
        {
            public const string EmployeeCantBeNull = "User cannot be null";
        }
    }
}
