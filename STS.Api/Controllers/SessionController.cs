using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Auth.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Sessions.Services;
using STS.DAL.DataAccess.Users.Services;

namespace STS.Api.Controllers
{
    [AllowAnonymous]
    public class SessionController : RootController
    {
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;

        public SessionController(
            ISessionService sessionService,
            IUserService userService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _sessionService = sessionService;
            _userService = userService;
        }

        [HttpPost("session/create")]
        public async Task<IActionResult> CreateSession(AuthModel authModel)
        {
            var tokenResult = await _sessionService.CreateSession(authModel);
            var userResult = await _userService.GetUserByAuthDataAsync(authModel);
            if (userResult.IsSuccess && tokenResult.IsSuccess)
            {
                userResult.Value.Token = tokenResult.Value.Bearer;
                userResult.Value.Expires = tokenResult.Value.Expires;

            }
            else if (tokenResult.IsFailed)
            {
                return ToApiResult(tokenResult);
            }

            return ToApiResult(userResult);
        }
    }
}