using System;

namespace STS.Common.Models
{
    public class Answer
    {
        public Guid ID { get; set; }
        public Guid ID_Question { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }
    }
}