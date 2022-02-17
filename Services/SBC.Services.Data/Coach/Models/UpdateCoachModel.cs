namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCoachModel
    {
        public int CoachId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }


        public decimal PricePerSession { get; set; }

        [Required]
        public string CalendlyUrl { get; set; }

        public int[] Languages { get; set; }

        public int[] Categories { get; set; }
    }
}
