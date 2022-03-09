namespace SBC.Web.ViewModels.Categories
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class CategoryDetailsViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
