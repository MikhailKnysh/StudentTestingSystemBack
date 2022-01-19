using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Constans;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.StudentAnswers.Services;

namespace STS.Api.Controllers
{
    [Authorize(Policy = RoleConstants.PolicyConstants.CommonPolicy)]
    public class StudentAnswerController : RootController
    {
        private readonly IStudentAnswerService _studentAnswerService;

        public StudentAnswerController(
            IStudentAnswerService studentAnswerService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _studentAnswerService = studentAnswerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudentAnswerAsync(StudentAnswer studentAnswer)
        {
            var result = await _studentAnswerService.CreateAsync(studentAnswer);

            return ToApiResult(result);
        }

        [HttpGet("get/{questionId}")]
        public async Task<IActionResult> GetStudentAnswerByQuestionIdAsync(Guid questionId)
        {
            var result = await _studentAnswerService.GetStudentAnswerByQuestionIdAsync(questionId);

            return ToApiResult(result);
        }
    }
}