using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class Lesson : BaseDomainEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set;}

        public List<Assignment> Assignments { get; set; }
    }
}
