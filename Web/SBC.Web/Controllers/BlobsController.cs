namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Blob;

    using static SBC.Common.ControllerRoutesConstants;

    public class BlobsController : ApiController
    {
        private readonly IBlobService blobService;

        public BlobsController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        [HttpGet(GetAllRoute)]
        public async Task<IActionResult> GetAllBlobsAsync(string containerName)
        {
            var blobs = await this.blobService.ListBlobsAsync(containerName);

            return this.Ok(blobs);
        }

        [HttpPost(UploadBlobRoute)]
        public async Task<IActionResult> UploadBlobAsync(IFormFile file, string containerName)
        {
            var result = await this.blobService.UploadFileBlobAsync(file, containerName);

            if (!result)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpGet(DownloadBlobByNameRoute)]
        public async Task<IActionResult> DownloadBlobByNameAsync(string blobName, string containerName)
        {
            var blob = this.blobService.DownloadBlobByName(blobName, containerName);

            if (!await blob.ExistsAsync())
            {
                return this.BadRequest("Blob does not exist!");
            }

            var result = await blob.DownloadAsync();

            return this.File(result.Value.Content, result.Value.ContentType);
        }

        [HttpDelete(DeleteRoute)]
        public async Task<IActionResult> DeleteBlobByNameAsync(string blobName, string containerName)
        {
            var result = await this.blobService.DeleteBlobByNameAsync(blobName, containerName);

            if (!result)
            {
                return this.BadRequest("Couldn't find job with this name!");
            }

            return this.Ok("Blob deleted successfully!");
        }
    }
}
