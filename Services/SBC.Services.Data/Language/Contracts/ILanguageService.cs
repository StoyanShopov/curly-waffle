namespace SBC.Services.Data.Language.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;

    public interface ILanguageService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();
    }
}
