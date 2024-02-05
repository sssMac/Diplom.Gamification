using AutoMapper;
using Diplom.Gamification.Application.Common;
using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.Services
{
    public class EducationService : BaseService
    {
        public EducationService(IUnitOfWork unitOfWork, IMapper mapper) : 
            base(unitOfWork, mapper)
        {
        }

        #region GET BY ID
        public async Task<Course> GetCourseById(Guid id, bool includeAll = false)
        {
            return await _unitOfWork.CourseRepository.GetByID(id, includeAll 
                ? x => x.Lessons.Select(y => y.Assignments)
                : null);
        }

        public async Task<Lesson> GetLessonsById(Guid id, bool includeAll = false)
        {
            return await _unitOfWork.LessonRepository.GetByID(id, includeAll
                ? x => x.Assignments
                : null);
        }

        public async Task<Assignment> GetAssignmentById(Guid id)
        {
            return await _unitOfWork.AssignmentRepository.GetByID(id);
        }

        #endregion

        #region GET LIST
        public async Task<List<Course>> GetCourses(bool includeAll = false)
        {
            var list = await _unitOfWork.CourseRepository.Get(includeProperties: includeAll
                ? x => x.Lessons.Select(y => y.Assignments)
                : null);

            return _mapper.Map<List<Course>>(list);
        }

        public async Task<List<Lesson>> GetLessons(bool includeAll = false)
        {
            var list = await _unitOfWork.LessonRepository.Get(includeProperties: includeAll
                ? x => x.Assignments
                : null);

            return _mapper.Map<List<Lesson>>(list);
        }

        public async Task<List<Assignment>> GetAssignments()
        {
            var list = await _unitOfWork.AssignmentRepository.Get();

            return _mapper.Map<List<Assignment>>(list);
        }
        #endregion
    }
}
