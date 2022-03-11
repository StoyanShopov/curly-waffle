namespace SBC.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "SBC";

        public const string BlobContainer = "upskillcontainertest";

        public class ControllerRouteConstants
        {
            public const string DeleteRoute = "delete";

            public const string GetAllRoute = "getAll";

            public const string DownloadBlobByNameRoute = "download";

            public const string UploadBlobRoute = "upload";
        }

        public class RolesNamesConstants
        {
            public const string AdministratorRoleName = "Administrator";
            public const string CompanyOwnerRoleName = "Owner";
            public const string CompanyEmployeeRoleName = "Employee";
        }

        public class PasswordConstants
        {
            public const string AdminPassword = "111111";
            public const string CompanyOwnerPassword = "222222";
            public const string EmployeePassword = "333333";
        }

        public class CategoriesNamesConstants
        {
            public const string Marketing = "Marketing";
            public const string Design = "Design";
            public const string Art = "Art";
        }

        public class LanguagesNamesConstants
        {
            public const string English = "English";
            public const string German = "German";
            public const string Spanish = "Spanish";
        }

        public class CompaniesNamesConstants
        {
            public const string MotionCompanyName = "Motion Software";
            public const string SoftUniCompanyName = "Soft Uni";
            public const string SmartITCompanyName = "Smart IT";
        }

        public class EmailsConstants
        {
            public const string MotionCompanyEmail = "motionCompany@test.test";
            public const string SoftUniEmail = "softUni@test.test";
            public const string SmartITEmail = "smartIT@test.test";
        }

        public class LogoUrlConstants
        {
            public const string MotionCompanyUrl = "https://assets.jobs.bg/assets/logo/2021-01-12/b_7728810788af22f934bc7f88690c2ef1.png";
            public const string SoftUniUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Logo_Software_University_%28SoftUni%29_-_blue.png/535px-Logo_Software_University_%28SoftUni%29_-_blue.png";
            public const string SmartITUrl = "https://smartit.bg/images/smartit-logo.svg";
        }

        public class ResourcesConstants
        {
            public const string IntroductionVideoResourceName = "Introduction Video Resource";
            public const string MarketingPDFResourceName = "Marketing PDF Resource";
            public const string DigitalMarketAudioResourceName = "Digital Market Audio Resource";

            public const string IntroductionVideoFileUrl = "C:\\SBC\\Project";
            public const string MarketingPDFFileUrl = "D:\\SBC\\Project";
            public const string DigitalMarketAudioFileUrl = "F:\\SBC\\Project";
        }

        public class LecturesConstants
        {
            public const string PlanningLectureName = "Planning";
            public const string BrandingLectureName = "Branding";
            public const string BusinessModelLectureName = "Business Model";

            public const string PlanningLectureDescription = "Planning Description Text";
            public const string BrandingLectureDescription = "Branding Description Text";
            public const string BusinessModelLectureDescription = "Business Model Description Text";
        }

        public class CoursesConstants
        {
            public const string ManagementTitle = "Management";
            public const string LeadershipTitle = "Leadership";
            public const string DesignTitle = "Design";

            public const string ManagementDescription = "Management Description Text";
            public const string LeadershipDescription = "Leadership Description Text";
            public const string DesignDescription = "Design Description Text";

            public const string ManagementVideoUrl = "https://www.youtube.com/watch?v=Kte7e8IspJw";
            public const string LeadershipVideoUrl = "https://www.youtube.com/watch?v=RDv_s0G91Ik";
            public const string DesignVideoUrl = "https://www.youtube.com/watch?v=NHahAT3oW7Y";
        }

        public class CoachConstants
        {
            public const string CoachFirstNameIvan = "Ivan";
            public const string CoachFirstNameMaria = "Maria";
            public const string CoachFirstNameEmil = "Emil";

            public const string CoachLastNameIvanov = "Ivanov";
            public const string CoachLastNamePetrova = "Petrova";
            public const string CoachLastNameEmilov = "Emilov";

            public const string IvanDescription = "Ivan Ivanov Description Text";
            public const string MariaDescription = "Maria Petrova Description Text";
            public const string EmilDescription = "Emil Emilov Description Text";

            public const string IvanVideoUrl = "https://www.youtube.com/watch?v=4dQoC6hRsjk";
            public const string MariaVideoUrl = "https://www.youtube.com/watch?v=vRiWG1iNikc";
            public const string EmilVideoUrl = "https://www.youtube.com/watch?v=XB3qoXgdA10";

            public const string IvanCalendlyUrl = "https://calendly.com/1";
            public const string MariaCalendlyUrl = "https://calendly.com/2";
            public const string EmilCalendlyUrl = "https://calendly.com/3";
        }

        public class RequestsConstants
        {
            public const string NameIvan = "Ivan";
            public const string NameMaria = "Maria";
            public const string NameEmil = "Emil";

            public const string IvanEmail = "IvanIvanov@test.test";
            public const string MariaEmail = "MariaPetrova@test.test";
            public const string EmilEmail = "EmilEmilov@test.test";

            public const string PhoneNumber1 = "+359 888000111";
            public const string PhoneNumber2 = "+359 888000222";
            public const string PhoneNumber3 = "+359 888000333";
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

        public class ApplicationUserConstants
        {
            public const string FullNameRegex = @" *([A-za-z]{2,}) +([A-za-z]{2,}) *";
            public const string FullNameError = "FullName is invalid. Must contain at least two separate names with letters only.";
        }
    }
}
