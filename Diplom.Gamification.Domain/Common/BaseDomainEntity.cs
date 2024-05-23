using System.ComponentModel.DataAnnotations;

namespace Diplom.Gamification.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
