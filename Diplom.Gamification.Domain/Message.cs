using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class Message : BaseDomainEntity
    {
        public string UserId { get; set; }
        public string Content { get; set; }

        public Guid ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
