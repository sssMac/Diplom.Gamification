using Diplom.Gamification.Domain.Common;

namespace Diplom.Gamification.Domain
{
    public class Assignment : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LessonId { get; set; }
        public string? Tests { get; set; }

        public Lesson Lesson { get; set; }

    }
}
