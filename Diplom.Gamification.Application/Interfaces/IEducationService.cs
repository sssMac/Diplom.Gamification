using Diplom.Gamification.Application.Common;
using Diplom.Gamification.Application.ViewModels;

namespace Diplom.Gamification.Application.Interfaces
{
    public interface IEducationService
    {
        Task<BaseResponse> AddCourse(AddCourseViewModel model);
        Task<BaseResponse> AddLesson(AddLessonViewModel model);
        Task<BaseResponse> DeleteCourse(Guid id);
        Task<BaseResponse> DeleteLesson(Guid id);
        Task<AssignmentViewModel> GetAssignmentById(Guid id);
        Task<List<AssignmentViewModel>> GetAssignments();
        Task<CourseViewModel> GetCourseById(Guid id, bool includeAll = false);
        Task<List<CourseViewModel>> GetCourses(bool includeAll = false, string userId = null);
        Task<List<LessonViewModel>> GetLessons(bool includeAll = false);
        Task<LessonViewModel> GetLessonsById(Guid id, bool includeAll = false);
        Task<List<CourseViewModel>> GetMyCourses(string userId, bool includeAll = false);
    }
}