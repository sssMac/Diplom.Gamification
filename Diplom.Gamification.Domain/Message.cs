using Diplom.Gamification.Domain.Common;
using Diplom.Gamification.Shared;

namespace Diplom.Gamification.Domain
{
    public class Message : BaseDomainEntity
    {
        public string UserId { get; set; }
        public string Content { get; set; }

        public Guid ForumId { get; set; }
        public Forum Forum { get; set; }
        public ApplicationUser User { get; set; }
    }
}
