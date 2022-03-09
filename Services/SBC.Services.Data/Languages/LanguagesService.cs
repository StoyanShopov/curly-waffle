namespace SBC.Services.Data.Languages
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;

    using SBC.Services.Mapping;

    public class LanguagesService : ILanguagesService
    {
        private readonly IDeletableEntityRepository<Language> languageRepository;

        public LanguagesService(IDeletableEntityRepository<Language> data)
        {
            this.languageRepository = data;
        }

        public async Task<Result> GetAllAsync<TModel>()
             => new ResultModel(await this.languageRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync());
    }
}
