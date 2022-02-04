namespace SBC.Services.Data.Coach.Contracts
{
    using System;
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICoachService
    {
        Task<Result> GetCount();
    }
}
