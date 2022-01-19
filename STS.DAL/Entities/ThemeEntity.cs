using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class ThemeEntity
    {
        public ThemeEntity()
        {
            AvailableTests = new HashSet<AvailableTestEntity>();
            Questions = new HashSet<QuestionEntity>();
            Tests = new HashSet<TestEntity>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SubjectId { get; set; }
        public int CountQuestions { get; set; }

        public virtual SubjectEntity SubjectEntity { get; set; }
        public virtual ICollection<AvailableTestEntity> AvailableTests { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        public virtual ICollection<TestEntity> Tests { get; set; }
    }
}
