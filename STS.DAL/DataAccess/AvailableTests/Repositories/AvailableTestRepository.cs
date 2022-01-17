﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.AvailableTests.Repositories
{
    public class AvailableTestRepository : BaseRepositoryAbstract<AvailableTestEntity>, IAvailableTestRepository
    {
        public AvailableTestRepository(
            ApplicationContext context
        ) : base(context)
        {
        }

        public async Task<List<AvailableTestEntity>> GetAllByUserIdAsync(Guid userId)
        {
            var entities = await _context.AvailableTests
                .Include(e => e.Student)
                .Include(e => e.Theme)
                .Where(e => e.StudentId == userId)
                .ToListAsync();

            return entities;
        }
    }
}