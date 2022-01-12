using FluentResults;
using STS.Common.Auth.Models;

namespace STS.Common.Auth.Services
{
    public interface IAuthTokenService
    {
        Result<Token> CreateAuthToken(AuthModelForCreateToken authModel);
    }
}