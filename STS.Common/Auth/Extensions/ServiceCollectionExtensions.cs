using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using STS.Common.Auth.Models;
using STS.Common.Auth.Services;
using STS.Common.Constans;

namespace STS.Common.Auth.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuth(configuration);

            services.AddAuthorizationsPolicy();

            services.Configure<AuthConfig>(configuration.GetSection(nameof(AuthConfig)));

            services.AddTransient<IAuthTokenService, AuthTokenService>();
        }

        private static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var authConfig = configuration.GetSection(nameof(AuthConfig)).Get<AuthConfig>();
            var key = Encoding.ASCII.GetBytes(authConfig.Key);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        private static void AddAuthorizationsPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleConstants.PolicyConstants.AdminPolicy,
                    policy => policy.RequireRole(RoleConstants.Admin));
                options.AddPolicy(RoleConstants.PolicyConstants.AdminAndTeacherPolicy,
                    policy => policy.RequireRole(RoleConstants.Teacher, RoleConstants.Admin));
                options.AddPolicy(RoleConstants.PolicyConstants.CommonPolicy,
                    policy => policy.RequireRole(RoleConstants.Teacher, RoleConstants.Admin, RoleConstants.Admin));
            });
        }
    }
}