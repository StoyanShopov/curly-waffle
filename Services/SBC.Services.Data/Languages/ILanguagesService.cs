namespace SBC.Services.Data.Language
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Data.Models;

    public interface ILanguagesService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();
    }
}
