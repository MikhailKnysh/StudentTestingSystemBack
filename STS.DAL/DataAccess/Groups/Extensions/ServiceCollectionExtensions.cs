using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Groups.Repositories;
using STS.DAL.DataAccess.Groups.Services;

namespace STS.DAL.DataAccess.Groups.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGroup(this IServiceCollection services)
        {
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();
        }
    }
}