using FluentResults;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entitieas;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Subjects.Repositories
{
    public interface ISubjectRepository<T> : IBaseRepository<T>
    {
        Task<SubjectEntity> GetById(Guid id);
        Task<IQueryable<SubjectEntity>> GetAll();
    }
}