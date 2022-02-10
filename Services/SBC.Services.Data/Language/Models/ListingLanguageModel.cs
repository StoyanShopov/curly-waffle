namespace SBC.Services.Data.Language.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ListingLanguageModel
    {
        [Required]
        public string Name { get; set; }
    }
}
