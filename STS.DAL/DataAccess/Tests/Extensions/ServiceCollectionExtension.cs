using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Tests.Repositories;
using STS.DAL.DataAccess.Tests.Services;

namespace STS.DAL.DataAccess.Tests.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddTest(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestService, TestService>();
        }
    }
}