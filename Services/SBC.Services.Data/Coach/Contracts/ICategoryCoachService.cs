namespace SBC.Services.Data.Coach.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;

    public interface ICategoryCoachService
    {
        List<CategoryCoach> GetAllCategoriesCoach(int coachId);

        void DeleteAllCategoriesCoach(List<CategoryCoach> categoryCoach);
    }
}