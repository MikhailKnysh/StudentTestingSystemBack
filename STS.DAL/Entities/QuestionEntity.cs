using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class QuestionEntity
    {
        public QuestionEntity()
        {
            Answers = new HashSet<AnswerEntity>();
            StudentAnswers = new HashSet<StudentAnswerEntity>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ThemeId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PathToImage { get; set; }
        public bool IsLocked { get; set; }
        public string LinkForHelp { get; set; }
        public int Difficulty { get; set; }
        public int TimeLimit { get; set; }
        public string Type { get; set; }

        public virtual ThemeEntity ThemeEntity { get; set; }
        public virtual UserEntity UserEntity { get; set; }
        public virtual ICollection<AnswerEntity> Answers { get; set; }
        public virtual ICollection<StudentAnswerEntity> StudentAnswers { get; set; }
    }
}
