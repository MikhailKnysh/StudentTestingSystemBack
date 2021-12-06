using System;
using System.Collections.Generic;

namespace STS.Common.Models
{
    public class GroupUsers
    {
        public Guid GroupId { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}