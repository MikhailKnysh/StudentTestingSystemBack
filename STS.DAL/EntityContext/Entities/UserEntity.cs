using System;
using System.Collections.Generic;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.EntityContext.Entitieas
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<GroupEntity> Groups { get; set; }

        public ICollection<QuestionEntity> Questions { get; set; }
        public ICollection<TestEntity> Tests { get; set; }
        public ICollection<AvailableTestEntity> AvailableTests { get; set; }

        public UserEntity()
        {
            AvailableTests = new HashSet<AvailableTestEntity>();
            Groups = new HashSet<GroupEntity>();
            Questions = new HashSet<QuestionEntity>();
            Tests = new HashSet<TestEntity>();
        }
    }
}