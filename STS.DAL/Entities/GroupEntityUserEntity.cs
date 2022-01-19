using System;
using System.Collections.Generic;

#nullable disable

namespace STS.DAL.Entities
{
    public partial class GroupEntityUserEntity
    {
        public Guid GroupsId { get; set; }
        public Guid UsersId { get; set; }

        public virtual GroupEntity GroupsEntity { get; set; }
        public virtual UserEntity UsersEntity { get; set; }
    }
}
