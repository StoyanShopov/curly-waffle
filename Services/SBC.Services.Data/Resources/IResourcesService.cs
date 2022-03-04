namespace SBC.Services.Data.Resources
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Resources;

    public interface IResourcesService
    {
        Task<IEnumerable<TModel>> GetAllByLectureIdAsync<TModel>(string id);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateResourceInputModel resourceModel);

        Task<Result> EditAsync(string id, EditResourceInputModel resourceModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
