using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Sessions.Extensions;
using STS.DAL.DataAccess.Subjects.Extensions;
using STS.DAL.DataAccess.Users.Extensions;
using STS.DAL.DataAccess.Themes.Extension;
using STS.DAL.EntityContext.Extensions;
using STS.DAL.Mapper.Extensions;

namespace STS.DAL.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddAutoMapper();

            services.AddSubject();
            services.AddUser();
            services.AddSessionService();
            services.AddTheme();
        }
    }
}