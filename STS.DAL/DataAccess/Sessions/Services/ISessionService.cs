using System.Threading.Tasks;
using FluentResults;
using STS.Common.Auth.Models;

namespace STS.DAL.DataAccess.Sessions.Services
{
    public interface ISessionService
    {
        Task<Result<Token>> CreateSession(AuthModel authModel);
    }
}