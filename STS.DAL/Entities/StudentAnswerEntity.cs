using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class StudentAnswerEntity
    {
        public Guid Id { get; set; }
        public Guid AnswerId { get; set; }
        public long AnswerDuration { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid StudentId { get; set; }

        public virtual AnswerEntity AnswerEntity { get; set; }
        public virtual QuestionEntity QuestionEntity { get; set; }
        public UserEntity Student { get; set; }
    }
}