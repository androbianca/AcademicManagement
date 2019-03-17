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
    [Migration("20190317165218_ModifiedTables")]
    partial class ModifiedTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.PotentialUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Photo");

                    b.Property<int>("Semester");

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.Property<int>("Year")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("PotentialUsers");
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
                        .HasMaxLength(40);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<Guid>("PotentialUserId");

                    b.Property<string>("UserCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PotentialUserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.HasOne("Entities.PotentialUser", "PotentialUser")
                        .WithOne("Student")
                        .HasForeignKey("Entities.Student", "PotentialUserId")
                        .HasConstraintName("ForeignKey_User_PotentialUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
