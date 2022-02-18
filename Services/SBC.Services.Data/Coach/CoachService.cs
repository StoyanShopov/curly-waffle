namespace SBC.Services.Data.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
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

        public async Task<Result> CreateAsync(RegisterCoach coach)
        {
            if (this.ExistingCoach(coach.CalendlyUrl))
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

            this.AddLanguages(coach.Languages, coachModel.Id);
            await this.languageCoachRepo.SaveChangesAsync();

            this.AddCategories(coach.Categories, coachModel.Id);
            await this.categoryCoachRepo.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
             => await this.coachRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<Result> UpdateAsync(UpdateCoachModel coach)
        {
            var coachModel = this.coachRepository.All().FirstOrDefault(x => x.Id == coach.CoachId);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach not'exist!");
            }

            await this.coachRepository.SaveChangesAsync();
            if (coach.Languages.Length != 0)
            {
                this.AddLanguages(coach.Languages, coachModel.Id);
                await this.languageCoachRepo.SaveChangesAsync();
            }

            if (coach.Categories.Length != 0)
            {
                this.AddCategories(coach.Categories, coachModel.Id);
                await this.categoryCoachRepo.SaveChangesAsync();
            }

            return true;
        }

        public async Task<Result> DeleteAsync(int coachId)
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

        private async void AddCategories(int[] categories, int coachId)
        {
            foreach (var categoryId in categories)
            {
                if (!this.ExistCategory(coachId, categoryId))
                {
                    await this.categoryCoachRepo.AddAsync(new CategoryCoach { CoachId = coachId, CategoryId = categoryId });
                }
            }
        }

        private async void AddLanguages(int[] languages, int coachId)
        {
            foreach (var languageId in languages)
            {
                if (!this.ExistLanguage(coachId, languageId))
                {
                    await this.languageCoachRepo.AddAsync(new LanguageCoach { CoachId = coachId, LanguageId = languageId });
                }
            }
        }

        private bool ExistingCoach(string calendlyUrl)
        => this.coachRepository.AllAsNoTracking().Any(x => x.CalendlyUrl == calendlyUrl && x.IsDeleted == false);

        private bool ExistCategory(int coachId, int categoryId)
        => this.categoryCoachRepo.AllAsNoTracking().Any(x => x.CategoryId == categoryId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguage(int coachId, int languigeId)
        => this.languageCoachRepo.AllAsNoTracking().Any(x => x.LanguageId == languigeId && x.CoachId == coachId && x.IsDeleted == false);

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
            foreach (var language in languagesCoach)
            {
                this.languageCoachRepo.Delete(language);
            }
        }

        private void DeleteAllLanguagesCoach2(List<LanguageCoach> languagesCoach)
        {
            foreach (var language in languagesCoach)
            {
                this.languageCoachRepo.Delete(language);
            }
        }

        private List<LanguageCoach> GetAllLanguagesCoach(int coachId)
        => this.languageCoachRepo.All().Where(x => x.CoachId == coachId).ToList();
    }
}
