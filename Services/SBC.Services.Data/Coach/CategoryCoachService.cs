namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Contracts;

    public class CategoryCoachService : ICategoryCoachService
    {
        private readonly IDeletableEntityRepository<CategoryCoach> categoryCoachRepository;

        public CategoryCoachService(IDeletableEntityRepository<CategoryCoach> categoryCoachRepository)
        {
            this.categoryCoachRepository = categoryCoachRepository;
        }

        public void DeleteAllCategoriesCoach(List<CategoryCoach> categoryCoach)
        {
            foreach (var category in categoryCoach)
            {
                this.categoryCoachRepository.Delete(category);
            }
        }

        public List<CategoryCoach> GetAllCategoriesCoach(int coachId)
        => this.categoryCoachRepository.All().Where(x => x.CoachId == coachId).ToList();
    }
}
