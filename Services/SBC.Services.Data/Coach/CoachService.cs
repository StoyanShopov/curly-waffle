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
                ImageUrl = coach.ImageUrl,
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

            foreach (var language in this.languageCoachRepo.All().Where(x => x.CoachId == coachId).ToArray())
            {
                this.languageCoachRepo.Delete(language);
            }

            foreach (var category in this.categoryCoachRepo.All().Where(x => x.CoachId == coachId).ToArray())
            {
                this.categoryCoachRepo.Delete(category);
            }

            this.coachRepository.Delete(coachModel);
            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        private async void AddCategories(ICollection<CategoryImportId> categories, int coachId)
        {
            foreach (var category in categories)
            {
                if (!this.ExistCategory(coachId, category.Id))
                {
                    await this.categoryCoachRepo.AddAsync(new CategoryCoach { CoachId = coachId, CategoryId = category.Id });
                }
            }
        }

        private async void AddLanguages(ICollection<LanguageImportId> languages, int coachId)
        {
            foreach (var language in languages)
            {
                if (!this.ExistLanguage(coachId, language.Id))
                {
                    await this.languageCoachRepo.AddAsync(new LanguageCoach { CoachId = coachId, LanguageId = language.Id });
                }
            }
        }

        private bool ExistingCoach(string calendlyUrl)
        => this.coachRepository.AllAsNoTracking().Any(x => x.CalendlyUrl == calendlyUrl && x.IsDeleted == false);

        private bool ExistCategory(int coachId, int categoryId)
        => this.categoryCoachRepo.AllAsNoTracking().Any(x => x.CategoryId == categoryId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguage(int coachId, int languigeId)
        => this.languageCoachRepo.AllAsNoTracking().Any(x => x.LanguageId == languigeId && x.CoachId == coachId && x.IsDeleted == false);
    }
}
