using STS.DAL.EntityContext.Entitieas;
using System;
using System.Collections.Generic;

namespace STS.DAL.EntityContext.Entities
{
    public class ThemeEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SubjectId { get; set; }
        public int CountQuestions { get; set; }
        public SubjectEntity Subject { get; set; }
        public ICollection<QuestionEntity> Questions { get; set; }

        public ICollection<AvailableTestEntity> AvailableTests { get; set; }

        public ThemeEntity()
        {
            Questions = new HashSet<QuestionEntity>();
            AvailableTests = new HashSet<AvailableTestEntity>();
        }
    }
}