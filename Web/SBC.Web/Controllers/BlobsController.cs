namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using SBC.Services.Blob;

    using static SBC.Common.GlobalConstants.ControllerRouteConstants;

    public class BlobsController : ApiController
    {
        private readonly IBlobService blobService;

        public BlobsController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        [HttpGet(GetAllRoute)]
        public async Task<IActionResult> GetAllBlobsAsync()
        {
            var blobs = await this.blobService.GetAllBlobsAsync();

            return this.Ok(blobs);
        }

        [HttpPost(UploadBlobRoute)]
        public async Task<IActionResult> UploadBlobAsync(IFormFile file)
        {
            await this.blobService.UploadFileBlobAsync(file);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            return this.GenericResponse(await this.blobService.UploadFileBlobAsync(file));
        }

        [HttpGet(DownloadBlobByNameRoute)]
        public async Task<IActionResult> DownloadBlobByNameAsync(string blobName)
        {
            var blob = this.blobService.DownloadBlobByName(blobName);

            if (!await blob.ExistsAsync())
            {
                return this.BadRequest("Blob does not exist!");
            }

            var result = await blob.DownloadAsync();

            return this.File(result.Value.Content, result.Value.ContentType);
        }

        [HttpDelete(DeleteRoute)]
        public async Task<IActionResult> DeleteBlobByNameAsync(string blobName)
        {
            var result = await this.blobService.DeleteBlobByNameAsync(blobName);

            if (!result)
            {
                return this.BadRequest("Couldn't find job with this name!");
            }

            return this.Ok("Blob deleted successfully!");
        }
    }
}
