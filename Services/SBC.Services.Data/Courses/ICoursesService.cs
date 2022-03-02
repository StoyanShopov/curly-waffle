namespace SBC.Services.Data.Courses
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICoursesService
    {
        Task<Result> GetAllWithActive(int companyId);

        Task<int> GetCountAsync();
    }
}
