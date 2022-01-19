using STS.DAL.DataAccess.BaseRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using STS.DAL.Entities;

namespace STS.DAL.DataAccess.Themes.Repositories
{
    public interface IThemeRepository<T> : IBaseRepository<T>
    {
        Task<List<ThemeEntity>> GetAllBySubjectId(Guid id);
    }
}
