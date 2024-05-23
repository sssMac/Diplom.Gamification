using AutoMapper;
using Diplom.Gamification.Application.Common;
using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Domain;

namespace Diplom.Gamification.Application.Services
{
    public class EducationService : BaseService, IEducationService
    {

        public EducationService(IUnitOfWork unitOfWork, IMapper mapper) :
            base(unitOfWork, mapper)
        {
        }

        #region GET BY ID
        public async Task<CourseViewModel> GetCourseById(Guid id, bool includeAll = false)
        {
            return _mapper.Map<CourseViewModel>(await _unitOfWork.CourseRepository.GetByID(id, includeAll
                ? x => x.Lessons
                : null));
        }

        public async Task<LessonViewModel> GetLessonsById(Guid id, bool includeAll = false)
        {
            return _mapper.Map<LessonViewModel>(await _unitOfWork.LessonRepository.GetByID(id, includeAll
                ? x => x.Assignment
                : null));
        }

        public async Task<AssignmentViewModel> GetAssignmentById(Guid id)
        {
            return _mapper.Map<AssignmentViewModel>(await _unitOfWork.AssignmentRepository.GetByID(id));
        }

        #endregion

        #region GET LIST
        public async Task<List<CourseViewModel>> GetCourses(bool includeAll = false, string userId = null)
        {
            var list = await _unitOfWork.CourseRepository.Get(includeProperties: includeAll
                ? x => x.Lessons
                : null);

            var mappedList = _mapper.Map<List<CourseViewModel>>(list);

            if (!string.IsNullOrEmpty(userId))
            {
                var progresses = await _unitOfWork.LearningProgressRepository.Get();

                foreach (var item in mappedList)
                {
                    item.Passed = progresses.Where(i => item.Lessons.Any(x => x.Id == i.LessonId)).Count();
                }
            }

            return mappedList;
        }

        public async Task<List<LessonViewModel>> GetLessons(bool includeAll = false)
        {
            var list = await _unitOfWork.LessonRepository.Get(includeProperties: includeAll
                ? x => x.Assignment
                : null);

            return _mapper.Map<List<LessonViewModel>>(list);
        }

        public async Task<List<AssignmentViewModel>> GetAssignments()
        {
            var list = await _unitOfWork.AssignmentRepository.Get();

            return _mapper.Map<List<AssignmentViewModel>>(list);
        }

        public async Task<List<CourseViewModel>> GetMyCourses(string userId, bool includeAll = false)
        {
            var list = await _unitOfWork.CourseRepository.Get(x => x.CreatedBy == userId, includeProperties: includeAll
                ? x => x.Lessons.Select(y => y.Assignment)
                : null);

            return _mapper.Map<List<CourseViewModel>>(list);
        }

        #endregion

        #region ADD

        public async Task<BaseResponse> AddCourse(AddCourseViewModel model)
        {
            try
            {     
                var entity = _mapper.Map<Course>(model);

                entity.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.CourseRepository.Insert(entity);
                await _unitOfWork.Save();

                return BaseResponse.Succeed(entity.Id);
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

        public async Task<BaseResponse> AddLesson(AddLessonViewModel model)
        {
            try
            {
                var entity = _mapper.Map<Lesson>(model);

                entity.CreatedAt = DateTime.UtcNow;

                await _unitOfWork.LessonRepository.Insert(entity);
                await _unitOfWork.Save();

                return BaseResponse.Succeed(entity.Id);
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

        #endregion

        #region DELETE

        public async Task<BaseResponse> DeleteCourse(Guid id)
        {
            try
            {
                await _unitOfWork.CourseRepository.Delete(id);
                await _unitOfWork.Save();

                return BaseResponse.Succeed();
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

        public async Task<BaseResponse> DeleteLesson(Guid id)
        {
            try
            {
                await _unitOfWork.LessonRepository.Delete(id);
                await _unitOfWork.Save();

                return BaseResponse.Succeed();
            }
            catch (Exception ex)
            {
                return BaseResponse.Failed(ex.Message);
            }
        }

        #endregion
    }
}
