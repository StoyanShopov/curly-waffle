namespace SBC.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SBC.Services.Blob;

    public class BlobsController : ApiController
    {
        private readonly IBlobService blobService;

        public BlobsController(IBlobService blobService)
        {
            this.blobService = blobService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await this.blobService.GetAllAsync();

            return this.GenericResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            var result = await this.blobService.UploadBlobAsync(file);

            return this.GenericResponse(result);
        }

        [HttpGet("{blobName}")]
        public async Task<ActionResult> DownloadBlobByName(string blobName)
        {
            var result = await this.blobService.DownloadByNameAsync(blobName);

            return this.File(result.Content, result.ContentType);
        }

        [HttpDelete("{blobName}")]
        public async Task<ActionResult> DeleteByName(string blobName)
        {
            var result = await this.blobService.DeleteByNameAsync(blobName);

            return this.GenericResponse(result);
        }
    }
}
