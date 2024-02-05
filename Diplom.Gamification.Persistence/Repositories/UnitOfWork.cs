using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Domain;

namespace Diplom.Gamification.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private IGenericRepository<Course> _courseRepository;
        private IGenericRepository<Lesson> _lessonRepository;
        private IGenericRepository<Assignment> _assignmentRepository;
        private IGenericRepository<Achievement> _achievementRepository;
        private IGenericRepository<LearningProgress> _learningProgressRepository;
        private IGenericRepository<Forum> _forumRepository;
        private IGenericRepository<Message> _messageRepository;

        public UnitOfWork(ApplicationContext context)
            => _context = context;

        public IGenericRepository<Course> CourseRepository =>
            _courseRepository ??= new GenericRepository<Course>(_context);
        public IGenericRepository<Lesson> LessonRepository =>
            _lessonRepository ??= new GenericRepository<Lesson>(_context);
        public IGenericRepository<Assignment> AssignmentRepository =>
            _assignmentRepository ??= new GenericRepository<Assignment>(_context);
        public IGenericRepository<Achievement> AchievementRepository =>
            _achievementRepository ??= new GenericRepository<Achievement>(_context);
        public IGenericRepository<LearningProgress> LearningProgressRepository =>
            _learningProgressRepository ??= new GenericRepository<LearningProgress>(_context);
        public IGenericRepository<Forum> ForumRepository =>
            _forumRepository ??= new GenericRepository<Forum>(_context);
        public IGenericRepository<Message> MessageRepository =>
            _messageRepository ??= new GenericRepository<Message>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
