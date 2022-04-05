namespace SBC.Services.Blob
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;

    using Microsoft.AspNetCore.Http;
    using SBC.Common;
    using SBC.Web.ViewModels.Blob;

    using static SBC.Common.ErrorConstants.BlobMessages;
    using static SBC.Common.GlobalConstants;

    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobService;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobService = blobServiceClient;
        }

        public async Task<Result> DeleteByNameAsync(string blobName)
        {
            var containerClient = this.blobService
                .GetBlobContainerClient(BlobContainer);

            var blobClient = containerClient.GetBlobClient(blobName);

            var result = await blobClient.DeleteIfExistsAsync();

            if (!result)
            {
                return new ErrorModel(
                    HttpStatusCode.NotFound,
                    BlobNotFound);
            }

            return new ResultModel(result);
        }

        public async Task<Result> GetAllAsync()
        {
            var containerClient = this.blobService
                .GetBlobContainerClient(BlobContainer);

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

            return new ResultModel(blobs);
        }

        public async Task<Result> UploadBlobAsync(IFormFile file)
        {
            if (file == null)
            {
                return new ErrorModel(
                    HttpStatusCode.BadRequest,
                    FileIsNull);
            }

            var containerClient = this.blobService
                .GetBlobContainerClient(BlobContainer);

            var blobClient = containerClient
                .GetBlobClient(Guid.NewGuid()
                .ToString());

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType,
            };

            await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            return new ResultModel(new { photoUrl = blobClient.Uri.ToString() });
        }

        public async Task<BlobDownloadResponseModel> DownloadByNameAsync(string blobName)
        {
            var container = this.blobService
                .GetBlobContainerClient(BlobContainer);

            var blob = container.GetBlobClient(blobName);

            var blobExists = await blob.ExistsAsync();

            if (!blobExists)
            {
                new ErrorModel(
                    HttpStatusCode.NotFound,
                    BlobNotFound);
            }

            var result = await blob.DownloadAsync();

            var responseModel = new BlobDownloadResponseModel
            {
                Content = result.Value.Content,
                ContentType = result.Value.ContentType,
            };

            return responseModel;
        }
    }
}
