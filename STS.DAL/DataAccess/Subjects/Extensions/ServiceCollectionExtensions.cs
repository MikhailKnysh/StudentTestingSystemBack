using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Subjects.Repositories;
using STS.DAL.DataAccess.Subjects.Services;

namespace STS.DAL.DataAccess.Subjects.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSubject(this IServiceCollection services)
        {
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectService, SubjectService>();
        }
    }
}