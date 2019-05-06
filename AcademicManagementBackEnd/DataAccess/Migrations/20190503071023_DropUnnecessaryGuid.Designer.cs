﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190503071023_DropUnnecessaryGuid")]
    partial class DropUnnecessaryGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<Guid>("PotentialUserId");

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid>("PotentialUserId");

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Package")
                        .HasMaxLength(5);

                    b.Property<int>("Semester")
                        .HasMaxLength(1);

                    b.Property<int>("Year")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Entities.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("ProfId");

                    b.Property<Guid>("StudentId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ProfId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Entities.PotentialUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.Property<Guid>("UserRoleId");

                    b.HasKey("Id");

                    b.ToTable("PotentialUsers");
                });

            modelBuilder.Entity("Entities.ProfCourse", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("ProfId");

                    b.HasKey("CourseId", "ProfId");

                    b.HasIndex("ProfId");

                    b.ToTable("ProfCourse");
                });

            modelBuilder.Entity("Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid>("PotentialUserId");

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Entities.ProfGroup", b =>
                {
                    b.Property<Guid>("ProfId");

                    b.Property<Guid>("GroupId");

                    b.HasKey("ProfId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("ProfGroup");
                });

            modelBuilder.Entity("Entities.ProfRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("ProfRole");
                });

            modelBuilder.Entity("Entities.ProfStuds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("GroupId");

                    b.Property<Guid>("ProfId");

                    b.HasKey("Id");

                    b.ToTable("ProfStuds");
                });

            modelBuilder.Entity("Entities.StudCourse", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("StudId");

                    b.HasKey("CourseId", "StudId");

                    b.HasIndex("StudId");

                    b.ToTable("StudCourse");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<Guid>("GroupId");

                    b.Property<string>("LastName");

                    b.Property<Guid>("PotentialUserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Entities.Account", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Account")
                        .HasForeignKey("Entities.Account", "PotentialUserId")
                        .HasConstraintName("ForeignKey_Account_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Admin", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Admin")
                        .HasForeignKey("Entities.Admin", "PotentialUserId")
                        .HasConstraintName("ForeignKey_Admin_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Grade", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("ForeignKey_Course_Grade")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Professor", "Professor")
                        .WithMany("Grades")
                        .HasForeignKey("ProfId")
                        .HasConstraintName("ForeignKey_Prof_Grade")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("ForeignKey_Student_Grade")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ProfCourse", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Profs")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Professor", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("ProfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Professor", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Professor")
                        .HasForeignKey("Entities.Professor", "PotentialUserId")
                        .HasConstraintName("ForeignKey_Professor_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.ProfGroup", b =>
                {
                    b.HasOne("Entities.Group", "Group")
                        .WithMany("Profs")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Professor", "Professor")
                        .WithMany("Groups")
                        .HasForeignKey("ProfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.StudCourse", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Studs")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.HasOne("Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("ForeignKey_Student_Group")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Student")
                        .HasForeignKey("Entities.Student", "PotentialUserId")
                        .HasConstraintName("ForeignKey_Student_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
