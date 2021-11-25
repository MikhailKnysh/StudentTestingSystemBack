using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Themes.Repositories;
using STS.DAL.DataAccess.Themes.Services;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.DataAccess.Themes.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTheme(this IServiceCollection services)
        {
            services.AddScoped<IThemeRepository<ThemeEntity>, ThemeRepository>();
            services.AddScoped<IThemeService, ThemeService>();
        }
    }
}
