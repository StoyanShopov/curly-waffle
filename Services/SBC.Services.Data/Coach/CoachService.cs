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
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Coach;

    using static SBC.Common.GlobalConstants.RequestsConstants;

    public class CoachService : ICoachService
    {
        private readonly IDeletableEntityRepository<Coach> coachRepository;
        private readonly IDeletableEntityRepository<CategoryCoach> categoriesCoachRepository;
        private readonly IDeletableEntityRepository<LanguageCoach> languagesCoachRepository;
        private readonly IDeletableEntityRepository<Language> languagesRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Company> companiesRepository;

        public CoachService(
            IDeletableEntityRepository<Coach> coachRepository,
            IDeletableEntityRepository<CategoryCoach> categoryCoachRepo,
            IDeletableEntityRepository<LanguageCoach> languageCoachRepo,
            IDeletableEntityRepository<Language> languageRepo,
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<Company> companiesRepository)
        {
            this.coachRepository = coachRepository;
            this.languagesCoachRepository = languageCoachRepo;
            this.categoriesCoachRepository = categoryCoachRepo;
            this.languagesRepository = languageRepo;
            this.categoriesRepository = categoryRepo;
            this.companiesRepository = companiesRepository;
        }

        public async Task<Result> CreateAsync(CreateCoachInputModel coach)
        {
            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, LanguageBadRequest);
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CategoryBadRequest);
            }

            if (this.coachRepository.AllAsNoTracking().Any(x => x.CalendlyUrl == coach.CalendlyUrl && x.IsDeleted == false))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachBadRequest);
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

            if (coach.CompanyEmail != null)
            {
                var company = await this.companiesRepository
                    .AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Email == coach.CompanyEmail);

                if (company != null)
                {
                    coachModel.CompanyId = company.Id;
                }
            }

            await this.coachRepository.AddAsync(coachModel);
            this.AddLanguages(coach.Languages, coachModel);
            this.AddCategories(coach.Categories, coachModel);

            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.coachRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());

        public async Task<Result> UpdateAsync(UpdateCoachInputModel coach)
        {
            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, LanguageBadRequest);
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CategoryBadRequest);
            }

            var coachModel = this.coachRepository.All().FirstOrDefault(x => x.Id == coach.CoachId);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachBadRequest);
            }

            coachModel.FirstName = coach.FirstName;
            coachModel.LastName = coach.LastName;
            coachModel.Description = coach.Description;
            coachModel.PricePerSession = coach.PricePerSession;
            coachModel.VideoUrl = coach.VideoUrl;
            coachModel.CalendlyUrl = coach.CalendlyUrl;
            coachModel.ImageUrl = coach.ImageUrl;

            if (coach.Languages.Length != 0)
            {
                this.AddLanguages(coach.Languages, coachModel);
            }

            if (coach.Categories.Length != 0)
            {
                this.AddCategories(coach.Categories, coachModel);
            }

            this.coachRepository.Update(coachModel);
            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int coachId)
        {
            var coachModel = await this.coachRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == coachId);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachBadRequest);
            }

            this.categoriesCoachRepository.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.categoriesCoachRepository.Delete(x));

            this.languagesCoachRepository.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.languagesCoachRepository.Delete(x));

            this.coachRepository.Delete(coachModel);
            await this.coachRepository.SaveChangesAsync();

            return true;
        }

        private void AddCategories(int[] categories, Coach coach)
        {
            coach.Categories = categories
                             .Where(x => !this.ExistCategory(coach.Id, x))
                             .Select(x => new CategoryCoach { CoachId = coach.Id, CategoryId = x })
                             .ToArray();
        }

        private void AddLanguages(int[] languages, Coach coach)
        {
            coach.Languages = languages
                            .Where(x => !this.ExistLanguage(coach.Id, x))
                            .Select(x => new LanguageCoach { CoachId = coach.Id, LanguageId = x })
                            .ToArray();
        }

        private bool ExistCategory(int coachId, int categoryId)
        => this.categoriesCoachRepository.AllAsNoTracking().Any(x => x.CategoryId == categoryId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguage(int coachId, int languigeId)
        => this.languagesCoachRepository.AllAsNoTracking().Any(x => x.LanguageId == languigeId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguageId(int[] languages)
        => languages.Any(x => !this.languagesRepository.AllAsNoTracking().Any(y => y.Id == x));

        private bool ExistCategoryId(int[] categories)
        => categories.Any(x => !this.categoriesRepository.AllAsNoTracking().Any(y => y.Id == x));
    }
}
