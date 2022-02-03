namespace SBC.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Request : BaseDeletableModel<string>
    {
        public Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }
    }
}
