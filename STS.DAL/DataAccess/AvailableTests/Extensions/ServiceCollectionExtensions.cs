using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.AvailableTests.Repositories;
using STS.DAL.DataAccess.AvailableTests.Sevices;

namespace STS.DAL.DataAccess.AvailableTests.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAvailableTest(this IServiceCollection services)
        {
            services.AddTransient<IAvailableTestRepository, AvailableTestRepository>();
            services.AddTransient<IAvailableTestService, AvailableTestService>();
        }
    }
}