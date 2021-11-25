using STS.DAL.EntityContext.Entities;
using System;
using System.Collections.Generic;

namespace STS.DAL.EntityContext.Entitieas
{
    public class SubjectEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<ThemeEntity> Themes { get; set; }
    }
}