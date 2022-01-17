using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Users.Services
{
    public interface IUserService
    {
        Task<Result<User>> GetUserByAuthDataAsync(AuthModel authModel);
        Task<Result> CreateUserAsync(User user);
        Task<Result> DeleteUserAsync(Guid id);
        Task<Result> UpdateUserAsync(User user);
        Task<Result<List<User>>> GetAllUsersByGroupIdAsync(Guid groupId);
        Task<Result<User>> GetUserByIdAsync(Guid id);
        Task<Result> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
        Task<Result<List<User>>> GetStudentsByIdsAsync(List<Guid> students);
    }
}