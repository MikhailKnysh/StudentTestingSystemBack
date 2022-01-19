using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class SubjectEntity
    {
        public SubjectEntity()
        {
            Themes = new HashSet<ThemeEntity>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<ThemeEntity> Themes { get; set; }
    }
}
