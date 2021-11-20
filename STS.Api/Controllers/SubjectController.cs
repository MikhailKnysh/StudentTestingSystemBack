using Microsoft.AspNetCore.Mvc;
using STS.DAL.Interfaces;
using System.Threading.Tasks;

namespace STS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(string name)
        {
            await _subjectService.CreateAsync(name);
            return Ok();
        }
    }
}