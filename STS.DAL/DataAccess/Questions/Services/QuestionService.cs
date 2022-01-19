using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.AvailableTests.Sevices;
using STS.DAL.DataAccess.Questions.Repositories;
using STS.DAL.DataAccess.StudentAnswers.Repositories;
using STS.DAL.DataAccess.StudentAnswers.Services;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Questions.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAvailableTestService _availableTestService;
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IMapper _mapper;

        public QuestionService(
            IQuestionRepository questionRepository,
            IAvailableTestService availableTestService,
            IStudentAnswerService studentAnswerService,
            IMapper mapper
        )
        {
            _questionRepository = questionRepository;
            _availableTestService = availableTestService;
            _studentAnswerService = studentAnswerService;
            _mapper = mapper;
        }

        public async Task<Result<List<Question>>> GetAllQuestionsByThemeIdAsync(Guid themeId)
        {
            var questionEntities = await _questionRepository.GetAllQuestionsByThemeIdAsync(themeId);
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<Question>> GetQuestionByIdAsync(Guid id)
        {
            var questionEntities = await _questionRepository.GetQuestionByIdAsync(id);
            var questions = _mapper.Map<Question>(questionEntities);

            return questions.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<Question>>> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId)
        {
            var questionEntities = await _questionRepository
                .GetAllQuestionsByDifficultyAsync(difficulty, themeId);
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<Question>>> GetAllAsync()
        {
            var questionEntities = await _questionRepository.GetAll();
            var questions = _mapper.Map<List<Question>>(questionEntities);

            return questions.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }


        public async Task<Result> CreateQuestionAsync(Question question)
        {
            var questionEntity = _mapper.Map<QuestionEntity>(question);
            questionEntity.Id = Guid.NewGuid();
            foreach (var questionEntityAnswer in questionEntity.Answers)
            {
                questionEntityAnswer.Id = Guid.NewGuid();
                questionEntityAnswer.Id_Question = questionEntity.Id;
            }

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
            foundedEntity.UserId = question.IdTeacher;
            foundedEntity.ThemeId = question.IdTheme;
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

        public async Task<Result<Question>> GetNextQuestionAsync(Guid studentId, Guid themeId)
        {
            // Random random = new Random();
            // int quantity = await _questionRepository.GetQuestionsQuantityAsync();
            //
            // int toSkip = random.Next(1, quantity);
            //
            // var foundedEntity = await _questionRepository.GetNextQuestionAsync(toSkip);
            // var questionModel = _mapper.Map<Question>(foundedEntity);
            //
            // return questionModel.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);

            var questions = await _questionRepository.GetAllQuestionsByThemeIdAsync(themeId);
            var studentAnswerResult = await _studentAnswerService.GetAllByStudentIdAsync(studentId);
            if (studentAnswerResult.IsSuccess)
            {
                var questionsIdsWithAnswers = studentAnswerResult.Value.Select(x => x.QuestionId);
                var question = questions.FirstOrDefault(x => !questionsIdsWithAnswers.Contains(x.Id));
                var questionModel = _mapper.Map<Question>(question);

                return questionModel.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
            }
            else
            {
                var question = questions.FirstOrDefault();
                var questionModel = _mapper.Map<Question>(question);

                return questionModel.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
            }
        }

        public async Task<Result<Question>> IntiTestAsync(AvailableTest availableTest)
        {
            var availableTestInDb = await _availableTestService.GetByStudentId(availableTest.StudentId);
            Question question = null;
            if (availableTestInDb.IsSuccess && availableTestInDb.Value.Any(x => x.StudentId == availableTest.StudentId && x.Theme?.Id == availableTest.Theme?.Id))
            {
                var questionResult = await GetNextQuestionAsync(availableTest.StudentId,availableTest.Theme.Id);
                if (questionResult.IsSuccess)
                {
                    question = questionResult.Value;
                }
            }

            return question.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}