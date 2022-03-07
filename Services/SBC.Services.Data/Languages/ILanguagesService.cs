namespace SBC.Services.Data.Language
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ILanguagesService
    {
        Task<Result> GetAllAsync<TModel>();
    }
}
