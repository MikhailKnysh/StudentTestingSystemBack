using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Auth.Services;
using STS.Common.Constans;
using STS.DAL.DataAccess.Users.Services;

namespace STS.DAL.DataAccess.Sessions.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUserService _userService;
        private readonly IAuthTokenService _authTokenService;
        private readonly IMapper _mapper;

        public SessionService(
            IUserService userService,
            IAuthTokenService authTokenService,
            IMapper mapper
        )
        {
            _userService = userService;
            _authTokenService = authTokenService;
            _mapper = mapper;
        }

        public async Task<Result<string>> CreateSession(AuthModel authModel)
        {
            Result<string> result = Result.Fail(ErrorConstants.SessionErrors.InvalidAuthData);
            var userResult = await _userService.GetUserByAuthDataAsync(authModel);
            if (userResult.IsSuccess)
            {
                var authModelForCreateToken = _mapper.Map<AuthModelForCreateToken>(userResult.Value);
                result = _authTokenService.CreateAuthToken(authModelForCreateToken);
            }

            return result;
        }
    }
}