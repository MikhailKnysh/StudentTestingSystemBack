using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Tests.Services;

namespace STS.Api.Controllers
{
    public class TestController : RootController
    {
        private readonly ITestService _testService;

        public TestController(
            ITestService testService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _testService = testService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTestAsync(Test test)
        {
            var result = await _testService.CreateTestAsync(test);

            return ToApiResult(result);
        }

        [HttpGet("get/all/student/{userid}")]
        public async Task<IActionResult> GetAllTestsByUserIdAsync(Guid userId)
        {
            var result = await _testService.GetAllTestsByUserIdAsync(userId);

            return ToApiResult(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetTestByIdAsync(Guid id)
        {
            var result = await _testService.GetTestByIdAsync(id);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _testService.DeleteAsync(id);

            return ToApiResult(result);
        }

        [HttpGet("get/all/group/{groupId}")]
        public async Task<IActionResult> GetAllTestsByGroupAsync(Guid groupId)
        {
            var result = await _testService.GetAllTestsByGroupAsync(groupId);

            return ToApiResult(result);
        }
    }
}