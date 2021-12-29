using System;

namespace STS.Common.Models
{
    public class StudentAnswer
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Guid QuestionsId { get; set; }
        public Guid AnswerId { get; set; }
        public long AnswerDuration { get; set; }
        public string TestTitle { get; set; }
        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}