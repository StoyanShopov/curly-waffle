namespace SBC.Services.Data.Resources
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using SBC.Common;
    using SBC.Data.Common.Repositories;
    using SBC.Data.Models;
    using SBC.Services.Mapping;
    using SBC.Web.ViewModels.Administration.Resources;

    using static SBC.Common.ErrorConstants.ResourcesMessages;

    public class ResourcesService : IResourcesService
    {
        private readonly IDeletableEntityRepository<Resource> resourcesRepository;

        public ResourcesService(IDeletableEntityRepository<Resource> resourcesRepository)
        {
            this.resourcesRepository = resourcesRepository;
        }

        public async Task<Result> CreateAsync(CreateResourceInputModel resourceModel)
        {
            var resource = await this.resourcesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Name == resourceModel.Name);

            if (resource != null)
            {
                return new ErrorModel(
                    HttpStatusCode.BadRequest,
                    ResourceAlreadyExist);
            }

            var newResource = new Resource()
            {
                Name = resourceModel.Name,
                FileUrl = resourceModel.FileUrl,
                Size = resourceModel.Size,
                FileType = (FileType)Enum.Parse(typeof(FileType), resourceModel.FileType),
                LectureId = resourceModel.LectureId,
            };

            await this.resourcesRepository.AddAsync(newResource);
            await this.resourcesRepository.SaveChangesAsync();

            var currentResource = new ResourceViewModel
            {
                Id = newResource.Id,
                Name = newResource.Name,
                FileType = newResource.FileType.ToString(),
                FileUrl = newResource.FileUrl,
                LectureId = newResource.LectureId,
            };

            return new ResultModel(currentResource);
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var resource = await this.resourcesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (resource == null)
            {
                return new ErrorModel(
                    HttpStatusCode.NotFound,
                    ResourceNotFound);
            }

            this.resourcesRepository.Delete(resource);
            await this.resourcesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UpdateAsync(string id, EditResourceInputModel resourceModel)
        {
            var resource = await this.resourcesRepository
                .All()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (resource == null)
            {
                return new ErrorModel(
                    HttpStatusCode.NotFound,
                    ResourceDoesNotExist);
            }

            resource.Name = resourceModel.Name;
            resource.FileUrl = resourceModel.FileUrl == null ? resource.FileUrl : resourceModel.FileUrl;
            resource.Size = resourceModel.Size;
            resource.LectureId = resourceModel.LectureId;
            resource.FileType = (FileType)Enum.Parse(typeof(FileType), resourceModel.FileType);

            await this.resourcesRepository.SaveChangesAsync();

            var currentResource = new ResourceViewModel
            {
                Id = resource.Id,
                Name = resource.Name,
                FileType = resource.FileType.ToString(),
                FileUrl = resource.FileUrl,
                LectureId = resource.LectureId,
            };

            return new ResultModel(currentResource);
        }

        public async Task<Result> GetAllByLectureIdAsync<TModel>(string id)
                  => new ResultModel(await this.resourcesRepository
                      .AllAsNoTracking()
                      .Where(c => c.LectureId == id)
                      .To<TModel>()
                      .ToListAsync());

        public async Task<Result> GetByIdAsync<TModel>(string id)
                => new ResultModel(await this.resourcesRepository
                    .AllAsNoTracking()
                    .Where(c => c.Id == id)
                    .To<TModel>()
                    .FirstOrDefaultAsync());
    }
}
