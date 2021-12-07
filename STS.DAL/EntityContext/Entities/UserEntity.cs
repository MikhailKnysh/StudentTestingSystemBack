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

        public UserEntity()
        {
            Groups = new HashSet<GroupEntity>(); 
        }
    }
}