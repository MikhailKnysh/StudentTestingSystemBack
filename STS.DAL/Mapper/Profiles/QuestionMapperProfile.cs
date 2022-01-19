using AutoMapper;
using STS.Common.Models;
using STS.DAL.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class QuestionMapperProfile : Profile
    {
        public QuestionMapperProfile()
        {
            CreateMapQuestionToQuestionEntity();
            CreateMapQuestionEntityToQuestion();
        }

        private void CreateMapQuestionEntityToQuestion()
        {
            CreateMap<QuestionEntity,Question>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTeacher, opt => opt
                    .MapFrom(src => src.UserId))
                .ForMember(dest => dest.IdTheme, opt => opt
                    .MapFrom(src => src.ThemeId))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title))
                .ForMember(dest => dest.QuestionBody, opt => opt
                    .MapFrom(src => src.Body))
                .ForMember(dest => dest.ImageLink, opt => opt
                    .MapFrom(src => src.PathToImage))
                .ForMember(dest => dest.IsDisabled, opt => opt
                    .MapFrom(src => src.IsLocked))
                .ForMember(dest => dest.LinkForHelp, opt => opt
                    .MapFrom(src => src.LinkForHelp))
                .ForMember(dest => dest.TimeLimit, opt => opt
                    .MapFrom(src => src.TimeLimit))
                .ForMember(dest => dest.Difficulty, opt => opt
                    .MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Type, opt => opt
                    .MapFrom(src => src.Type));
        }

        private void CreateMapQuestionToQuestionEntity()
        {
            CreateMap<Question, QuestionEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt
                    .MapFrom(src => src.IdTeacher))
                .ForMember(dest => dest.ThemeId, opt => opt
                    .MapFrom(src => src.IdTheme))
                .ForMember(dest => dest.Title, opt => opt
                    .MapFrom(src => src.Title))
                .ForMember(dest => dest.Body, opt => opt
                    .MapFrom(src => src.QuestionBody))
                .ForMember(dest => dest.PathToImage, opt => opt
                    .MapFrom(src => src.ImageLink))
                .ForMember(dest => dest.IsLocked, opt => opt
                    .MapFrom(src => src.IsDisabled))
                .ForMember(dest => dest.LinkForHelp, opt => opt
                    .MapFrom(src => src.LinkForHelp))
                .ForMember(dest => dest.TimeLimit, opt => opt
                    .MapFrom(src => src.TimeLimit))
                .ForMember(dest => dest.Difficulty, opt => opt
                    .MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Type, opt => opt
                    .MapFrom(src => src.Type));
        }
    }
}