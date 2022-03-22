﻿namespace SBC.Web.ViewModels.Employees
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class UserCoachSessionViewModel : IMapFrom<UserCoachSession>
    {
        public string CoachFirstName { get; set; }

        public string CoachLastName { get; set; }

        public string CoachImageUrl { get; set; }

        public string CoachCompanyName { get; set; }

        public decimal CoachPricePerSession { get; set; }
    }
}