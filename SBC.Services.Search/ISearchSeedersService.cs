using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBC.Services.Search
{
    public interface ISearchSeedersService
    {
        Task SeedCoursesAsync();
    }
}
