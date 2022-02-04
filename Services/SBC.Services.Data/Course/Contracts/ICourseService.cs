namespace SBC.Services.Data.Course.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Course.Models;

    public interface ICourseService
    {
        Task<Result> GetAllAsync();

        Task<Result> GetByIdAsync(int id);

        Task<Result> CreateAsync(CreateCourseServiceModel courseModel);

        Task<Result> EditAsync(EditCourseServiceModel courseModel);

        Task<Result> DeleteByIdAsync(int id);
    }
}
