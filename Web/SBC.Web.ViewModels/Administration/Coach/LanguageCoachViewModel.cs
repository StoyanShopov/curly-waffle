using SBC.Data.Models;
using SBC.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBC.Web.ViewModels.Administration.Coach
{
    public class LanguageCoachViewModel : IMapFrom<LanguageCoach>
    {
        public int LanguageId { get; set; }

    }
}
