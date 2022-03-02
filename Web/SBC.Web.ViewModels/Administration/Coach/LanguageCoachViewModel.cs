using SBC.Data.Models;
using SBC.Services.Mapping;

namespace SBC.Web.ViewModels.Administration.Coach
{
    public class LanguageCoachViewModel : IMapFrom<LanguageCoach>, IMapTo<LanguageCoach>
    {
        public int LanguageId { get; set; }

        public int? CoachId { get; set; }
    }
}
