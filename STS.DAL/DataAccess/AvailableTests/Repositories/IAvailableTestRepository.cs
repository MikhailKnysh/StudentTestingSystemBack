using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.AvailableTests.Repositories
{
    public interface IAvailableTestRepository : IBaseRepository<AvailableTestEntity>
    {
        Task<List<AvailableTestEntity>> GetAllByUserIdAsync(Guid userId);
    }
}