using System.Linq;
using Microsoft.EntityFrameworkCore;
using STS.DAL.EntityContext.Entitieas;
using STS.DAL.EntityContext.Entities;

namespace STS.DAL.EntityContext.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SubjectEntity> Subjects { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ThemeEntity> Themes { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThemeEntity>(entity =>
            {
                entity.HasOne(t => t.Subject)
                    .WithMany(s => s.Themes)
                    .HasForeignKey(k => k.SubjectId);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasMany(groupEntity => groupEntity.Groups)
                    .WithMany(groupEntity => groupEntity.Users);
            });
        }
    }
}