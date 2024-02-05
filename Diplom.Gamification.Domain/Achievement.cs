using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class Achievement : BaseDomainEntity
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateEarned { get; set; }
        public string ImagePath { get; set; }
    }
}
