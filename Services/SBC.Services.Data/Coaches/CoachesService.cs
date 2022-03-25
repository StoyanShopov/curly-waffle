﻿namespace SBC.Services.Data.Coaches
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
    using SBC.Services.Messaging;
    using SBC.Web.ViewModels.Administration.Coaches;
    using SBC.Web.ViewModels.Coaches;
    using SBC.Web.ViewModels.Feedback;

    using static SBC.Common.GlobalConstants;

    public class CoachesService : ICoachesService
    {
        private const int TakeDefaultValue = 3;

        private readonly IDeletableEntityRepository<Coach> coachesRepository;
        private readonly IDeletableEntityRepository<Language> languagesRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly IRepository<CategoryCoach> categoriesCoachRepository;
        private readonly IRepository<LanguageCoach> languagesCoachRepository;
        private readonly IDeletableEntityRepository<UserCoachSession> sessionsRepository;
        private readonly IEmailSender emailSender;

        public CoachesService(
            IDeletableEntityRepository<Coach> coachesRepository,
            IDeletableEntityRepository<Language> languagesRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Company> companiesRepository,
            IRepository<CategoryCoach> categoriesCoachRepository,
            IRepository<LanguageCoach> languagesCoachRepository,
            IDeletableEntityRepository<UserCoachSession> sessionsRepository,
            IEmailSender emailSender)
        {
            this.coachesRepository = coachesRepository;
            this.languagesCoachRepository = languagesCoachRepository;
            this.categoriesCoachRepository = categoriesCoachRepository;
            this.languagesRepository = languagesRepository;
            this.categoriesRepository = categoriesRepository;
            this.companiesRepository = companiesRepository;
            this.sessionsRepository = sessionsRepository;
            this.emailSender = emailSender;
        }

        public async Task<Result> LeftFeedback(ApplicationUser user, FeedbackInputModel feedback)
        {
            var session = await this.sessionsRepository.All().FirstOrDefaultAsync(x => x.UserId == user.Id && x.CoachId == feedback.CoachId);
            session.LeftFeedback = true;
            await this.sessionsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
               from: user.Email,
               fromName: user.LastName + ' ' + user.FirstName,
               to: user.Company.Email,
               subject: $"Feedback from {user.FirstName} {user.LastName} about coach Session",
               htmlContent: $"<div> < h4 > Top Secret Feedback from {user.FirstName} {user.LastName}</h4><p>Message: {feedback.Message}</p></div>");

            return true;
        }

        public async Task<Result> BookCoachAsync(string employeeId, int coachId)
        {
            var session = await this.sessionsRepository.All().FirstOrDefaultAsync(x => x.UserId == employeeId && x.CoachId == coachId);

            if (session != null)
            {
                this.sessionsRepository.HardDelete(session);
            }

            session = new UserCoachSession()
            {
                UserId = employeeId,
                CoachId = coachId,
            };

            await this.sessionsRepository.AddAsync(session);
            await this.sessionsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> GetAlLOfEmployeeAsync(int companyId, string userId)
        {
            try
            {
                var result = await this.coachesRepository
                    .AllAsNoTracking()
                    .Where(c => c.ClientCompanies.Any(x => x.CompanyId == companyId))
                    .Select(coach => new EmployeeCoachCardViewModel
                    {
                        Id = coach.Id,
                        FullName = $"{coach.FirstName} {coach.LastName}",
                        ImageUrl = coach.ImageUrl,
                        CompanyName=coach.Company.Name,
                        CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                        CalendlyId = coach.CalendlyUrl,
                        Feedbacked = coach.Users.Any(x => x.CoachId == coach.Id && x.UserId == userId && !x.LeftFeedback),
                        VideoUrl = coach.VideoUrl,
                        Description = coach.Description,
                    })
                    .ToListAsync();

                return new ResultModel(result);
            }
            catch (System.Exception err)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, err);
            }
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

        public async Task<Result> GetAllWithActiveAsync(int companyId, int skip = default, int take = TakeDefaultValue)
        {
            var coachesCount = await this.coachesRepository
               .AllAsNoTracking()
               .CountAsync();

            var isViewMoreAvailable = (coachesCount - skip - take) > 0;

            var portions = await this.coachesRepository
                .AllAsNoTracking()
                .OrderByDescending(u => u.CreatedOn)
                .Skip(skip)
                .Take(take)
                .Select(coach => new CoachCardViewModel
                {
                    Id = coach.Id,
                    FullName = $"{coach.FirstName} {coach.LastName}",
                    CategoryByDefault = coach.Categories.Count == 0 ? "Common" : coach.Categories.FirstOrDefault().Category.Name,
                    PricePerSession = coach.PricePerSession,
                    ImageUrl = coach.ImageUrl,
                    CompanyLogoUrl = coach.CompanyId != null ? coach.Company.LogoUrl : "Null",
                    IsActive = coach.ClientCompanies.Any(x => x.CompanyId == companyId),
                })
                .ToListAsync();

            var coaches = new CoachesCardViewModel
            {
                Portions = portions,
                ViewMoreAvailable = isViewMoreAvailable,
            };

            return new ResultModel(coaches);
        }

        private bool ExistLanguageId(ICollection<LanguageCoachViewModel> languages)
            => languages.Any(x => !this.languagesRepository.AllAsNoTracking()
            .Any(y => y.Id == x.LanguageId));

        private bool ExistCategoryId(ICollection<CategoryCoachViewModel> categories)
            => categories.Any(x => !this.categoriesRepository.AllAsNoTracking()
            .Any(y => y.Id == x.CategoryId));
    }
}
