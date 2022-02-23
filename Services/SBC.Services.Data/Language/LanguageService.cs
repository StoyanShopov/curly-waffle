namespace SBC.Services.Data.Language
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;

    using SBC.Services.Mapping;

    public class LanguageService : ILanguageService
    {
        private readonly IDeletableEntityRepository<Language> languageRepository;

        public LanguageService(IDeletableEntityRepository<Language> data)
        {
            this.languageRepository = data;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
             => await this.languageRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();
    }
}
