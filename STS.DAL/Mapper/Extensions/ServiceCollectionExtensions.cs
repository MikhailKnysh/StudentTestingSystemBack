using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using STS.DAL.Mapper.Profiles;

namespace STS.DAL.Mapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SubjectMapperProfile());
                mc.AddProfile(new UserMapperProfile());
                mc.AddProfile(new ThemeMapperProfile());
                mc.AddProfile(new GroupMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}