using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Users.Repositories;
using STS.DAL.DataAccess.Users.Services;

namespace STS.DAL.DataAccess.Users.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUser(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddTransient<IUserService, UserService>();
        }
    }
}