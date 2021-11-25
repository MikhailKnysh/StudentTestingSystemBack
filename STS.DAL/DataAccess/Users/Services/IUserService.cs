using System.Threading.Tasks;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Models;

namespace STS.DAL.DataAccess.Users.Services
{
    public interface IUserService
    {
        Task<Result<User>> GetUserByAuthData(AuthModel authModel);
    }
}