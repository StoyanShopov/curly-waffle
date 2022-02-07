namespace SBC.Web.ViewModels.Resource
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ResourceViewModel : IMapFrom<Resource>
    {
     
        
        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public FileType FileType { get; set; }

        public string LectureId { get; set; }
    }
}
