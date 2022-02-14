namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Coach.Contracts;
    using SBC.Services.Data.Coach.Models;
    using SBC.Services.Data.Language.Contracts;
    using SBC.Services.Mapping;

    public class CoachService : ICoachService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;
        private readonly IDeletableEntityRepository<CategoryCoach> categoryCoachRepo;
        private readonly IDeletableEntityRepository<LanguageCoach> languageCoachRepo;

        public CoachService(
            IDeletableEntityRepository<Coach> data,
            IDeletableEntityRepository<CategoryCoach> categoryCoachRepo,
            IDeletableEntityRepository<LanguageCoach> languageCoachRepo)
        {
            this.coachRepository = data;
            this.languageCoachRepo = languageCoachRepo;
            this.categoryCoachRepo = categoryCoachRepo;
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

        public async Task<IEnumerable<TModel>> GetAll<TModel>()
             => await this.coachRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

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

            var languagesCoach = this.GetAllLanguagesCoach(coachId);
            this.DeleteAllLanguagesCoach(languagesCoach);

            var categoriesCoach = this.GetAllCategoriesCoach(coachId);
            this.DeleteAllCategoriesCoach(categoriesCoach);

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

        private void DeleteAllCategoriesCoach(List<CategoryCoach> categoryCoach)
        {
            foreach (var category in categoryCoach)
            {
                this.categoryCoachRepo.Delete(category);
            }
        }

        private List<CategoryCoach> GetAllCategoriesCoach(int coachId)
        => this.categoryCoachRepo.All().Where(x => x.CoachId == coachId).ToList();

        private void DeleteAllLanguagesCoach(List<LanguageCoach> languagesCoach)
        {
            foreach (var languige in languagesCoach)
            {
                this.languageCoachRepo.Delete(languige);
            }
        }

        private List<LanguageCoach> GetAllLanguagesCoach(int coachId)
        => this.languageCoachRepo.All().Where(x => x.CoachId == coachId).ToList();
    }
}
