using System;
using AutoMapper;
using STS.Common.Models;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.Mapper.Profiles
{
    public class StudentAnswerProfile : Profile
    {
        public StudentAnswerProfile()
        {
            CreateMapStudentAnswerLightToStudentAnswerEntity();
        }

        private void CreateMapStudentAnswerLightToStudentAnswerEntity()
        {
            CreateMap<StudentAnswerLight, StudentAnswerEntity>()
                .ForMember(dest => dest.Id, opt => opt
                    .MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.QuestionId, opt => opt
                    .MapFrom(src => src.QuestionId))
                .ForMember(dest => dest.AnswerId, opt => opt
                    .MapFrom(src => src.AnswerId))
                .ForMember(dest => dest.StudentId, opt => opt
                    .MapFrom(src => src.StudentId))
                .ForMember(dest => dest.AnswerDuration, opt => opt
                    .MapFrom(src => src.TimeDuration));
        }
    }
}