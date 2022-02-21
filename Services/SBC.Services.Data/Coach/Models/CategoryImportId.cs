namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryImportId
    {
        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
