namespace SBC.Web.ViewModels.BusinessOwner.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class CreateEmployeeInputModel
    {
        [Required(AllowEmptyStrings = true)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
