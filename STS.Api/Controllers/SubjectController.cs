using Microsoft.AspNetCore.Mvc;
using STS.DAL.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using STS.Common.Models;
using STS.Common.RootControllers;
using System;
using Microsoft.AspNetCore.Authorization;
using STS.Common.Constans;

namespace STS.Api.Controllers
{
    [Authorize(Policy = RoleConstants.PolicyConstants.AdminAndTeacherPolicy)]
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
        
        [Authorize(Policy = RoleConstants.PolicyConstants.AdminAndTeacherPolicy)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Subject subject)
        {
            var result = await _subjectService.CreateAsync(subject);

            return ToApiResult(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _subjectService.GetById(id);

            return ToApiResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _subjectService.GetAll();

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Subject subject)
        {
            var result = await _subjectService.UpdateAsync(subject);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _subjectService.DeleteAsync(id);

            return ToApiResult(result);
        }
    }
}