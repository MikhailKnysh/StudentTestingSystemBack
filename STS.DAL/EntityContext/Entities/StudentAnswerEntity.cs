using System;
using System.Collections.Generic;

namespace STS.DAL.EntityContext.Entities
{
    public class StudentAnswerEntity
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Guid QuestionsId { get; set; }
        public Guid AnswerId { get; set; }
        public long AnswerDuration { get; set; }
        public TestEntity Test { get; set; }
        public AnswerEntity Answer { get; set; }
        public QuestionEntity Question { get; set; }
    }
}