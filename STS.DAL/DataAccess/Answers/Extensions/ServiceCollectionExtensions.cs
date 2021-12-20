using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Answers.Repositories;
using STS.DAL.DataAccess.Answers.Services;

namespace STS.DAL.DataAccess.Answers.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAnswer(this IServiceCollection services)
        {
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IAnswerService, AnswerService>();
        }
    }
}