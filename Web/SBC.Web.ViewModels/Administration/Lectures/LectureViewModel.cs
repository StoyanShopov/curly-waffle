namespace SBC.Web.ViewModels.Administration.Lectures
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LectureViewModel : IMapFrom<Lecture>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
