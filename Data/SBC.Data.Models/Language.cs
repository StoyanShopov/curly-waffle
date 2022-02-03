namespace SBC.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Language : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
