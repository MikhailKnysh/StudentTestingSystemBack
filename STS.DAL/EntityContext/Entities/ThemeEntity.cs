using STS.DAL.EntityContext.Entitieas;
using System;

namespace STS.DAL.EntityContext.Entities
{
    public class ThemeEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SubjectId { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}