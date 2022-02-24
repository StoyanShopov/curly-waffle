using SBC.Data.Models;
using SBC.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBC.Web.ViewModels.Administration.Coach
{
    public class CategoryCoachViewModel : IMapFrom<CategoryCoach>
    {
        public int CategoryId { get; set; }
    }
}
