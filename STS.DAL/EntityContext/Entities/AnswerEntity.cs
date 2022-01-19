using System;

namespace STS.DAL.EntityContext.Entities
{
    public class AnswerEntity
    {
        public Guid Id { get; set; }
        public Guid Id_Question { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }
    }
}