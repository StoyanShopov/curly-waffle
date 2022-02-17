namespace SBC.Web.ViewModels.Language
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ListingLanguageModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
