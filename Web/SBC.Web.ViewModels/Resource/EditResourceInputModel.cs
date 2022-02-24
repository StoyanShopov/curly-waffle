namespace SBC.Services.Data.Resource.Models
{
    public class EditResourceInputModel
    {
        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public string FileType { get; set; }

        public string LectureId { get; set; }
    }
}
