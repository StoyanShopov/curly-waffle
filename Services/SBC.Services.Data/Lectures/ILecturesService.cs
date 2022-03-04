namespace SBC.Services.Data.Lectures
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Lectures;

    public interface ILecturesService
    {
        Task<IEnumerable<TModel>> GetAllByCourseIdAsync<TModel>(int skip, int id, int take = 6);

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task<Result> CreateAsync(CreateLectureInputModel lectureMmodel);

        Task<Result> EditAsync(string id, EditLectureInputModel lectureModel);

        Task<Result> DeleteByIdAsync(string id);
    }
}
