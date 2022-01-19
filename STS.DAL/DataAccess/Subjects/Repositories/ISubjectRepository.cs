using STS.DAL.DataAccess.BaseRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Subjects.Repositories
{
    public interface ISubjectRepository : IBaseRepository<SubjectEntity>
    {
        Task<SubjectEntity> GetById(Guid id);
        Task<List<SubjectEntity>> GetAll();
    }
}