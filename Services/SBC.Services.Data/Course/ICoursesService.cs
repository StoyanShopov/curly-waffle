namespace SBC.Services.Data.Course
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ICoursesService
    {
        Task<int> GetCountAsync();
    }
}
