namespace SBC.Services.Data.Course
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;

    public class CoursesService : ICoursesService
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;

        public CoursesService(IDeletableEntityRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<int> GetCountAsync()
            => await this.courseRepository
                .AllAsNoTracking()
                .CountAsync();
    }
}
