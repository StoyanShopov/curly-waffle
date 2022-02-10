namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Contracts;

    public class LanguageCoachService : ILanguageCoachService
    {
        private readonly IDeletableEntityRepository<LanguageCoach> languageCoachRepository;

        public LanguageCoachService(IDeletableEntityRepository<LanguageCoach> languageCoachRepository)
        {
            this.languageCoachRepository = languageCoachRepository;
        }

        public void DeleteAllLanguagesCoach(List<LanguageCoach> languagesCoach)
        {
            foreach (var languige in languagesCoach)
            {
                this.languageCoachRepository.Delete(languige);
            }
        }

        public List<LanguageCoach> GetAllLanguagesCoach(int coachId)
        => this.languageCoachRepository.All().Where(x => x.CoachId == coachId).ToList();
    }
}
