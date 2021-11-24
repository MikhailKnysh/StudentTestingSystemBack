using Common.Models;
using Microsoft.AspNetCore.Mvc;
using STS.DAL.Interfaces;
using System.Threading.Tasks;
using Common.RootControllers;
using Microsoft.Extensions.Logging;
using System;

namespace STS.Api.Controllers
{
    public class SubjectController : RootController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(
            ISubjectService subjectService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _subjectService = subjectService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Subject subject)
        {
            var result = await _subjectService.CreateAsync(subject);

            return ToApiResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _subjectService.GetById(id);

            return ToApiResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _subjectService.GetAll();

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Subject subject)
        {
            var result = await _subjectService.UpdateAsync(subject);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _subjectService.DeleteAsync(id);

            return ToApiResult(result);
        }
    }
}