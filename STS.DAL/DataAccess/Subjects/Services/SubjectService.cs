using FluentResults;
using STS.DAL.DataAccess.Subjects.Repositories;
using System.Threading.Tasks;
using AutoMapper;
using System;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using System.Collections.Generic;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Subjects.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(
            ISubjectRepository subjectRepository,
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

        public async Task<Result<Subject>> GetById(Guid id)
        {
            var foundedEntity = await _subjectRepository.GetById(id);
            var subject = _mapper.Map<Subject>(foundedEntity);

            return subject.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<Subject>>> GetAll()
        {
            var foundedEntities = await _subjectRepository.GetAll();
            var subjects = _mapper.Map<List<Subject>>(foundedEntities);

            return subjects.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> UpdateAsync(Subject subject)
        {
            var foundedEntity = await _subjectRepository.FindAsync(g => g.Id == subject.Id);
            foundedEntity.Title = subject.Title;
            

            var responseDb = await _subjectRepository.UpdateAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.SubjectErrors.SubjectNotUpdated);
        }

        public async Task<Result<Subject>> FindByTitleAsync(string title)
        {
            var subjectEntity = await _subjectRepository.FindAsync(s => s.Title == title);
            var subject = _mapper.Map<Subject>(subjectEntity);

            return subject.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var foundedEntity = await _subjectRepository.FindAsync(g => g.Id == id);

            var responseDb = await _subjectRepository.DeleteAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.SubjectErrors.SubjectNotDeleted);
        }
    }
}