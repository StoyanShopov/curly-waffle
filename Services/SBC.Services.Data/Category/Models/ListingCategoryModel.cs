namespace SBC.Services.Data.Category.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ListingCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}
