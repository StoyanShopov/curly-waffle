namespace SBC.Services.Data.Resource.Contracts
{
<<<<<<< Updated upstream:Services/SBC.Services.Data/Resource/Contracts/IResourceService.cs
    public interface IResourceService
    {
=======
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Resource;

    public interface IResourceService
    {
        Task<IEnumerable<TModel>> GetAllByLectureIdAsync<TModel>(string id);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateResourceInputModel resourceModel);

        Task<Result> EditAsync(EditResourceServiceModel resourceModel);

        Task<Result> DeleteByIdAsync(string id);
>>>>>>> Stashed changes:Services/SBC.Services.Data/Resource/IResourceService.cs
    }
}
