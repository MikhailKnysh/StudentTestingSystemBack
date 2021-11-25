using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Auth.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Sessions.Services;

namespace STS.Api.Controllers
{
    [AllowAnonymous]
    public class SessionController : RootController
    {
        private readonly ISessionService _sessionService;

        public SessionController(
            ISessionService sessionService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _sessionService = sessionService;
        }

        [HttpPost("session/create")]
        public async Task<IActionResult> CreateSession(AuthModel authModel)
        {
            var result = await _sessionService.CreateSession(authModel);

            return ToApiResult(result);
        }
    }
}