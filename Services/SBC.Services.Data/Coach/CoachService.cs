namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;
    using SBC.Services.Data.Language.Contracts;

    public class CoachService : ICoachService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;
        private readonly ILanguageCoachService languageService;
        private readonly ICategoryCoachService categoryService;

        public CoachService(
            IDeletableEntityRepository<Coach> data,
            ILanguageCoachService languageService,
            ICategoryCoachService categoryService)
        {
            this.coachRepository = data;
            this.languageService = languageService;
            this.categoryService = categoryService;
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

        public Task<List<ListingCoachModel>> GetAll()
        {
            return Task.FromResult(this.coachRepository.AllAsNoTracking().Select(x => new ListingCoachModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PricePerSession = x.PricePerSession,
                Description = x.Description,
                CalendlyUrl = x.CalendlyUrl,
                VideoUrl = x.VideoUrl,
            }).ToList());
        }

        public async Task<Result> UpdateCoach(UpdateCoachModel coach)
        {
            var coachModel = this.coachRepository.All().FirstOrDefault(x => x.Id == coach.CoachId);
            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach not'exist!");
            }

            coachModel.Description = coach.Description;
            coachModel.PricePerSession = coach.PricePerSession;
            coachModel.VideoUrl= coach.VideoUrl;
            coachModel.CalendlyUrl = coach.CalendlyUrl;

            foreach (var languigeId in coach.Languiges)
            {
                if (!this.ExistLanguage(coachModel, languigeId))
                {
                    coachModel.Languages.Add(new LanguageCoach { CoachId = coachModel.Id, LanguageId = languigeId });
                }
            }

            foreach (var categoryId in coach.Categories)
            {
                if (!this.ExistCategory(coachModel, categoryId))
                {
                    coachModel.Categories.Add(new CategoryCoach { CoachId = coachModel.Id, CategoryId = categoryId });
                }
            }

            await this.coachRepository.SaveChangesAsync();
            return true;
        }

        public async Task<Result> DeleteCoach(int coachId)
        {
            var coachModel = this.coachRepository.AllAsNoTracking().Where(x => x.Id == coachId).FirstOrDefault();
            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach not'exist!");
            }

            var languagesCoach = this.languageService.GetAllLanguagesCoach(coachId);
            this.languageService.DeleteAllLanguagesCoach(languagesCoach);

            var categoriesCoach = this.categoryService.GetAllCategoriesCoach(coachId);
            this.categoryService.DeleteAllCategoriesCoach(categoriesCoach);

            this.coachRepository.Delete(coachModel);
            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        private bool ExistingCoach(string firstName, string lastName)
        => this.coachRepository.AllAsNoTracking().Any(x => x.FirstName == firstName && x.LastName == lastName && x.IsDeleted == false);

        private bool ExistCategory(Coach coachModel, int categoryId)
        => coachModel.Categories.Any(x => x.CategoryId == categoryId && x.CoachId == coachModel.Id && x.IsDeleted == false);

        private bool ExistLanguage(Coach coachModel, int languigeId)
        => coachModel.Languages.Any(x => x.LanguageId == languigeId && x.CoachId == coachModel.Id && x.IsDeleted == false);
    }
}
