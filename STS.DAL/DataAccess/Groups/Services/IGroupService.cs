using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Groups.Services
{
    public interface IGroupService
    {
        Task<Result> CreateAsync(Group group);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Group group);
        Task<Result<List<Group>>> GetAllAsync();
        Task<Result> AddUsersToGroup(GroupUsers groupUsers);
    }
}