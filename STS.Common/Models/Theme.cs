using System;

namespace Common.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SubjectId { get; set; }
        public int CountQuestions { get; set; }
    }
}