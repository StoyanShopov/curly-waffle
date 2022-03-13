namespace SBC.Web.ViewModels.Categories
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CategoryViewModel : IMapFrom<CategoryCoach>
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
