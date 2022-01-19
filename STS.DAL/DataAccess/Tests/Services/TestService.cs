using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.Common.Models;
using STS.Common.SMTP.Service;
using STS.DAL.DataAccess.AvailableTests.Sevices;
using STS.DAL.DataAccess.Tests.Repositories;
using STS.DAL.DataAccess.Themes.Services;
using STS.DAL.DataAccess.Users.Services;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Tests.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMailSenderService _mailSenderService;
        private readonly IUserService _userService;
        private readonly IThemeService _themeService;
        private readonly IAvailableTestService _availableTestService;
        private readonly IMapper _mapper;

        public TestService(
            ITestRepository testRepository,
            IMailSenderService mailSenderService,
            IUserService userService,
            IThemeService themeService,
            IAvailableTestService availableTestService,
            IMapper mapper
        )
        {
            _testRepository = testRepository;
            _mailSenderService = mailSenderService;
            _userService = userService;
            _themeService = themeService;
            _availableTestService = availableTestService;
            _mapper = mapper;
        }

        public async Task<Result<Test>> CreateTestAsync(Guid userId, Guid themeId)
        {
            var testEntity = new TestEntity()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ThemeId = themeId,
                Mark = new Random().Next(20, 100),
                DateTimeFinish = DateTimeOffset.Now.ToUnixTimeSeconds(),
                // TODO: Calculate Mark and other fields
            };
            var responseDb = await _testRepository.CreateAsync(testEntity);
            Test test = null;
            if (responseDb > 0)
            {
                test = _mapper.Map<Test>(testEntity);
            }

            return test.CheckEntityNull(ErrorConstants.TestError.TestNotCreated);
        }

        public async Task<Result<List<Test>>> GetAllTestsByUserIdAsync(Guid userId)
        {
            var testEntities = await _testRepository.GetAllTestsByUserIdAsync(userId);
            var tests = _mapper.Map<List<Test>>(testEntities);

            return tests.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<Test>> GetTestByIdAsync(Guid id)
        {
            var testEntity = await _testRepository.GetTestByIdAsync(id);
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

        public async Task<Result<List<Test>>> GetAllTestByThemeIdAsync(Guid themeId)
        {
            var testEntities = await _testRepository.GetAllTestByThemeIdAsync(themeId);
            var tests = _mapper.Map<List<Test>>(testEntities);

            return tests.CheckCollectionNullOrEmpty(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result<List<AvailableTest>>> SetAvailableTestAsync(
            AvailableTestForStudents availableTestForStudents)
        {
            var availableTests = new List<AvailableTest>();
            var themeResult = await _themeService.GetByIdAsync(availableTestForStudents.ThemeId);
            if (themeResult.IsSuccess)
            {
                var studentsResult = await _userService.GetStudentsByIdsAsync(availableTestForStudents.Students);
                if (studentsResult.IsSuccess)
                {
                    foreach (var user in studentsResult.Value)
                    {
                        await _mailSenderService.SendMessageWithInviteAsync(user.Email, themeResult.Value.Title);
                        var availableTest = new AvailableTest()
                        {
                            StudentId = user.Id,
                            Theme = themeResult.Value,
                        };
                        var createResult = await _availableTestService.CreateAsync(availableTest);
                        if (createResult.IsSuccess)
                        {
                            availableTests.Add(availableTest);
                        }
                    }
                }
            }

            return availableTests.CheckCollectionNullOrEmpty(ErrorConstants.AvailableTestError.AvailableTestNotSet);
        }

        public async Task<Result<List<AvailableTest>>> GetAvailableTestAsync(Guid userId)
        {
            var result = await _availableTestService.GetByStudentId(userId);

            return result;
        }
    }
}