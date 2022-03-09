namespace SBC.Web.Controllers
{
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Common;
    using SBC.Services.Blob;

    public class BlobsController : ApiController
    {
        private readonly IBlobService blobService;

        public BlobsController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blobs = await this.blobService.GetAllAsync();

            return this.Ok(blobs);
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlobAsync(IFormFile file)
        {
            if (file == null)
            {
                return this.GenericResponse(new ErrorModel(HttpStatusCode.NotFound, "file is empty"));
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            return this.GenericResponse(await this.blobService.UploadBlobAsync(file));
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> DownloadBlobByNameAsync(string blobName)
        {
            var blob = this.blobService.DownloadByName(blobName);

            if (!await blob.ExistsAsync())
            {
                return this.BadRequest("Blob does not exist!");
            }

            var result = await blob.DownloadAsync();

            return this.File(result.Value.Content, result.Value.ContentType);
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteByNameAsync(string blobName)
        {
            var result = await this.blobService.DeleteByNameAsync(blobName);

            if (!result)
            {
                return this.BadRequest("Couldn't find job with this name!");
            }

            return this.GenericResponse(result);
        }
    }
}
