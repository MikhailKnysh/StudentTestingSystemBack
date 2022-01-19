using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class AnswerEntity
    {
        public AnswerEntity()
        {
            StudentAnswers = new HashSet<StudentAnswerEntity>();
        }

        public Guid Id { get; set; }
        public Guid IdQuestion { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }

        public virtual QuestionEntity IdQuestionEntityNavigation { get; set; }
        public virtual ICollection<StudentAnswerEntity> StudentAnswers { get; set; }
    }
}
