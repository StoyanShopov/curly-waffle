namespace SBC.Services.Data.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using SBC.Common;

    public interface IDasboardService
    {
        Task<Result> GetDashboard();
    }
}
