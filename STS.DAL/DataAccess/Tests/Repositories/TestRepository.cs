using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Task<List<TestEntity>> GetAllTestsByGroupAsync(Guid groupId)
        {
            var tests = _context.Tests
                .Include(testEntity => testEntity.Student)
                .ThenInclude(userEntity => userEntity.Groups)
                .Where(testEntity => testEntity.Student.Groups.FirstOrDefault(groupEntity => groupEntity.Id == groupId) != null)
                .ToListAsync();

            return tests;
        }
    }
}