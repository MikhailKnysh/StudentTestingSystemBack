using System;
using System.Collections.Generic;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Entities
{
    public class StudentAnswerEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public long AnswerDuration { get; set; }
        //
        // public AnswerEntity Answer { get; set; }
        // public QuestionEntity Question { get; set; }
        // public UserEntity Student { get; set; }
    }
}