using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Answers.Services
{
    public interface IAnswerService
    {
        Task<Result> CreateAsync(Answer answer);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Answer answer);
        Task<Result<List<Answer>>> GetAllAnswerByQuestionIdAsync(Guid questionId);
    }
}