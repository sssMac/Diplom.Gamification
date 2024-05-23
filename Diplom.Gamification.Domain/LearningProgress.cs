using Diplom.Gamification.Domain.Common;
using Diplom.Gamification.Shared;

namespace Diplom.Gamification.Domain
{
    public class LearningProgress : BaseDomainEntity
    {
        public string UserId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletionDate { get; set; }

        public ApplicationUser User { get; set; }
        public Lesson Lesson { get; set; }
    }
}
