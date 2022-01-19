using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Themes.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using STS.Common.Constans;

namespace STS.Api.Controllers
{
    [Authorize(Policy = RoleConstants.PolicyConstants.CommonPolicy)]
    public class ThemeController : RootController
    {
        private readonly IThemeService _themeService;

        public ThemeController(
            IThemeService themeService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _themeService = themeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Theme theme)
        {
            var result = await _themeService.CreateAsync(theme);

            return ToApiResult(result);
        }

        [HttpGet("get/all/subject/{id}")]
        public async Task<IActionResult> GetAllBySubjectId([FromRoute] Guid id)
        {
            var result = await _themeService.GetAllBySubjectId(id);

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Theme theme)
        {
            var result = await _themeService.UpdateAsync(theme);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _themeService.DeleteAsync(id);

            return ToApiResult(result);
        }
    }
}
