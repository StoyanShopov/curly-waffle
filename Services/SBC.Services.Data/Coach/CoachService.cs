﻿namespace SBC.Services.Data.Coach
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
            var coachModel = this.coachRepository.AllAsNoTracking().Where(x => x.Id == coachId).FirstOrDefault();
            if (coachModel == null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, CoachBadRequest);
            }

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
        => this.categoryCoachRepo.AllAsNoTracking().Any(x => x.CategoryId == categoryId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguage(int coachId, int languigeId)
        => this.languageCoachRepo.AllAsNoTracking().Any(x => x.LanguageId == languigeId && x.CoachId == coachId && x.IsDeleted == false);

        private bool ExistLanguageId(int[] languages)
        => languages.Any(x => !this.languageRepo.AllAsNoTracking().Any(y => y.Id == x));

        private bool ExistCategoryId(int[] categories)
        => categories.Any(x => !this.categoryRepo.AllAsNoTracking().Any(y => y.Id == x));
    }
}
