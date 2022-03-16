namespace SBC.Web.ViewModels.Administration.Resources
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class ResourceViewModel : IMapFrom<Resource>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string FileUrl { get; set; }

        public int Size { get; set; }

        public string FileType { get; set; }

        public string LectureId { get; set; }
    }
}
