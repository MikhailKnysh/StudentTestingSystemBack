using System;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Entities
{
    public class AvailableTestEntity
    {
        public Guid Id { get; set; }
        public Guid ThemeId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsAvailable { get; set; }

        public UserEntity Student { get; set; }
        public ThemeEntity Theme { get; set; }
    }
}