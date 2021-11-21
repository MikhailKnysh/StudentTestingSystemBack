using Microsoft.EntityFrameworkCore;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Context
{
    public class SubjectContext : DbContext
    {
        public DbSet<SubjectEntity> Subjects { get; set; }

        public SubjectContext(DbContextOptions options) : base(options)
        {
        }
    }
}
