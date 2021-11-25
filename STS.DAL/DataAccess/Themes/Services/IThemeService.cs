using Common.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Themes.Services
{
    public interface IThemeService
    {
        Task<Result> CreateAsync(Theme theme);
        Task<Result<List<Theme>>> GetAllBySubjectId(Guid id);
        Task<Result> UpdateAsync(Theme theme);
        Task<Result> DeleteAsync(Guid id);
    }
}
