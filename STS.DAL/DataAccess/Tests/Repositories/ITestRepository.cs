using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.Common.Models;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Tests.Repositories
{
    public interface ITestRepository : IBaseRepository<TestEntity>
    {
        Task<List<TestEntity>> GetAllTestsByGroupAsync(Guid groupId);
        Task<List<TestEntity>> GetAllTestsByUserIdAsync(Guid userId);
        Task<TestEntity> GetTestByIdAsync(Guid id);
        Task<List<TestEntity>> GetAllTestByThemeIdAsync(Guid themeId);
    }
}