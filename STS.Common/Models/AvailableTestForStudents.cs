using System;
using System.Collections.Generic;

namespace STS.Common.Models
{
    public class AvailableTestForStudents
    {
        public List<Guid> Students { get; set; }
        public Guid ThemeId { get; set; }
    }
}