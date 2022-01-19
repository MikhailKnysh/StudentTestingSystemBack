using System;

namespace STS.Common.Models
{
    public class StudentAnswerLight
    {
        public Guid StudentId { get; set; }
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public long TimeDuration { get; set; }
    }
}