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
    [Migration("20190401163448_OptionalTableCreated")]
    partial class OptionalTableCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("Semester")
                        .HasMaxLength(1);

                    b.Property<int>("Year")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Entities.CourseProfessor", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("ProfessorId");

                    b.Property<Guid?>("OptionalId");

                    b.HasKey("CourseId", "ProfessorId");

                    b.HasIndex("OptionalId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("CourseProfessor");
                });

            modelBuilder.Entity("Entities.Optional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("Semester")
                        .HasMaxLength(1);

                    b.Property<int>("Year")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("Optionals");
                });

            modelBuilder.Entity("Entities.OptionalPotentialUser", b =>
                {
                    b.Property<Guid>("OptionalId");

                    b.Property<Guid>("PotentialUserId");

                    b.HasKey("OptionalId", "PotentialUserId");

                    b.HasIndex("PotentialUserId");

                    b.ToTable("OptionalPotentialUsers");
                });

            modelBuilder.Entity("Entities.PotentialUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Photo");

                    b.Property<int>("Semester")
                        .HasMaxLength(1);

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.Property<int>("Year")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("PotentialUsers");
                });

            modelBuilder.Entity("Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("ProfessorCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<Guid>("PotentialUserId");

                    b.Property<string>("StudentCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.CourseProfessor", b =>
                {
                    b.HasOne("Entities.Professor", "Professor")
                        .WithMany("Courses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Optional")
                        .WithMany("Professors")
                        .HasForeignKey("OptionalId");

                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Professors")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.OptionalPotentialUser", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithMany("Optionals")
                        .HasForeignKey("OptionalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.Optional", "Optional")
                        .WithMany("PotentialUsers")
                        .HasForeignKey("PotentialUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
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
