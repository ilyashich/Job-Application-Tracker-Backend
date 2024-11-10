﻿// <auto-generated />
using System;
using JobApplicationTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobApplicationTracker.Migrations
{
    [DbContext(typeof(JobApplicationContext))]
    partial class JobApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JobApplicationTracker.Models.JobApplication", b =>
                {
                    b.Property<Guid>("JobApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("ApplicationDate")
                        .HasColumnType("date");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("JobApplicationStatus")
                        .HasColumnType("int");

                    b.Property<string>("JobPostingUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Notes")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("JobApplicationId");

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications");

                    b.HasData(
                        new
                        {
                            JobApplicationId = new Guid("369af106-4c08-437c-8130-1dffdedd0d4c"),
                            ApplicationDate = new DateOnly(2024, 11, 9),
                            CompanyName = "Samsung",
                            JobApplicationStatus = 2,
                            JobPostingUrl = "https://www.samsung.com/careers",
                            JobTitle = "Junior Java Developer",
                            Notes = "Super cool job application",
                            UserId = new Guid("2762580d-543e-4bdf-89bb-f43cc329066e")
                        });
                });

            modelBuilder.Entity("JobApplicationTracker.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("2762580d-543e-4bdf-89bb-f43cc329066e"),
                            Email = "illia@gmail.com",
                            FirstName = "Illia",
                            LastName = "Yatskevich",
                            PasswordHash = "$2a$11$ChChWKfnCukVSfypFdXcsukH9o.VRHn74Gi0BpdrZL0.3AZXrUhmy",
                            UserName = "illia"
                        },
                        new
                        {
                            UserId = new Guid("aaee2115-9e9c-4ac7-972d-8a82dbdb446a"),
                            Email = "alex@gmail.com",
                            FirstName = "Alex",
                            LastName = "Huts",
                            PasswordHash = "$2a$11$aNprsJfhwKeeVpzYolfx8u4YuYnikDIgnkqkeeU3OtsKaIK55Jt1G",
                            UserName = "alex"
                        });
                });

            modelBuilder.Entity("JobApplicationTracker.Models.JobApplication", b =>
                {
                    b.HasOne("JobApplicationTracker.Models.User", "User")
                        .WithMany("JobApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobApplicationTracker.Models.User", b =>
                {
                    b.Navigation("JobApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
