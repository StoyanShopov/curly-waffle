namespace SBC.Services.Data.Resource
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Data.Resource.Contracts;
    using SBC.Services.Data.Resource.Models;
    using SBC.Services.Mapping;

    public class ResourceService : IResourceService
    {
        private readonly IDeletableEntityRepository<Resource> resources;

        public ResourceService(IDeletableEntityRepository<Resource> resources)
    public async Task<Result> CreateAsync(CreateResourceInputModel resourceModel)
    {
        var resource = await this.resources
            .All()
            .FirstOrDefaultAsync(c => c.Name == resourceModel.Name);

        if (resource != null)
        {
            this.resources = resources;
        }

        public async Task<Result> CreateAsync(CreateResourceServiceModel resourceModel)
        {
            var resource = await this.resources
                .All()
                .FirstOrDefaultAsync(c => c.Name == resourceModel.Name);

            if (resource != null)
            {
                return new ErrorModel(HttpStatusCode.BadRequest, "Resource already exist!");
            }

            var newResource = new Resource()
            {
                Name = resourceModel.Name,
                FileUrl = resourceModel.FileUrl,
                Size = resourceModel.Size,
                FileType = resourceModel.FileType,
                LectureId = resourceModel.LectureId,
            };

            await this.resources.AddAsync(newResource);
            await this.resources.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteByIdAsync(string id)
        {
            var resource = await this.resources
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (resource == null)
            {
                return new ErrorModel(HttpStatusCode.NotFound, "Resource not found!");
            }

            this.resources.Delete(resource);
            await this.resources.SaveChangesAsync();

            return true;
        }

        public async Task<Result> EditAsync(EditResourceServiceModel resourceModel)
        {
            var resource = await this.resources
                .All()
                .FirstOrDefaultAsync(c => c.Id == resourceModel.Id);

            if (resource == null)
            {
                return new ErrorModel(HttpStatusCode.NotFound, "Resource doesn't exist!");
            }

            resource.Name = resourceModel.Name;
            resource.FileUrl = resourceModel.FileUrl;
            resource.Size = resourceModel.Size;
            resource.FileType = resourceModel.FileType;
            resource.LectureId = resourceModel.LectureId;

            await this.resources.SaveChangesAsync();
    public async Task<Result> EditAsync(EditResourceInputModel resourceModel)
    {
        var resource = await this.resources
            .All()
            .FirstOrDefaultAsync(c => c.Id == resourceModel.Id);

            return true;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            => await this.resources
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

        public async Task<TModel> GetByIdAsync<TModel>(string id)
            => await this.resources
                .AllAsNoTracking()
                .Where(c => c.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TModel>> GetAllByLectureIdAsync<TModel>(string id)
              => await this.resources
                  .AllAsNoTracking()
                   .Where(c => c.LectureId == id)
                  .To<TModel>()
                  .ToListAsync();

    public async Task<TModel> GetByIdAsync<TModel>(string id)
            => await this.resources
                .AllAsNoTracking()
                .Where(c => c.Id == id)
                .To<TModel>()
                .FirstOrDefaultAsync();
    }
}
