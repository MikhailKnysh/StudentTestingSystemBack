using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Answers.Services;

namespace STS.Api.Controllers
{
    public class AnswerController : RootController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(
            IAnswerService answerService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _answerService = answerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAnswerAsync(Answer answer)
        {
            var result = await _answerService.CreateAsync(answer);

            return ToApiResult(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAnswerAsync(Guid id)
        {
            var result = await _answerService.DeleteAsync(id);

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAnswerAsync(Answer answer)
        {
            var result = await _answerService.UpdateAsync(answer);

            return ToApiResult(result);
        }

        [HttpGet("get/all/{questionId}")]
        public async Task<IActionResult> GetAllAnswersByQuestionIDAsync(Guid questionId)
        {
            var result = await _answerService.GetAllAnswerByQuestionIdAsync(questionId);

            return ToApiResult(result);
        }
    }
}