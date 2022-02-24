namespace SBC.Services.Data.Coach
{
    using System;
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICoachesService
    {
        Task<Result> GetCount();
    }
}
