using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using STS.Common.Auth.Models;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;

namespace STS.Common.Auth.Services
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly AuthConfig _authConfig;

        public AuthTokenService(
            IOptions<AuthConfig> authConfigOptions
        )
        {
            _authConfig = authConfigOptions.Value;
        }

        public Result<Token> CreateAuthToken(AuthModelForCreateToken authModel)
        {
            Result<Token> result = Result.Fail(ErrorConstants.SessionErrors.SessionNotCreated);
            if (authModel.Id != Guid.Empty && !string.IsNullOrEmpty(authModel.Role))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var bytes = Encoding.ASCII.GetBytes(_authConfig.Key);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, authModel.Role),
                    new Claim(ClaimTypes.Name, authModel.Id.ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(_authConfig.TokenTimeExpiration),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(bytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result = new Token()
                {
                    Bearer = tokenHandler.WriteToken(token),
                    Expires = _authConfig.TokenTimeExpiration,
                }.CheckEntityNull(ErrorConstants.SessionErrors.SessionNotCreated);
            }

            return result;
        }
    }
}