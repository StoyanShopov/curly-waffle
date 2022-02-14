namespace SBC.Web.Areas.Administration.Models.Client
{
    using System.ComponentModel.DataAnnotations;

    public class AddRequestModel
    {
        [Required(AllowEmptyStrings = true)]
        public string FullName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
