namespace SBC.Web.ViewModels.Languages
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LanguageViewModel : IMapFrom<LanguageCoach>
    {
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }
    }
}
