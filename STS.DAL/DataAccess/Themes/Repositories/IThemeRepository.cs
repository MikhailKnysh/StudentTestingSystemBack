using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Themes.Repositories
{
    public interface IThemeRepository<T> : IBaseRepository<T>
    {
        Task<List<ThemeEntity>> GetAllBySubjectId(Guid id);
    }
}
