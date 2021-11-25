using System;

namespace Common.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Subject Subject { get; set; }
    }
}
