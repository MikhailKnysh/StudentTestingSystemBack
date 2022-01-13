using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Questions.Services;

namespace STS.Api.Controllers
{
    public class QuestionController : RootController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(
            IQuestionService questionService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _questionService = questionService;
        }

        [HttpGet("get/all/{themeid}")]
        public async Task<IActionResult> GetAllQuestionsByThemeIdAsync(Guid themeId)
        {
            var result = await _questionService.GetAllQuestionsByThemeIdAsync(themeId);

            return ToApiResult(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetQuestionByIdAsync(Guid id)
        {
            var result = await _questionService.GetQuestionByIdAsync(id);

            return ToApiResult(result);
        }

        [HttpGet("get/all/{difficulty}/{themeId}")]
        public async Task<IActionResult> GetAllQuestionsByDifficultyAsync(int difficulty, Guid themeId)
        {
            var result = await _questionService.GetAllQuestionsByDifficultyAsync(difficulty, themeId);

            return ToApiResult(result);
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _questionService.GetAllAsync();

            return ToApiResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestionAsync(Question question)
        {
            var result = await _questionService.CreateQuestionAsync(question);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteQuestionAsync(Guid id)
        {
            var result = await _questionService.DeleteQuestionAsync(id);

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateQuestionAsync(Question question)
        {
            var result = await _questionService.UpdateQuestionAsync(question);

            return ToApiResult(result);
        }

        [HttpPost("lock/{id}")]
        public async Task<IActionResult> LockQuestionAsync(Guid id, bool isLocked)
        {
            var result = await _questionService.LockQuestionAsync(id, isLocked);

            return ToApiResult(result);
        }

        [HttpPost("get/next/{testId}")]
        public async Task<IActionResult> GetNextQuestion(Guid testId)
        {
            var result = _questionService.GetNextQuestionAsync(testId);

            return ToApiResult(result);
        }
    }
}