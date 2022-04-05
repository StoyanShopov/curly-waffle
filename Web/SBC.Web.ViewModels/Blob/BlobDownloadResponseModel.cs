namespace SBC.Web.ViewModels.Blob
{
    using System.IO;

    public class BlobDownloadResponseModel
    {
        public Stream Content { get; set; }

        public string ContentType { get; set; }
    }
}
