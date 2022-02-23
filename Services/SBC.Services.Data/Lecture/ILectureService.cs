namespace SBC.Services.Data.Lecture
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Lecture;

    public interface ILectureService
    {
        Task<IEnumerable<TModel>> GetAllByCourseIdAsync<TModel>(int id);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateLectureInputModel lectureMmodel);

        Task<Result> EditAsync(string id, EditLectureInputModel lectureModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
