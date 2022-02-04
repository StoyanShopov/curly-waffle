namespace SBC.Services.Data.Course.Contracts
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICourseService
    {
        Task<Result> GetCount();
    }
}
