namespace SBC.Web.ViewModels.Languages
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LanguageDetailsViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
