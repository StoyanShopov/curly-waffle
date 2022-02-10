namespace SBC.Services.Data.Language
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Language.Contracts;

    using SBC.Services.Data.Language.Models;

    public class LanguageService : ILanguageService
    {
        private readonly IDeletableEntityRepository<Language> languageRepository;

        public LanguageService(IDeletableEntityRepository<Language> data)
        {
            this.languageRepository = data;
        }

        public Task<List<ListingLanguageModel>> GetAll()
            => Task.FromResult(this.languageRepository.AllAsNoTracking().Select(x => new ListingLanguageModel { Name = x.Name }).ToList());
    }
}
