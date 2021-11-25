using Microsoft.EntityFrameworkCore;
using STS.DAL.EntityContext.Entitieas;

namespace STS.DAL.EntityContext.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=STS;Integrated Security=True;");
            }
        }
    }
}