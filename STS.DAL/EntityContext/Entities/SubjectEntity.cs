using STS.DAL.EntityContext.Entities;
using System;
using System.Collections.Generic;
using STS.Common.Constans;

namespace STS.DAL.EntityContext.Entitieas
{
    public class SubjectEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<ThemeEntity> Themes { get; set; }

        public SubjectEntity()
        {
            Themes = new HashSet<ThemeEntity>();
        }
    }
}