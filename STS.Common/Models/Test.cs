using System;
using System.Collections.Generic;
using Common.Models;

namespace STS.Common.Models
{
    public class Test
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ThemeId { get; set; }
        public long DateTimeStart { get; set; }
        public long DateTimeFinish { get; set; }
        public int Mark { get; set; }
        public int TimePreparation { get; set; }
        public int CountOfHelpChecks { get; set; }
        public bool IsDone { get; set; }
        public User Student { get; set; }
        public Theme Theme { get; set; }
        public ICollection<StudentAnswer> Answers { get; set; }
    }
}