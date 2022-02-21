namespace SBC.Web.ViewModels.Category
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ListingCategoryModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
