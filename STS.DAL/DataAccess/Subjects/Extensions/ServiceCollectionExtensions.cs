using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Subjects.Repositories;
using STS.DAL.DataAccess.Subjects.Services.Subjects;
using STS.DAL.EntityContext.Entitieas;
using STS.DAL.Interfaces;

namespace STS.DAL.DataAccess.Subjects.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSubject(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository<SubjectEntity>, SubjectRepository>();
        }
    }
}
