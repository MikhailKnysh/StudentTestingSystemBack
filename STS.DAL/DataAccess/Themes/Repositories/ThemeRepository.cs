using Microsoft.EntityFrameworkCore;
using STS.DAL.DataAccess.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STS.DAL.DBContext;
using STS.DAL.Entities;

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
                .Include(t => t.SubjectEntity)
                .Where(g => g.SubjectId == id)
                .OrderBy(t => t.Title)
                .ToListAsync();

            return result;
        }
    }
}
