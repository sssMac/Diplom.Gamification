﻿// <auto-generated />
using System;
using Diplom.Gamification.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Diplom.Gamification.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240302205323_AddFKUser")]
    partial class AddFKUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Diplom.Gamification.Domain.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateEarned")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Tests")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5132),
                            Description = "Complete the exercises from Chapter 5.",
                            LessonId = new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                            Title = "Basics of C#"
                        },
                        new
                        {
                            Id = new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5135),
                            Description = "Write a program to implement the sorting algorithm discussed in class.",
                            LessonId = new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                            Title = "Advanced Concepts"
                        },
                        new
                        {
                            Id = new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5137),
                            Description = "Complete the exercises from Chapter 4.",
                            LessonId = new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                            Title = "Parallel Programming"
                        });
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6034),
                            CreatedBy = "Emily Johnson",
                            Description = "Learn the basics of C# programming language.",
                            Level = 1,
                            Title = "Introduction to C#"
                        },
                        new
                        {
                            Id = new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6037),
                            CreatedBy = "John Smith",
                            Description = "Explore advanced topics in C# programming.",
                            Level = 2,
                            Title = "Advanced C#"
                        });
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Forum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                            Content = "This lesson covers basic syntax and concepts of C#.",
                            CourseId = new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6553),
                            Title = "Basics of C#"
                        },
                        new
                        {
                            Id = new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                            Content = "This lesson explores advanced features of C#.",
                            CourseId = new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6555),
                            Title = "Advanced Concepts"
                        },
                        new
                        {
                            Id = new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                            Content = "Learn how to write parallel programs in C#.",
                            CourseId = new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                            CreatedAt = new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6557),
                            Title = "Parallel Programming"
                        });
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ForumId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Diplom.Gamification.Shared.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cec91ee6-ea68-44b5-aec4-c65ddd91c508",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEDrnIKwtumrk/jsWN+1N3F8rfc/Rw68nzNMkXoMajxZvU6JsstArVvJgsKB9NGlraw==",
                            PhoneNumberConfirmed = false,
                            Rating = 99,
                            SecurityStamp = "591fdb84-fba0-4b43-89a3-f5d0de9f7315",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "03476e34-e1eb-49e1-8eaf-73ec2424415e",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3b87c435-a7e9-4165-9eb4-4068f652d39b",
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = "a10af09f-cfea-42b6-906e-5e1fec9de544",
                            Name = "Creator",
                            NormalizedName = "CREATOR"
                        },
                        new
                        {
                            Id = "6f6c5cf9-9785-4a0b-8e87-710d5bbb44bf",
                            Name = "Basic",
                            NormalizedName = "BASIC"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                            RoleId = "03476e34-e1eb-49e1-8eaf-73ec2424415e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Achievement", b =>
                {
                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Assignment", b =>
                {
                    b.HasOne("Diplom.Gamification.Domain.Lesson", null)
                        .WithOne("Assignments")
                        .HasForeignKey("Diplom.Gamification.Domain.Assignment", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Forum", b =>
                {
                    b.HasOne("Diplom.Gamification.Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Lesson", b =>
                {
                    b.HasOne("Diplom.Gamification.Domain.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Message", b =>
                {
                    b.HasOne("Diplom.Gamification.Domain.Forum", "Forum")
                        .WithMany("Messages")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Forum");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Diplom.Gamification.Shared.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Forum", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Diplom.Gamification.Domain.Lesson", b =>
                {
                    b.Navigation("Assignments")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
