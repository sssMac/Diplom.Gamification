﻿using Diplom.Gamification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Gamification.Domain
{
    public class Forum : BaseDomainEntity
    {
        public string UserId { get; set; }
        public Guid CourseId { get; set; }
        public List<Message> Messages { get; set; }
    }
}
