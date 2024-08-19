﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurricolumId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("InitialDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CurricolumId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Core.Entities.Curricolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("SalaryExpectation")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("SchoolLevel")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Curricolums");
                });

            modelBuilder.Entity("Core.Entities.ProfessionalExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("longtext");

                    b.Property<int>("CurricolumId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("InitialDate")
                        .HasColumnType("date");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CurricolumId");

                    b.ToTable("ProfessionalExperiences");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Document")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Course", b =>
                {
                    b.HasOne("Core.Entities.Curricolum", "Curricolum")
                        .WithMany("Courses")
                        .HasForeignKey("CurricolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curricolum");
                });

            modelBuilder.Entity("Core.Entities.Curricolum", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany("Curricolums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.ProfessionalExperience", b =>
                {
                    b.HasOne("Core.Entities.Curricolum", "Curricolum")
                        .WithMany("ProfessionalExperience")
                        .HasForeignKey("CurricolumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curricolum");
                });

            modelBuilder.Entity("Core.Entities.Curricolum", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("ProfessionalExperience");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Navigation("Curricolums");
                });
#pragma warning restore 612, 618
        }
    }
}
