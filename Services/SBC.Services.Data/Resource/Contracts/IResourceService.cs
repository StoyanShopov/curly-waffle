namespace SBC.Services.Data.Resource.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Services.Data.Resource.Models;

    public interface IResourceService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateResourceServiceModel resourceModel);

        Task<Result> EditAsync(EditResourceServiceModel resourceModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
