using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class Assignment : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LessonId { get; set; }
        public string? TestResultContent { get; set; }

    }
}
