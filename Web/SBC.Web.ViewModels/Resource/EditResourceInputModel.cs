namespace SBC.Services.Data.Resource.Models
{
    using SBC.Data.Models;

    public class EditResourceInputModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public FileType FileType { get; set; }

        public string LectureId { get; set; }
    }
}
