using Microsoft.AspNetCore.Builder;

namespace STS.Common.Auth.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();
        }
    }
}