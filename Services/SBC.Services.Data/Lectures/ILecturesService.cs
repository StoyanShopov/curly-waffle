namespace SBC.Services.Data.Lectures
{
    using System.Threading.Tasks;

    using SBC.Common;
    using SBC.Web.ViewModels.Administration.Lectures;

    public interface ILecturesService
    {
        Task<Result> CreateAsync(CreateLectureInputModel lectureMmodel);

        Task<Result> DeleteAsync(string id);

        Task<Result> GetAllByCourseIdAsync<TModel>(int skip, int id, int take = 6);

        Task<Result> GetByIdAsync<TModel>(string id);

        Task<Result> UpdateAsync(string id, EditLectureInputModel lectureModel);
    }
}
