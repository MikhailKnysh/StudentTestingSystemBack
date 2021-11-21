using Common.Models;
using FluentResults;
using STS.DAL.DataAccess.Subjects.Repositories;
using STS.DAL.EntityContext.Entitieas;
using STS.DAL.Interfaces;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Subjects.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        public ISubjectRepository<SubjectEntity> _subjectRepository; 

        public SubjectService(ISubjectRepository<SubjectEntity> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public Task<Result> CreateAsync(SubjectModel subjectModel)
        {
            //mapping model to entity??
            _subjectRepository.Create();

            return Result<Task>.Ok();
        }
    }
}