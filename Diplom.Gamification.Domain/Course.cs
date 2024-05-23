using Diplom.Gamification.Domain.Common;

namespace Diplom.Gamification.Domain
{
    public class Course : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public string CreatedBy { get; set; }
        public string? ImgLink { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
