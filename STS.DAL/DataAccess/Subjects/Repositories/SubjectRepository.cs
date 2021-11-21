using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.DataAccess.Subjects.Repositories
{
    public class SubjectRepository : BaseRepositoryAbstract<SubjectEntity>, ISubjectRepository<SubjectEntity>
    {
        public SubjectRepository(
            AppContext context
        ) : base(context)
        {
        }
    }
}