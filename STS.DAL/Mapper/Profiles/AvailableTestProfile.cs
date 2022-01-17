using AutoMapper;
using STS.Common.Models;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class AvailableTestProfile : Profile
    {
        public AvailableTestProfile()
        {
            CreateMapAvailableTestToAvailableTestEntity();
            CreateMapAvailableTestEntityToAvailableTest();
        }

        private void CreateMapAvailableTestToAvailableTestEntity()
        {
            CreateMap<AvailableTestEntity, AvailableTest>()
                .ForMember(dest => dest.StudentId, opt => opt
                    .MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Theme, opt => opt
                    .MapFrom(src => src.Theme));
        }

        private void CreateMapAvailableTestEntityToAvailableTest()
        {
            CreateMap<AvailableTest, AvailableTestEntity>()
                .ForMember(dest => dest.StudentId, opt => opt
                    .MapFrom(src => src.StudentId))
                .ForMember(dest => dest.ThemeId, opt => opt
                    .MapFrom(src => src.Theme.Id));
        }
    }
}