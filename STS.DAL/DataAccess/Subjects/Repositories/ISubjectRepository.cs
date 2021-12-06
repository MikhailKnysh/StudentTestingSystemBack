using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entitieas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Subjects.Repositories
{
    public interface ISubjectRepository : IBaseRepository<SubjectEntity>
    {
        Task<SubjectEntity> GetById(Guid id);
        Task<List<SubjectEntity>> GetAll();
    }
}