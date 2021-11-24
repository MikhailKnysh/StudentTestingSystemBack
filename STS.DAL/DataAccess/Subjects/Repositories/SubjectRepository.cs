using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entitieas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Subjects.Repositories
{
    public class SubjectRepository : BaseRepositoryAbstract<SubjectEntity>, ISubjectRepository<SubjectEntity>
    {
        public SubjectRepository(
            ApplicationContext context
        ) : base(context)
        {
        }

        public async Task<SubjectEntity> GetById(Guid id)
        {
            var result = await FindAsync(g => g.Id == id);

            return result;
        }

        public async Task<List<SubjectEntity>> GetAll()
        {
            var result = await _context.Subjects.Select(x => x).ToListAsync();

            return result;
        }
    }
}