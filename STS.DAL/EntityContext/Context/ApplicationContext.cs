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
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<StudentAnswerEntity> StudentAnswers { get; set; }

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
                optionsBuilder.UseSqlServer(
                    "Server=tcp:stsapplicationsqlserver.database.windows.net,1433;Initial Catalog=STS;Persist Security Info=False;User ID=stsapplicationsqlserver-admin;Password=360OYYD32LSFP13G$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThemeEntity>(entity =>
            {
                entity.HasOne(themeEntity => themeEntity.Subject)
                    .WithMany(subjectEntity => subjectEntity.Themes)
                    .HasForeignKey(themeEntity => themeEntity.SubjectId);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasMany(groupEntity => groupEntity.Groups)
                    .WithMany(groupEntity => groupEntity.Users);
            });

            modelBuilder.Entity<QuestionEntity>(entity =>
            {
                entity.HasOne(questionEntity => questionEntity.User)
                    .WithMany(userEntity => userEntity.Questions)
                    .HasForeignKey(questionEntity => questionEntity.UserId);

                entity.HasOne(questionEntity => questionEntity.Theme)
                    .WithMany(themeEntity => themeEntity.Questions)
                    .HasForeignKey(questionEntity => questionEntity.ThemeId);
                entity.HasMany(questionEntity => questionEntity.Answers)
                    .WithOne(answerEntity => answerEntity.Question)
                    .HasForeignKey(answerEntity => answerEntity.Id_Question);
            });
            modelBuilder.Entity<TestEntity>(entity =>
            {
                entity.HasMany(testEntity => testEntity.Answers)
                    .WithOne(studentAnswerEntity => studentAnswerEntity.Test)
                    .HasForeignKey(studentAnswerEntity => studentAnswerEntity.TestId);

                entity.HasOne(testEntity => testEntity.Theme);

                entity.HasOne(testEntity => testEntity.Student)
                    .WithMany(userEntity => userEntity.Tests);
            });
        }
    }
}