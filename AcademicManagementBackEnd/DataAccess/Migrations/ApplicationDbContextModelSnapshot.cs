﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsStudent");

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

                    b.ToTable("PotentialUser");
                });

            modelBuilder.Entity("Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<Guid>("PotentialUserId");

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Entities.PUserOptionalCourse", b =>
                {
                    b.Property<Guid>("OptionalCourseId");

                    b.Property<Guid>("PotentialUserId");

                    b.HasKey("OptionalCourseId", "PotentialUserId");

                    b.HasIndex("PotentialUserId");

                    b.ToTable("PUserOptionalCourse");
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

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.Professor", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Professor")
                        .HasForeignKey("Entities.Professor", "PotentialUserId")
                        .HasConstraintName("ForeignKey_Professor_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.PUserOptionalCourse", b =>
                {
                    b.HasOne("Entities.Course", "OptionalCourse")
                        .WithMany("PotentialUsers")
                        .HasForeignKey("OptionalCourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithMany("OptionalCourses")
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
