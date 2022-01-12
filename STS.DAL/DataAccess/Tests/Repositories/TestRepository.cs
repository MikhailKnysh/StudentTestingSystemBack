using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.Common.Models;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

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
                .ThenInclude(userEntity => userEntity.Groups)
                .Include(e=>e.Answers)
                .Where(testEntity => testEntity.Student.Groups.FirstOrDefault(groupEntity => groupEntity.Id == groupId) != null)
                .ToListAsync();

            return tests;
        }

        public async Task<List<TestEntity>> GetAllTestsByUserIdAsync(Guid userId)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.Groups)
                .Include(e=>e.Answers)
                .Where(testEntity => testEntity.UserId==userId)
                .ToListAsync();

            return tests;
        }

        public async Task<TestEntity> GetTestByIdAsync(Guid id)
        {
            var tests = await _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.Groups)
                .Include(e => e.Answers)
                .FirstOrDefaultAsync(testEntity => testEntity.Id == id);

            return tests;
        }
    }
}