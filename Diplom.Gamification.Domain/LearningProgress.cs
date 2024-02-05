using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class LearningProgress : BaseDomainEntity
    {
        public string UserId { get; set; }
        public Guid LessonId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
