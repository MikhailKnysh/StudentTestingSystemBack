using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Constans;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Users.Services;

namespace STS.Api.Controllers
{
    [Authorize(Policy = RoleConstants.PolicyConstants.AdminAndTeacherPolicy)]
    public class UserController : RootController
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost("change/password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordModel);

            return ToApiResult(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            var result = await _userService.CreateUserAsync(user);

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            var result = await _userService.DeleteUserAsync(id);

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            var result = await _userService.UpdateUserAsync(user);

            return ToApiResult(result);
        }

        [HttpGet("get/all/group/{id}")]
        public async Task<IActionResult> GetAllUsersByGroupIdAsync(Guid id)
        {
            var result = await _userService.GetAllUsersByGroupIdAsync(id);

            return ToApiResult(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            return ToApiResult(result);
        }
    }
}