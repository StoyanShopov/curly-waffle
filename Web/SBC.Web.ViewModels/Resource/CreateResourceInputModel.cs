namespace SBC.Web.ViewModels.Resource
{
    using SBC.Data.Models;

    public class CreateResourceInputModel
    {
        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public FileType FileType { get; set; }

        public string LectureId { get; set; }


    }
}
