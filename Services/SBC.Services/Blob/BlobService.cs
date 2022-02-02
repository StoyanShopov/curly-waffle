namespace SBC.Services.Blob
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Microsoft.AspNetCore.Http;

    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobService;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobService = blobServiceClient;
        }

        public async Task<IEnumerable<string>> ListBlobsAsync(string containerName)
        {
            var containerClient = this.blobService.GetBlobContainerClient(containerName);
            var blobs = new List<string>();

            await foreach (var blob in containerClient.GetBlobsAsync())
            {
                blobs.Add(blob.Name);
            }

            return blobs;
        }

        public async Task<bool> UploadFileBlobAsync(IFormFile file, string containerName)
        {
            var containerClient = this.blobService.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(file.Name + Guid.NewGuid().ToString());
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType,
            };

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            return result != null;
        }

        public BlobClient DownloadBlobByName(string blobName, string containerName)
        {
            var container = this.blobService.GetBlobContainerClient(containerName);

            return container.GetBlobClient(blobName);
        }

        public async Task<bool> DeleteBlobByNameAsync(string blobName, string containerName)
        {
            var containerClient = this.blobService.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
