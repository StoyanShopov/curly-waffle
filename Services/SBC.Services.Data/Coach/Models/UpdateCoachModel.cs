namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    using static SBC.Common.GlobalConstants.CoachConstants;

    public class UpdateCoachModel
    {
        public int CoachId { get; set; }

        [Required]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal PricePerSession { get; set; }

        [Required]
        public string CalendlyUrl { get; set; }

        [MinLength(MinCountUpdate)]
        [MaxLength(MaxCountLanguages)]
        public int[] Languages { get; set; }

        [MinLength(MinCountUpdate)]
        public int[] Categories { get; set; }
    }
}
