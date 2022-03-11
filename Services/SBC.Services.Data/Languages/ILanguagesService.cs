namespace SBC.Services.Data.Languages
{
    using System.Threading.Tasks;

    using SBC.Common;

    public interface ILanguagesService
    {
        Task<Result> GetAllAsync<TModel>();
    }
}
