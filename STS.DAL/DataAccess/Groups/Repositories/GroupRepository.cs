using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.DBContext;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Groups.Repositories
{
    public class GroupRepository : BaseRepositoryAbstract<GroupEntity>, IGroupRepository
    {
        public GroupRepository(
            ApplicationContext context
        ) : base(context)
        {
        }

        public async Task<List<GroupEntity>> GetAllAsync()
        {
            var groups = await _context.Groups
                .Include(e => e.GroupEntityUserEntities)
                .ToListAsync();

            return groups;
        }

        public async Task<int> AddUsersToGroup(Guid groupId, List<Guid> userIds)
        {
            var groupEntity = await FindAsync(g => g.Id == groupId);
            var users = await _context.Users
                .Select(x => x)
                .Where(x => userIds.Contains(x.Id))
                .ToListAsync();
            foreach (var user in users)
            {
                var groupEntityUserEntity = new GroupEntityUserEntity()
                {
                    GroupsId = groupEntity.Id,
                    UsersId = user.Id
                };
                groupEntity.GroupEntityUserEntities.Add(groupEntityUserEntity);
            }

            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}