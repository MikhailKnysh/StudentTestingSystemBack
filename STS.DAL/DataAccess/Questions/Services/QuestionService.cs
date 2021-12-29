using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.Questions.Repositories;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Questions.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(
            IQuestionRepository questionRepository,
            IMapper mapper
        )
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<Question>>> GetAllQuestionsByThemeIdAsync(Guid themeId)
        {
            var questionEntities = await _questionRepository.WhereAsync(q => q.ThemeId == themeId);
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<Question>> GetQuestionByIdAsync(Guid id)
        {
            var questionEntities = await _questionRepository.FindAsync(q => q.Id == id);
            var questions = _mapper.Map<Question>(questionEntities);

            return questions.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<Question>>> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId)
        {
            var questionEntities = await _questionRepository
                .WhereAsync(q => q.ThemeId == themeId
                                 && q.Difficulty == difficulty);
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<Question>>> GetAllAsync()
        {
            var questionEntities = await _questionRepository.GetAll();
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<Question>> GetQuestionByThemIdAndParametersAsync(Guid themeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> CreateQuestionAsync(Question question)
        {
            var questionEntity = _mapper.Map<QuestionEntity>(question);
            questionEntity.Answers = null;
            questionEntity.User = null;
            questionEntity.Theme = null;

            var responseDb = await _questionRepository.CreateAsync(questionEntity);

            return responseDb.CheckDbResponse(ErrorConstants.QuestionError.QuestionNotCreated);
        }

        public async Task<Result> DeleteQuestionAsync(Guid id)
        {
            var foundedEntity = await _questionRepository.FindAsync(q => q.Id == id);
            var responseDb = await _questionRepository.DeleteAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.QuestionError.QuestionNotDeleted);
        }

        public async Task<Result> UpdateQuestionAsync(Question question)
        {
            var foundedEntity = await _questionRepository.FindAsync(q => q.Id == question.Id);
            foundedEntity.Id = question.Id;
            foundedEntity.UserId = question.Id_Teacher;
            foundedEntity.ThemeId = question.Id_Theme;
            foundedEntity.Title = question.Title;
            foundedEntity.Body = question.QuestionBody;
            foundedEntity.PathToImage = question.ImageLink;
            foundedEntity.IsLocked = question.IsDisabled;
            foundedEntity.LinkForHelp = question.LinkForHelp;
            foundedEntity.Difficulty = question.Difficulty;
            foundedEntity.TimeLimit = question.TimeLimit;
            foundedEntity.Type = question.Type;

            var responseDb = await _questionRepository.UpdateAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.QuestionError.QuestionNotDeleted);
        }

        public async Task<Result> LockQuestionAsync(Guid id, bool isLocked)
        {
            var foundedEntity = await _questionRepository.FindAsync(q => q.Id == id);
            foundedEntity.IsLocked = isLocked;
            var responseDb = await _questionRepository.UpdateAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.QuestionError.QuestionNotUpdated);
        }

        public Task<Result<Question>> GetNextQuestionAsync(Guid testId)
        {
            // todo сюда добавить поиск вопроса по формуле из диплома
            return null;
        }
    }
}