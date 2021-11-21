using Microsoft.EntityFrameworkCore;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Context
{
    public class AppContext : DbContext
    {
        public DbSet<SubjectEntity> Subjects { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
