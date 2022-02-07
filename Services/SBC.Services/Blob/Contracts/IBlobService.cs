namespace SBC.Services.Blob
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    using Microsoft.AspNetCore.Http;
    using SBC.Web.ViewModels.Blob;

    public interface IBlobService
    {
        Task<ICollection<BlobResponseModel>> GetAllBlobsAsync();

        Task<string> UploadFileBlobAsync(IFormFile file);

        Task<bool> DeleteBlobByNameAsync(string blobName);

        BlobClient DownloadBlobByName(string blobName);
    }
}
