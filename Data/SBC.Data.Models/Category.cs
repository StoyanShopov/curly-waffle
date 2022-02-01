namespace SBC.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
