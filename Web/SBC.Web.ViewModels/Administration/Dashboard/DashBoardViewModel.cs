namespace SBC.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    public class DashboardViewModel
    {
        public int Clients { get; set; }

        public int Revenue { get; set; }

        public int Courses { get; set; }

        public int Coaches { get; set; }

        public ICollection<DiagramViewModelPoint<int, string>> NumberOfClients { get; set; }

        public ICollection<DiagramViewModelPoint<int, string>> TotalRevenue { get; set; }
    }
}
