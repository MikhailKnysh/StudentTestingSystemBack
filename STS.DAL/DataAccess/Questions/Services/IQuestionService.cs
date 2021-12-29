using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Questions.Services
{
    public interface IQuestionService
    {
        Task<Result<List<Question>>> GetAllQuestionsByThemeIdAsync(Guid themeId);
        Task<Result<Question>> GetQuestionByIdAsync(Guid id);
        Task<Result<List<Question>>> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId);
        Task<Result<List<Question>>> GetAllAsync();
        Task<Result<Question>> GetQuestionByThemIdAndParametersAsync(Guid themeId);
        Task<Result> CreateQuestionAsync(Question question);
        Task<Result> DeleteQuestionAsync(Guid id);
        Task<Result> UpdateQuestionAsync(Question question);
        Task<Result> LockQuestionAsync(Guid id, bool isLocked);
        Task<Result<Question>> GetNextQuestionAsync(Guid testId);
    }
}