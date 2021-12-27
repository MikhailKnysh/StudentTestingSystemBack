using System;
using System.Collections;
using System.Collections.Generic;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Entities
{
    public class QuestionEntity
    {
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

        public UserEntity User { get; set; }
        public ThemeEntity Theme { get; set; }
        public ICollection<AnswerEntity> Answers { get; set; }

        public QuestionEntity()
        {
            Answers = new HashSet<AnswerEntity>();
        }
    }
}