using System;
using System.Collections.Generic;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Entities
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; }

        public GroupEntity()
        {
            Users = new HashSet<UserEntity>();
        }
    }
}