using System;

namespace STS.Common.Models
{
    public class Subject
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public Guid TeacherId { get; set; }
    }
}