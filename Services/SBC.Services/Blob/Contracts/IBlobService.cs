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
        Task<ICollection<BlobResponseModel>> GetAllBlobsAsync();

        Task<Result> UploadFileBlobAsync(IFormFile file);

        Task<bool> DeleteBlobByNameAsync(string blobName);

        BlobClient DownloadBlobByName(string blobName);
    }
}
