namespace SBC.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SBC.Data.Common.Models;

    public class Notification : BaseDeletableModel<int>
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
