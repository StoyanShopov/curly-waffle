namespace SBC.Services.Blob
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;

    using Microsoft.AspNetCore.Http;
    using SBC.Common;
    using SBC.Web.ViewModels.Blob;

    public interface IBlobService
    {
        Task<ICollection<BlobResponseModel>> GetAllAsync();

        Task<Result> UploadBlobAsync(IFormFile file);

        Task<bool> DeleteByNameAsync(string blobName);

        BlobClient DownloadByName(string blobName);
    }
}
