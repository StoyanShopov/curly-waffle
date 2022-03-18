namespace SBC.Services.Search
{
    using System.Threading.Tasks;

    public interface ISearchSeedersService
    {
        Task SeedCoursesAsync();
    }
}
