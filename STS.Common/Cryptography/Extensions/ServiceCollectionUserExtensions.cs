using Microsoft.Extensions.DependencyInjection;
using STS.Common.Cryptography.Services;

namespace STS.Common.Cryptography.Extensions
{
    public static class ServiceCollectionUserExtensions
    {
        public static void AddEncryptor(this IServiceCollection services)
        {
            services.AddTransient<IEncryptorService, EncryptorService>();
        }
    }
}