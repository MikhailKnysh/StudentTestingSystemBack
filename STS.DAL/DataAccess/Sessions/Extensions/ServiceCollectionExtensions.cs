using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Sessions.Services;

namespace STS.DAL.DataAccess.Sessions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSessionService(this IServiceCollection services)
        {
            services.AddTransient<ISessionService, SessionService>();
        }
    }
}