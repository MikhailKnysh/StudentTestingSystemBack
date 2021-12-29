using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.DAL.DataAccess.Tests.Repositories;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Tests.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(
            ITestRepository testRepository,
            IMapper mapper
        )
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateTestAsync(Test test)
        {
            var testEntity = _mapper.Map<TestEntity>(test);
            var responseDb = await _testRepository.CreateAsync(testEntity);

            return responseDb.CheckDbResponse(ErrorConstants.TestError.TestNotCreated);
        }

        public async Task<Result<List<Test>>> GetAllTestsByUserIdAsync(Guid userId)
        {
            var testEntities = await _testRepository.WhereAsync(t => t.UserId == userId);
            var tests = _mapper.Map<List<Test>>(testEntities);

            return tests.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<Test>> GetTestByIdAsync(Guid id)
        {
            var testEntity = await _testRepository.FindAsync(t => t.Id == id);
            var test = _mapper.Map<Test>(testEntity);

            return test.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var foundedEntity = await _testRepository.FindAsync(t => t.Id == id);

            var responseDb = await _testRepository.DeleteAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.TestError.TestNotDeleted);
        }

        public async Task<Result<List<Test>>> GetAllTestsByGroupAsync(Guid groupId)
        {
            var testEntities = await _testRepository.GetAllTestsByGroupAsync(groupId);
            var tests = _mapper.Map<List<Test>>(testEntities);

            return tests.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}