namespace SBC.Web.ViewModels.Administration.Coach
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CategoryCoachViewModel : IMapFrom<CategoryCoach>, IMapTo<CategoryCoach>
    {
        public int CategoryId { get; set; }
    }
}
