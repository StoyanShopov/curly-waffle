using System.ComponentModel.DataAnnotations;

namespace SBC.Web.Models.Identity
{
    public class LoginResponseModel
    {
        [Required]
        public string JWT { get; init; }
    }
}
