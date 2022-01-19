using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using STS.DAL.Entities;

#nullable disable

namespace STS.DAL.DBContext
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnswerEntity> Answers { get; set; }
        public virtual DbSet<AvailableTestEntity> AvailableTests { get; set; }
        public virtual DbSet<GroupEntity> Groups { get; set; }
        public virtual DbSet<GroupEntityUserEntity> GroupEntityUserEntities { get; set; }
        public virtual DbSet<QuestionEntity> Questions { get; set; }
        public virtual DbSet<StudentAnswerEntity> StudentAnswers { get; set; }
        public virtual DbSet<SubjectEntity> Subjects { get; set; }
        public virtual DbSet<TestEntity> Tests { get; set; }
        public virtual DbSet<ThemeEntity> Themes { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:stsapplicationsqlserver.database.windows.net,1433;Initial Catalog=STS;User ID=stsapplicationsqlserver-admin;Password=360OYYD32LSFP13G$;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnswerEntity>(entity =>
            {
                entity.HasIndex(e => e.IdQuestion, "IX_Answers_Id_Question");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdQuestion).HasColumnName("Id_Question");

                entity.HasOne(d => d.IdQuestionEntityNavigation)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.IdQuestion);
            });

            modelBuilder.Entity<AvailableTestEntity>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_AvailableTests_StudentId");

                entity.HasIndex(e => e.ThemeId, "IX_AvailableTests_ThemeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AvailableTests)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ThemeEntity)
                    .WithMany(p => p.AvailableTests)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<GroupEntityUserEntity>(entity =>
            {
                entity.HasKey(e => new { e.GroupsId, e.UsersId });

                entity.ToTable("GroupEntityUserEntity");

                entity.HasIndex(e => e.UsersId, "IX_GroupEntityUserEntity_UsersId");

                entity.HasOne(d => d.GroupsEntity)
                    .WithMany(p => p.GroupEntityUserEntities)
                    .HasForeignKey(d => d.GroupsId);

                entity.HasOne(d => d.UsersEntity)
                    .WithMany(p => p.GroupEntityUserEntities)
                    .HasForeignKey(d => d.UsersId);
            });

            modelBuilder.Entity<QuestionEntity>(entity =>
            {
                entity.HasIndex(e => e.ThemeId, "IX_Questions_ThemeId");

                entity.HasIndex(e => e.UserId, "IX_Questions_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ThemeEntity)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ThemeId);

                entity.HasOne(d => d.UserEntity)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<StudentAnswerEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AnswerEntity)
                    .WithMany(p => p.StudentAnswers)
                    .HasForeignKey(d => d.AnswerId);

                entity.HasOne(d => d.QuestionEntity)
                    .WithMany(p => p.StudentAnswers)
                    .HasForeignKey(d => d.QuestionId);
            });

            modelBuilder.Entity<SubjectEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TestEntity>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Tests_StudentId");

                entity.HasIndex(e => e.ThemeId, "IX_Tests_ThemeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.ThemeEntity)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ThemeId);
            });

            modelBuilder.Entity<ThemeEntity>(entity =>
            {
                entity.HasIndex(e => e.SubjectId, "IX_Themes_SubjectId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SubjectEntity)
                    .WithMany(p => p.Themes)
                    .HasForeignKey(d => d.SubjectId);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
