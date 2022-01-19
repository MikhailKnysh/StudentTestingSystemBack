using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.StudentAnswers.Services
{
    public interface IStudentAnswerService
    {
        Task<Result> CreateAsync(StudentAnswerLight studentAnswer);
        Task<Result<StudentAnswerEntity>> GetStudentAnswerByQuestionIdAsync(Guid questionId);
        Task<Result<List<StudentAnswerEntity>>> GetAllByStudentIdAsync(Guid studentId);
    }
}