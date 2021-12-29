using System;
using System.Collections.Generic;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Entities
{
    public class TestEntity
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
        public UserEntity Student { get; set; }
        public ThemeEntity Theme { get; set; }
        public ICollection<StudentAnswerEntity> Answers { get; set; }

        public TestEntity()
        {
            Answers = new HashSet<StudentAnswerEntity>();
        }
    }
}