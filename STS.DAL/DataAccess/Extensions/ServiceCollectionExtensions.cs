using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.Common.Cryptography.Extensions;
using STS.Common.Generators.Extensions;
using STS.DAL.DataAccess.Answers.Extensions;
using STS.DAL.DataAccess.AvailableTests.Extensions;
using STS.DAL.DataAccess.Groups.Extensions;
using STS.DAL.DataAccess.Questions.Extensions;
using STS.DAL.DataAccess.Sessions.Extensions;
using STS.DAL.DataAccess.StudentAnswers.Extensions;
using STS.DAL.DataAccess.Subjects.Extensions;
using STS.DAL.DataAccess.Tests.Extensions;
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
            services.AddEncryptor();
            services.AddGenerators();

            services.AddSubject();
            services.AddUser();
            services.AddSessionService();
            services.AddTheme();
            services.AddGroup();
            services.AddAnswer();
            services.AddQuestion();
            services.AddTest();
            services.AddStudentAnswer();
            services.AddAvailableTest();
        }
    }
}