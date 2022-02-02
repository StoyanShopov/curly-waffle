namespace SBC.Services.Blob
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    using Microsoft.AspNetCore.Http;

    public interface IBlobService
    {
        Task<IEnumerable<string>> ListBlobsAsync(string containerName);

        Task<bool> UploadFileBlobAsync(IFormFile file, string containerName);

        Task<bool> DeleteBlobByNameAsync(string blobName, string containerName);

        BlobClient DownloadBlobByName(string blobName, string containerName);
    }
}
