namespace SBC.Services.Data.Resource.Contracts
{


    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Resource.Models;
    using SBC.Web.ViewModels.Resource;

    public interface IResourceService
    {
        Task<IEnumerable<TModel>> GetAllByLectureIdAsync<TModel>(string id);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateResourceInputModel resourceModel);

        Task<Result> EditAsync(EditResourceInputModel resourceModel);

        Task<Result> DeleteByIdAsync(string id);
 
    }
}