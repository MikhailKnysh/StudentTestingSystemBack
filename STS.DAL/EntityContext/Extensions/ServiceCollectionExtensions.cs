using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.DAL.EntityContext.Context;

namespace STS.DAL.EntityContext.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(
                builder => builder.UseSqlServer(connectionString, 
                    builder => builder.MigrationsAssembly("STS.DAL")), ServiceLifetime.Transient);
        }
    }
}
