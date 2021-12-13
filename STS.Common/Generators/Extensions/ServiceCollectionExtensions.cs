using Microsoft.Extensions.DependencyInjection;
using STS.Common.Generators.Services;

namespace STS.Common.Generators.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGenerators(this IServiceCollection services)
        {
            services.AddTransient<IStringGeneratorService, StringGeneratorService>();
        }
    }
}