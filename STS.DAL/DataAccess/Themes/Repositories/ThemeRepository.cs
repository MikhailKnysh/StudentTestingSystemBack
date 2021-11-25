using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using STS.DAL.EntityContext.Context;
using STS.DAL.EntityContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STS.DAL.DataAccess.Themes.Repositories
{
    public class ThemeRepository : BaseRepositoryAbstract<ThemeEntity>, IThemeRepository<ThemeEntity>
    {
        public ThemeRepository(
            ApplicationContext context
        ) : base(context)
        {

        }

        public async Task<List<ThemeEntity>> GetAllBySubjectId(Guid id)
        {
            var result = await _context.Themes
                .Include(t => t.Subject)
                .Where(g => g.SubjectId == id)
                .OrderBy(t => t.Title)
                .ToListAsync();

            return result;
        }
    }
}
