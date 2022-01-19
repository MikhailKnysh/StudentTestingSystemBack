using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class GroupEntity
    {
        public GroupEntity()
        {
            GroupEntityUserEntities = new HashSet<GroupEntityUserEntity>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GroupEntityUserEntity> GroupEntityUserEntities { get; set; }
    }
}
