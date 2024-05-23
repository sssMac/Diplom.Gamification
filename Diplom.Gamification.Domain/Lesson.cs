using Diplom.Gamification.Domain.Common;

namespace Diplom.Gamification.Domain
{
    public class Lesson : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set;}

        public Assignment Assignment { get; set; }
    }
}
