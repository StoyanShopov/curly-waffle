namespace SBC.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ListingCategoryModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
