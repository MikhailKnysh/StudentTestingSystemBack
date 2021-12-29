using System;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.StudentAnswers.Services
{
    public interface IStudentAnswerService
    {
        Task<Result> CreateAsync(StudentAnswer studentAnswer);
        Task<Result<StudentAnswerEntity>> GetStudentAnswerByQuestionIdAsync(Guid questionId);
    }
}