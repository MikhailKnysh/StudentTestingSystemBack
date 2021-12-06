using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

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
                .Include(e => e.Users)
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
                groupEntity.Users.Add(user);
            }

            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}