using SBC.Data.Models;
using SBC.Services.Mapping;

namespace SBC.Web.ViewModels.Administration.Coach
{
    public class LanguageCoachViewModel : IMapFrom<LanguageCoach>
    {
        public int LanguageId { get; set; }
    }
}
