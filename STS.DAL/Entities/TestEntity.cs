using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class TestEntity
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
        public Guid? StudentId { get; set; }

        public virtual UserEntity Student { get; set; }
        public virtual ThemeEntity ThemeEntity { get; set; }
    }
}
