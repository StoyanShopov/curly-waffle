

namespace SBC.Web.ViewModels
{
    using SBC.Data.Models;
    using SBC.Services.Mapping;

    public class LectureViewModel : IMapFrom<Lecture>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
