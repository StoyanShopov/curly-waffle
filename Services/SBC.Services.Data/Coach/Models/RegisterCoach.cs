namespace SBC.Services.Data.Coach.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterCoach
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }


        public decimal PricePerSession { get; set; }

        [Required]
        public string CalendlyUrl { get; set; }

        public int[] Languiges { get; set; }

        public int[] Categories { get; set; }
    }
}
