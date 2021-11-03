﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Repositories;

namespace WebAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211103103825_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("UserTitleId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTitleId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "george@example.com",
                            IsActive = true,
                            Name = "George",
                            Surname = "GeorgeSurname",
                            UserTitleId = 1,
                            UserTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "nikos@example.com",
                            IsActive = true,
                            Name = "Nikos",
                            Surname = "NikosSurname",
                            UserTitleId = 2,
                            UserTypeId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Domain.UserTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("UserTitle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "description1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "description2"
                        });
                });

            modelBuilder.Entity("WebAPI.Domain.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("UserType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "a",
                            Description = "description1"
                        },
                        new
                        {
                            Id = 2,
                            Code = "b",
                            Description = "description2"
                        });
                });

            modelBuilder.Entity("WebAPI.Domain.User", b =>
                {
                    b.HasOne("WebAPI.Domain.UserTitle", "UserTitle")
                        .WithMany("User")
                        .HasForeignKey("UserTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Domain.UserType", "UserType")
                        .WithMany("User")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}