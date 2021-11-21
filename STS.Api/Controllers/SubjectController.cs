using Common.Models;
using Microsoft.AspNetCore.Mvc;
using STS.DAL.Interfaces;
using System.Threading.Tasks;
using Common.RootControllers;
using Microsoft.Extensions.Logging;

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
    }
}