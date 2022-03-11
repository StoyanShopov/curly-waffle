namespace SBC.Services.Data.Coaches
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Web.ViewModels.Coaches;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Coaches;

    using static SBC.Common.GlobalConstants;

    public class CoachesService : ICoachesService
    {
        private readonly IDeletableEntityRepository<Coach> coachesRepository;
        private readonly IDeletableEntityRepository<Language> languagesRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly IRepository<CategoryCoach> categoriesCoachRepository;
        private readonly IRepository<LanguageCoach> languagesCoachRepository;

        public CoachesService(
            IDeletableEntityRepository<Coach> coachesRepository,
            IDeletableEntityRepository<Language> languagesRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Company> companiesRepository,
            IRepository<CategoryCoach> categoriesCoachRepository,
            IRepository<LanguageCoach> languagesCoachRepository)
        {
            this.coachesRepository = coachesRepository;
            this.languagesCoachRepository = languagesCoachRepository;
            this.categoriesCoachRepository = categoriesCoachRepository;
            this.languagesRepository = languagesRepository;
            this.categoriesRepository = categoriesRepository;
            this.companiesRepository = companiesRepository;
        }

        public async Task<Result> CreateAsync(CreateCoachInputModel coach)
        {
            if (this.coachesRepository.AllAsNoTracking().Any(x => x.CalendlyUrl == coach.CalendlyUrl && x.IsDeleted == false))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, string.Format(CoachesConstants.CoachAlreadyExists, coach.CalendlyUrl));
            }

            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, LanguagesConstants.LanguageNotExist);
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CategoriesConstants.CategoryDoesNotExist);
            }

            if (coach.Languages.Count == 0 || coach.Categories.Count == 0)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachesConstants.CoachLangAndCategoriesFieldShouldNotBeEmpty);
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

            coachModel.Languages = coach.Languages
                .Select(x => new LanguageCoach { LanguageId = x.LanguageId, CoachId = coachModel.Id })
                .ToHashSet();

            coachModel.Categories = coach.Categories
                .Select(x => new CategoryCoach { CategoryId = x.CategoryId, CoachId = coachModel.Id })
                .ToHashSet();

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

            await this.coachesRepository.AddAsync(coachModel);
            await this.coachesRepository.SaveChangesAsync();

            return new ResultModel(coachModel);
        }

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.coachesRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());

        public async Task<Result> UpdateAsync(UpdateCoachInputModel coach)
        {
            var coachModel = await this.coachesRepository.All()
                .Include(x => x.Languages)
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == coach.Id);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, string.Format(CoachesConstants.CoachDoesNotExist, coachModel.Id));
            }

            if (this.ExistLanguageId(coach.Languages))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, LanguagesConstants.LanguageNotExist);
            }

            if (this.ExistCategoryId(coach.Categories))
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CategoriesConstants.CategoryDoesNotExist);
            }

            if (coach.Languages.Count == 0 || coach.Categories.Count == 0)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachesConstants.CoachLangAndCategoriesFieldShouldNotBeEmpty);
            }

            coachModel.FirstName = coach.FirstName;
            coachModel.LastName = coach.LastName;
            coachModel.Description = coach.Description;
            coachModel.PricePerSession = coach.PricePerSession;
            coachModel.VideoUrl = coach.VideoUrl;
            coachModel.CalendlyUrl = coach.CalendlyUrl;
            coachModel.ImageUrl = coach.ImageUrl;

            coachModel.Languages = coach.Languages.Select(x => new LanguageCoach
            {
                CoachId = coach.Id,
                LanguageId = x.LanguageId,
            })
                .ToHashSet();

            coachModel.Categories = coach.Categories.Select(x => new CategoryCoach
            {
                CategoryId = x.CategoryId,
                CoachId = coach.Id,
            })
                .ToHashSet();

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

            this.coachesRepository.Update(coachModel);
            await this.coachesRepository.SaveChangesAsync();

            return new ResultModel(coachModel);
        }

        public async Task<Result> DeleteAsync(int coachId)
        {
            var coachModel = await this.coachesRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == coachId);

            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, string.Format(CoachesConstants.CoachDoesNotExist, coachModel.Id));
            }

            this.categoriesCoachRepository.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.categoriesCoachRepository.Delete(x));

            this.languagesCoachRepository.All()
                .Where(x => x.CoachId == coachId).ToList()
                .ForEach(x => this.languagesCoachRepository.Delete(x));

            this.coachesRepository.Delete(coachModel);
            await this.coachesRepository.SaveChangesAsync();

            return new ResultModel(coachId);
        }

        public async Task<int> GetCountAsync()
            => await this.coachesRepository
                .AllAsNoTracking()
                .CountAsync();

        private bool ExistLanguageId(ICollection<LanguageCoachViewModel> languages)
        => languages.Any(x => !this.languagesRepository.AllAsNoTracking().Any(y => y.Id == x.LanguageId));

        private bool ExistCategoryId(ICollection<CategoryCoachViewModel> categories)
        => categories.Any(x => !this.categoriesRepository.AllAsNoTracking().Any(y => y.Id == x.CategoryId));
    }


    public async Task<Result> GetAllWithActive(int companyId)
    {
        var filteredCoaches = await this.coachesRepository
            .AllAsNoTracking()
            .Select(coach => new CoachCardViewModel
            {
                Id = coach.Id,
                FullName = $"{coach.FirstName} {coach.LastName}",
                CategoryByDefault = coach.Categories.Count == 0 ? "Common" : coach.Categories.FirstOrDefault().Category.Name,
                PricePerSession = coach.PricePerSession,
                CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                IsActive = coach.ClientCompanies.Any(x => x.CompanyId == companyId),
            })
            .ToListAsync();

        return new ResultModel(filteredCoaches);
    }

    public async Task<int> GetCountAsync()
        => await this.coachesRepository
            .AllAsNoTracking()
            .CountAsync();
}



}

