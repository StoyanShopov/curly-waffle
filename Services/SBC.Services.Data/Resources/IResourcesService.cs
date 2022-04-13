namespace SBC.Services.Data.Resources
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Resources;

    public interface IResourcesService
    {
        Task<Result> CreateAsync(CreateResourceInputModel resourceModel);

        Task<Result> DeleteAsync(string id);

        Task<Result> UpdateAsync(string id, EditResourceInputModel resourceModel);

        Task<Result> GetAllByLectureIdAsync<TModel>(string id);

        Task<Result> GetByIdAsync<TModel>(string id);
    }
}
