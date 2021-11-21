using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Subjects.Extensions;
using STS.DAL.EntityContext.Extensions;

namespace STS.DAL.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddSubject();
        }
    }
}
