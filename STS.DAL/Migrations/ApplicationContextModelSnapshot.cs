﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STS.DAL.EntityContext.Context;

namespace STS.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupEntityUserEntity", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupEntityUserEntity");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entitieas.SubjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entitieas.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.GroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<string>("LinkForHelp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.ThemeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("GroupEntityUserEntity", b =>
                {
                    b.HasOne("STS.DAL.EntityContext.Entities.GroupEntity", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STS.DAL.EntityContext.Entitieas.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.QuestionEntity", b =>
                {
                    b.HasOne("STS.DAL.EntityContext.Entities.ThemeEntity", "Theme")
                        .WithMany("Questions")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STS.DAL.EntityContext.Entitieas.UserEntity", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.ThemeEntity", b =>
                {
                    b.HasOne("STS.DAL.EntityContext.Entitieas.SubjectEntity", "Subject")
                        .WithMany("Themes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entitieas.SubjectEntity", b =>
                {
                    b.Navigation("Themes");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entitieas.UserEntity", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("STS.DAL.EntityContext.Entities.ThemeEntity", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
