namespace SBC.Web.ViewModels.Administration.Coaches
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LanguageCoachViewModel : IMapFrom<LanguageCoach>
    {
        public int LanguageId { get; set; }
    }
}
