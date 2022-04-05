namespace SBC.Services.Blob
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using SBC.Common;
    using SBC.Web.ViewModels.Blob;

    public interface IBlobService
    {
        Task<Result> DeleteByNameAsync(string blobName);

        Task<Result> GetAllAsync();

        Task<Result> UploadBlobAsync(IFormFile file);

        Task<BlobDownloadResponseModel> DownloadByNameAsync(string blobName);
    }
}
