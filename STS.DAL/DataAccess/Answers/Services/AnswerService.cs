using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.Answers.Repositories;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Answers.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(
            IAnswerRepository answerRepository,
            IMapper mapper
        )
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Answer answer)
        {
            var answerEntity = _mapper.Map<AnswerEntity>(answer);
            answerEntity.Id = Guid.NewGuid();

            var responseDb = await _answerRepository.CreateAsync(answerEntity);

            return responseDb.CheckDbResponse(ErrorConstants.AnswerErrors.AnswerNotCreated);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var foundedEntity = await _answerRepository.FindAsync(a => a.Id == id);
            var responseDb = await _answerRepository.DeleteAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.AnswerErrors.AnswerNotDeleted);
        }

        public async Task<Result> UpdateAsync(Answer answer)
        {
            var foundedEntity = await _answerRepository.FindAsync(a => a.Id == answer.ID);
            foundedEntity.Body = answer.Body;
            foundedEntity.Id_Question = answer.ID_Question;
            foundedEntity.IsCorrect = answer.IsCorrect;

            var responseDb = await _answerRepository.UpdateAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.AnswerErrors.AnswerNotUpdated);
        }

        public async Task<Result<List<Answer>>> GetAllAnswerByQuestionIdAsync(Guid questionId)
        {
            var answerEntities = await _answerRepository.GetAllByQuestionID(questionId);
            var answers = _mapper.Map<List<Answer>>(answerEntities);

            return answers.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}