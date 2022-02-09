

namespace SBC.Services.Data.Coach
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;


    public class CoachService : ICoachService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;
        //TODO

        public CoachService(IDeletableEntityRepository<Coach> data)
        {
            this.coachRepository = data;
        }

        public async Task<Result> NewRegistrationCoach(RegisterCoach coach)
        {
            if (this.ExistingCoach(coach.FirstName, coach.LastName))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach already exist!");
            }

            var coachModel = new Coach
            {
                FirstName = coach.FirstName,
                LastName = coach.LastName,
                Description = coach.Description,
                VideoUrl = coach.VideoUrl,
                PricePerSession = coach.PricePerSession,
                CalendlyUrl = coach.CalendlyUrl,
            };

            await this.coachRepository.AddAsync(coachModel);
            await this.coachRepository.SaveChangesAsync();

            foreach (var languigeId in coach.Languiges)
            {
                coachModel.Languages.Add(new LanguageCoach { CoachId = coachModel.Id, LanguageId = languigeId });
            }

            foreach (var categoryId in coach.Categories)
            {
                coachModel.Categories.Add(new CategoryCoach { CoachId = coachModel.Id, CategoryId = categoryId });
            }

            await this.coachRepository.SaveChangesAsync();
            return true;
        }

        public Task<string> NewRegistrationCoach(RegisterCoach coach, int languageId, int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> Get(LoginCoach coach)
        {
            throw new System.NotImplementedException();
        }

        private bool ExistingCoach(string firstName, string lastName)
       => this.coachRepository.AllAsNoTracking().Any(x => x.FirstName == firstName && x.LastName == lastName);
    }
}
