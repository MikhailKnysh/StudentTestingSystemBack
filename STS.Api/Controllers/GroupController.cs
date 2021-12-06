using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STS.Common.Constans;
using STS.Common.Models;
using STS.Common.RootControllers;
using STS.DAL.DataAccess.Groups.Services;

namespace STS.Api.Controllers
{
    [Authorize(Policy = RoleConstants.PolicyConstants.AdminAndTeacherPolicy)]
    public class GroupController : RootController
    {
        private readonly IGroupService _groupService;

        public GroupController(
            IGroupService groupService,
            ILogger<RootController> logger
        ) : base(logger)
        {
            _groupService = groupService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(Group group)
        {
            var result = await _groupService.CreateAsync(group);

            return ToApiResult(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _groupService.GetAllAsync();

            return ToApiResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _groupService.DeleteAsync(id);

            return ToApiResult(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(Group group)
        {
            var result = await _groupService.UpdateAsync(group);

            return ToApiResult(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddUser(GroupUsers groupUsers)
        {
            var result = await _groupService.AddUsersToGroup(groupUsers);

            return ToApiResult(result);
        }
    }
}