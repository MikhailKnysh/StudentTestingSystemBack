using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using STS.Common.SMTP.Models;
using STS.Common.SMTP.Service;

namespace STS.Common.SMTP.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMailSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpConfig>(configuration.GetSection(nameof(SmtpConfig)));
            services.AddTransient<IMailSenderService, MailSenderService>();
        }
    }
}