using System;
using System.Collections.Generic;

namespace STS.Common.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}