using AutoMapper;
using STS.Common.Models;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class GroupMapperProfile : Profile
    {
        public GroupMapperProfile()
        {
            CreateMapGroupEntityToGroup();
            CreateMapGroupToGroupEntity();
        }

        private void CreateMapGroupEntityToGroup()
        {
            CreateMap<GroupEntity, Group>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Name));
        }

        private void CreateMapGroupToGroupEntity()
        {
            CreateMap<Group, GroupEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt
                    .MapFrom(src => src.Title));
        }
    }
}