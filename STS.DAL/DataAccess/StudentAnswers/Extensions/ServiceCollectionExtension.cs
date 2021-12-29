using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.StudentAnswers.Repositories;
using STS.DAL.DataAccess.StudentAnswers.Services;

namespace STS.DAL.DataAccess.StudentAnswers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddStudentAnswer(this IServiceCollection services)
        {
            services.AddTransient<IStudentAnswerRepository, StudentAnswerRepository>();
            services.AddTransient<IStudentAnswerService, StudentAnswerService>();
        }
    }
}