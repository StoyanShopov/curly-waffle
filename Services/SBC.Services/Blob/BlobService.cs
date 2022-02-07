namespace SBC.Services.Blob
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Microsoft.AspNetCore.Http;
    using SBC.Web.ViewModels.Blob;

    using static SBC.Common.GlobalConstants;

    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobService;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobService = blobServiceClient;
        }

        public async Task<ICollection<BlobResponseModel>> GetAllBlobsAsync()
        {
            var containerClient = this.blobService.GetBlobContainerClient(BlobContainer);
            var blobs = new List<BlobResponseModel>();

            await foreach (var blob in containerClient.GetBlobsAsync())
            {
                var name = blob.Name;

                var uri = containerClient.Uri.AbsoluteUri;

                var fullUri = uri + "/" + name;

                blobs.Add(new BlobResponseModel
                {
                    Name = name,
                    ContentType = blob.Properties.ContentType,
                    Uri = fullUri,
                });
            }

            return blobs;
        }

        public async Task<string> UploadFileBlobAsync(IFormFile file)
        {
            var containerClient = this.blobService.GetBlobContainerClient(BlobContainer);

            var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType,
            };

            await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            return blobClient.Uri.ToString();
        }

        public BlobClient DownloadBlobByName(string blobName)
        {
            var container = this.blobService.GetBlobContainerClient(BlobContainer);

            return container.GetBlobClient(blobName);
        }

        public async Task<bool> DeleteBlobByNameAsync(string blobName)
        {
            var containerClient = this.blobService.GetBlobContainerClient(BlobContainer);

            var blobClient = containerClient.GetBlobClient(blobName);

            return await blobClient.DeleteIfExistsAsync();
        }
    }
}
