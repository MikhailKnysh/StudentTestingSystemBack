using Common.Models;
using FluentResults;
using STS.DAL.DataAccess.Subjects.Repositories;
using STS.DAL.EntityContext.Entitieas;
using STS.DAL.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using Common.Constans;
using Common.FluentResult.Extensions;
using System;

namespace STS.DAL.DataAccess.Subjects.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository<SubjectEntity> _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(
            ISubjectRepository<SubjectEntity> subjectRepository,
            IMapper mapper
        )
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Subject subject)
        {
            var subjectEntity = _mapper.Map<SubjectEntity>(subject);
            subjectEntity.Id = new Guid();

            var responseDb = await _subjectRepository.CreateAsync(subjectEntity);

            return responseDb.CheckDbResponse(ErrorConstants.SubjectErrors.SubjectNotCreated);
        }

        public async Task<Result<Subject>> FindByTitleAsync(string title)
        {
            var subjectEntity = await _subjectRepository.FindAsync(s => s.Title == title);
            var subject = _mapper.Map<Subject>(subjectEntity);

            return subject.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}