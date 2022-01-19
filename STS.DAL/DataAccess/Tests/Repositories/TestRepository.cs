using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.DBContext;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Tests.Repositories
{
    public class TestRepository : BaseRepositoryAbstract<TestEntity>, ITestRepository
    {
        public TestRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<TestEntity>> GetAllTestsByGroupAsync(Guid groupId)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.GroupEntityUserEntities)
                .Where(testEntity =>
                    testEntity.Student.GroupEntityUserEntities.FirstOrDefault(groupEntity =>
                        groupEntity.GroupsId == groupId) != null)
                .ToListAsync();

            return tests;
        }

        public async Task<List<TestEntity>> GetAllTestsByUserIdAsync(Guid userId)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.GroupEntityUserEntities)
                .Where(testEntity => testEntity.UserId == userId)
                .ToListAsync();

            return tests;
        }

        public async Task<TestEntity> GetTestByIdAsync(Guid id)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.GroupEntityUserEntities)
                .FirstOrDefaultAsync(testEntity => testEntity.Id == id);

            return tests;
        }

        public async Task<List<TestEntity>> GetAllTestByThemeIdAsync(Guid themeId)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.GroupEntityUserEntities)
                .Where(testEntity => testEntity.ThemeId == themeId)
                .ToListAsync();

            return tests;
        }
    }
}