using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            AvailableTests = new HashSet<AvailableTestEntity>();
            GroupEntityUserEntities = new HashSet<GroupEntityUserEntity>();
            Questions = new HashSet<QuestionEntity>();
            Tests = new HashSet<TestEntity>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<AvailableTestEntity> AvailableTests { get; set; }
        public virtual ICollection<GroupEntityUserEntity> GroupEntityUserEntities { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        public virtual ICollection<TestEntity> Tests { get; set; }
    }
}
