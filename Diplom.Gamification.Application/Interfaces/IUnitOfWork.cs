using Diplom.Gamification.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Diplom.Gamification.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Course> CourseRepository { get; }
        public IGenericRepository<Lesson> LessonRepository { get; }
        public IGenericRepository<Assignment> AssignmentRepository { get; }
        public IGenericRepository<Achievement> AchievementRepository { get; }
        public IGenericRepository<LearningProgress> LearningProgressRepository { get; }
        public IGenericRepository<Forum> ForumRepository { get; }
        public IGenericRepository<Message> MessageRepository { get; }

        public Task Save();
        public void Dispose();
    }
}
