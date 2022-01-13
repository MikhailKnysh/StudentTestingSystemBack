using System;
using System.Collections.Generic;

namespace STS.Common.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid IdTeacher { get; set; }
        public Guid IdTheme { get; set; }
        public string Title { get; set; }
        public string QuestionBody { get; set; }
        public string ImageLink { get; set; }
        public bool IsDisabled { get; set; }
        public string LinkForHelp { get; set; }
        public int Difficulty { get; set; }
        public int TimeLimit { get; set; }
        public List<Answer> Answers { get; set; }
        public string Type { get; set; }
    }
}