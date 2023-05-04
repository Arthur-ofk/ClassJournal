﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace ClassJournal.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230203141507_m2")]
    partial class m2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GroupCourse")
                        .HasMaxLength(60)
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"),
                            GroupCourse = 4,
                            GroupName = "144b"
                        },
                        new
                        {
                            Id = new Guid("5e5d5c0e-1b88-45e4-96c4-059f2db0de95"),
                            GroupCourse = 1,
                            GroupName = "143b"
                        });
                });

            modelBuilder.Entity("Entities.Models.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MarkValue")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Marks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                            CreatedDate = new DateTime(2023, 2, 3, 16, 15, 6, 977, DateTimeKind.Local).AddTicks(7077),
                            MarkValue = 80,
                            StudentId = new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"),
                            SubjectId = new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc")
                        },
                        new
                        {
                            Id = new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                            CreatedDate = new DateTime(2023, 2, 3, 16, 15, 6, 977, DateTimeKind.Local).AddTicks(7110),
                            MarkValue = 90,
                            StudentId = new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"),
                            SubjectId = new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88")
                        });
                });

            modelBuilder.Entity("Entities.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsStateLearning")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentAge")
                        .HasColumnType("int");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"),
                            Adress = "vulytsya pushkina ,dom kolotushkina",
                            Email = "arthauz19@gmail.com",
                            GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"),
                            IsStateLearning = false,
                            PhoneNumber = "380987432010",
                            Role = "leader",
                            StudentAge = 19,
                            StudentName = "Artur"
                        },
                        new
                        {
                            Id = new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"),
                            Adress = "Kobylanska 38",
                            Email = "Bednyy@gmail.com",
                            GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"),
                            IsStateLearning = false,
                            PhoneNumber = "0684739285",
                            Role = "Student",
                            StudentAge = 18,
                            StudentName = "Nazar"
                        },
                        new
                        {
                            Id = new Guid("559c7c64-1532-4780-bfc1-083f85ae6e33"),
                            Adress = "Prospekt",
                            Email = "Andre@gmail.com",
                            GroupId = new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"),
                            IsStateLearning = true,
                            PhoneNumber = "0680952644",
                            Role = "Student",
                            StudentAge = 22,
                            StudentName = "Andrew"
                        });
                });

            modelBuilder.Entity("Entities.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc"),
                            SubjectName = "Math"
                        },
                        new
                        {
                            Id = new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88"),
                            SubjectName = "Programming"
                        });
                });

            modelBuilder.Entity("Entities.Models.Student", b =>
                {
                    b.HasOne("Entities.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Entities.Models.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}