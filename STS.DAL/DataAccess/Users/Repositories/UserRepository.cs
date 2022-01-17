using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.DataAccess.Users.Repositories
{
    public class UserRepository : BaseRepositoryAbstract<UserEntity>, IUserRepository
    {
        public UserRepository(
            ApplicationContext context
        ) : base(context)
        {
        }

        public async Task<List<UserEntity>> GetStudentsByIdsAsync(List<Guid> students)
        {
            var users = await _context.Users.Where(u => students.Contains(u.Id)).ToListAsync();

            return users;
        }
    }
}