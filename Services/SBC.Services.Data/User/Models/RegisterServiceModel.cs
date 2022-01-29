namespace SBC.Services.Data.User.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RegisterServiceModel
    {
        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
