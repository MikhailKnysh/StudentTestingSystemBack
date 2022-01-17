using AutoMapper;
using Common.Models;
using FluentResults;
using STS.Common.Constans;
using STS.Common.FluentResult.Extensions;
using STS.DAL.DataAccess.Themes.Repositories;
using STS.DAL.EntityContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal;

namespace STS.DAL.DataAccess.Themes.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository<ThemeEntity> _themeRepository;
        private readonly IMapper _mapper;

        public ThemeService(
            IThemeRepository<ThemeEntity> themeRepository,
            IMapper mapper
        )
        {
            _themeRepository = themeRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Theme theme)
        {
            var themeEntity = _mapper.Map<ThemeEntity>(theme);
            themeEntity.Id = Guid.NewGuid();
            themeEntity.Subject = null;

            var responseDb = await _themeRepository.CreateAsync(themeEntity);

            return responseDb.CheckDbResponse(ErrorConstants.ThemeErrors.ThemeNotCreated);
        }

        public async Task<Result<List<Theme>>> GetAllBySubjectId(Guid id)
        {
            var foundedEntities = await _themeRepository.GetAllBySubjectId(id);
            var subjects = _mapper.Map<List<Theme>>(foundedEntities);

            return subjects.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }

        public async Task<Result> UpdateAsync(Theme theme)
        {
            var foundedEntity = await _themeRepository.FindAsync(s => s.Id == theme.Id);
            foundedEntity.Title = theme.Title;
            foundedEntity.SubjectId = theme.SubjectId;
            foundedEntity.Subject = null;

            var responseDb = await _themeRepository.UpdateAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.ThemeErrors.ThemeNotUpdated);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var foundedEntity = await _themeRepository.FindAsync(g => g.Id == id);

            var responseDb = await _themeRepository.DeleteAsync(foundedEntity);

            return responseDb.CheckDbResponse(ErrorConstants.ThemeErrors.ThemeNotDeleted);
        }

        public async Task<Result<Theme>> GetByIdAsync(Guid themeId)
        {
            var themeEntity = await _themeRepository.FindAsync(t => t.Id == themeId);

            var theme = _mapper.Map<Theme>(themeEntity);

            return theme.CheckEntityNull(ErrorConstants.CommonErrors.DataNotFound);
        }
    }
}