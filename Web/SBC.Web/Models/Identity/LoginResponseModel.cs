namespace SBC.Web.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginResponseModel
    {
        [Required]
        public string JWT { get; init; }
    }
}
