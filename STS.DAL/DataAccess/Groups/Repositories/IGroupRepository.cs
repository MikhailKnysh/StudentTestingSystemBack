using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Groups.Repositories
{
    public interface IGroupRepository : IBaseRepository<GroupEntity>
    {
        Task<List<GroupEntity>> GetAllAsync();
        Task<int> AddUsersToGroup(Guid groupId, List<Guid> userIds);
    }
}