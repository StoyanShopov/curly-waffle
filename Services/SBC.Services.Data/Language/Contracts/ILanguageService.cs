namespace SBC.Services.Data.Language.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;
    using SBC.Services.Data.Language.Models;

    public interface ILanguageService
    {
        Task<List<ListingLanguageModel>> GetAll();
    }
}
