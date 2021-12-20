using Microsoft.Extensions.DependencyInjection;
using STS.DAL.DataAccess.Questions.Repositories;
using STS.DAL.DataAccess.Questions.Services;

namespace STS.DAL.DataAccess.Questions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddQuestion(this IServiceCollection services)
        {
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IQuestionService, QuestionService>();
        }
    }
}