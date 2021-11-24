using FluentResults;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entitieas;
using System;
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

        public Task<IQueryable<SubjectEntity>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}