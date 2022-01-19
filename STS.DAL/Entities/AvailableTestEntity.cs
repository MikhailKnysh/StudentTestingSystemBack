using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class AvailableTestEntity
    {
        public Guid Id { get; set; }
        public Guid ThemeId { get; set; }
        public Guid StudentId { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual UserEntity Student { get; set; }
        public virtual ThemeEntity ThemeEntity { get; set; }
    }
}
