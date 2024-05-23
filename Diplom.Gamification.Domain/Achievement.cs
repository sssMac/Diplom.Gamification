using Diplom.Gamification.Domain.Common;
using Diplom.Gamification.Shared;

namespace Diplom.Gamification.Domain
{
    public class Achievement : BaseDomainEntity
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateEarned { get; set; }
        public string ImagePath { get; set; }

        public ApplicationUser User { get; set; }
    }
}
