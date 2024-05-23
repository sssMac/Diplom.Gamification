using Diplom.Gamification.Domain.Common;
using Diplom.Gamification.Shared;

namespace Diplom.Gamification.Domain
{
    public class Forum : BaseDomainEntity
    {
        public string UserId { get; set; }
        public Guid CourseId { get; set; }
        public List<Message> Messages { get; set; }

        public ApplicationUser User { get; set; }
        public Course Course { get; set; }
    }
}
