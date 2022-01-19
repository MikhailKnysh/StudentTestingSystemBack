using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Users.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<List<UserEntity>> GetStudentsByIdsAsync(List<Guid> students);
    }
}