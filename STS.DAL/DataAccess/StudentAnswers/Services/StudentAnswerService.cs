using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.StudentAnswers.Repositories;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.StudentAnswers.Services
{
    public class StudentAnswerService : IStudentAnswerService
    {
        private readonly IStudentAnswerRepository _studentAnswerRepository;
        private readonly IMapper _mapper;

        public StudentAnswerService(
            IStudentAnswerRepository studentAnswerRepository,
            IMapper mapper
        )
        {
            _studentAnswerRepository = studentAnswerRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(StudentAnswerLight studentAnswer)
        {
            var entity = _mapper.Map<StudentAnswerEntity>(studentAnswer);
            var responseDb = await _studentAnswerRepository.CreateAsync(entity);

            return responseDb.CheckDbResponse(ErrorConstants.StudentAnswerError.StudentAnswerNotCreated);
        }

        public async Task<Result<StudentAnswerEntity>> GetStudentAnswerByQuestionIdAsync(Guid questionId)
        {
            var result = await _studentAnswerRepository.FindAsync(e => e.QuestionId == questionId);

            return result.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }


        public async Task<Result<List<StudentAnswerEntity>>> GetAllByStudentIdAsync(Guid studentId)
        {
            var result = await _studentAnswerRepository.WhereAsync(e => e.StudentId == studentId);

            return result.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}