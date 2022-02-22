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
        private readonly IDeletableEntityRepository<Language> languageRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CoachService(
            IDeletableEntityRepository<Coach> coachRepository,
            IDeletableEntityRepository<CategoryCoach> categoryCoachRepo,
            IDeletableEntityRepository<LanguageCoach> languageCoachRepo,
            IDeletableEntityRepository<Language> languageRepo,
            IDeletableEntityRepository<Category> categoryRepo)
        {
            this.coachRepository = coachRepository;
            this.languageCoachRepo = languageCoachRepo;
            this.categoryCoachRepo = categoryCoachRepo;
            this.languageRepo = languageRepo;
            this.categoryRepo = categoryRepo;
        }

        public async Task<Result> CreateAsync(RegisterCoach coach)
        {
            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Language  not'exist!");
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Category  not'exist!");
            }

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

            this.AddLanguages(coach.Languages, coachModel);
            //await this.languageCoachRepo.SaveChangesAsync();

            this.AddCategories(coach.Categories, coachModel);
            //await this.categoryCoachRepo.SaveChangesAsync();

            return true;
        }

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.coachRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());

        public async Task<Result> UpdateAsync(UpdateCoachModel coach)
        {
            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Language  not'exist!");
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Category  not'exist!");
            }

            var coachModel = this.coachRepository.All().FirstOrDefault(x => x.Id == coach.CoachId);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach not'exist!");
            }

            coachModel.Description = coach.Description;
            coachModel.PricePerSession = coach.PricePerSession;
            coachModel.VideoUrl = coach.VideoUrl;
            coachModel.CalendlyUrl = coach.CalendlyUrl;

            if (coach.Languages.Count != 0)
            {
                this.AddLanguages(coach.Languages, coachModel);
                //await this.languageCoachRepo.SaveChangesAsync();
            }

            if (coach.Categories.Count != 0)
            {
                this.AddCategories(coach.Categories, coachModel);
                //await this.categoryCoachRepo.SaveChangesAsync();
            }

            this.coachRepository.Update(coachModel);
            await this.coachRepository.SaveChangesAsync();
            return true;
        }

        public async Task<Result> DeleteAsync(int coachId)
        {
            var coachModel = this.coachRepository.AllAsNoTracking().Where(x => x.Id == coachId).FirstOrDefault();
            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Coach not'exist!");
            }

            /*
            foreach (var language in this.languageCoachRepo.All().Where(x => x.CoachId == coachId).ToArray())
            {
                this.languageCoachRepo.Delete(language);
            }

            foreach (var category in this.categoryCoachRepo.All().Where(x => x.CoachId == coachId).ToArray())
            {
                this.categoryCoachRepo.Delete(category);
            }
            */

            this.categoryCoachRepo.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.categoryCoachRepo.Delete(x));

            this.languageCoachRepo.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.languageCoachRepo.Delete(x));

            this.coachRepository.Delete(coachModel);
            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        private void AddCategories(List<int> categories, Coach coach)
        {
            coach.Categories = categories
                .Where(x => !this.ExistCategory(coach.Id, x))
                .Select(x => new CategoryCoach { CoachId = coach.Id, CategoryId = x })
                .ToHashSet();

            /* foreach (var category in categories)
             {
                 if (!this.ExistCategory(coachId, category.CategoryId))
                 {
                     await this.categoryCoachRepo.AddAsync(new CategoryCoach { CoachId = coachId, CategoryId = category.CategoryId });
                 }
             }
            */
        }

        private void AddLanguages(List<int> languages, Coach coach)
        {
            coach.Languages = languages
                            .Where(x => !this.ExistLanguage(coach.Id, x))
                            .Select(x => new LanguageCoach { CoachId = coach.Id, LanguageId = x })
                            .ToHashSet();
            /*
            foreach (var language in languages)
            {
                if (!this.ExistLanguage(coachId, language.LanguageId))
                {
                    await this.languageCoachRepo.AddAsync(new LanguageCoach { CoachId = coachId, LanguageId = language.LanguageId });
                }
            }
            */
        }

        private bool ExistingCoach(string calendlyUrl)
        => this.coachRepository.AllAsNoTracking().Any(x => x.CalendlyUrl == calendlyUrl && x.IsDeleted == false);

        private bool ExistCategory(int coachId, int categoryId)
        => this.categoryCoachRepo.AllAsNoTracking().Any(x => x.CategoryId == categoryId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguage(int coachId, int languigeId)
        => this.languageCoachRepo.AllAsNoTracking().Any(x => x.LanguageId == languigeId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguageId(List<int> languages)
        => languages.Any(x => !this.languageRepo.AllAsNoTracking().Any(y => y.Id == x));

        private bool ExistCategoryId(List<int> categories)
        => categories.Any(x => !this.categoryRepo.AllAsNoTracking().Any(y => y.Id == x));
    }
}
