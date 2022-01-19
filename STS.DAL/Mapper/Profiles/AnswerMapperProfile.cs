using AutoMapper;
using STS.Common.Models;
using STS.DAL.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class AnswerMapperProfile : Profile
    {
        public AnswerMapperProfile()
        {
            CreateMapAnswerEntityToAnswer();
            CreateMapAnswerToAnswerEntity();
        }

        private void CreateMapAnswerEntityToAnswer()
        {
            CreateMap<AnswerEntity, Answer>()
                .ForMember(dest => dest.ID, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.Body, opt => opt
                    .MapFrom(src => src.Body))
                .ForMember(dest => dest.IdQuestion, opt => opt
                    .MapFrom(src => src.IdQuestion))
                .ForMember(dest => dest.IsCorrect, opt => opt
                    .MapFrom(src => src.IsCorrect));
        }

        private void CreateMapAnswerToAnswerEntity()
        {
            CreateMap<Answer, AnswerEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.ID))
                .ForMember(dest => dest.Body, opt => opt
                    .MapFrom(src => src.Body))
                .ForMember(dest => dest.IdQuestion, opt => opt
                    .MapFrom(src => src.IdQuestion))
                .ForMember(dest => dest.IsCorrect, opt => opt
                    .MapFrom(src => src.IsCorrect));
        }
    }
}