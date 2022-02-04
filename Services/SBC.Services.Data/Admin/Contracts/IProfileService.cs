namespace SBC.Services.Data.Admin.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Admin.Models;

    public interface IProfileService
    {
        Task<Result> GetDashboard();

        Task<Result> GetCompanies(int page);

        Task<Result> CreateComapany(CompanyServiceModel companyServiceModel);

        Task<Result> UpdateProfile(AdminSerivceModel adminSerivceModel);
    }
}
