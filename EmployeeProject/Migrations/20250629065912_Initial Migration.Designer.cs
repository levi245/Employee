﻿// <auto-generated />
using System;
using EmployeeProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeProject.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20250629065912_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("HiredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("EmployeeProject.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("employeeSkills");
                });

            modelBuilder.Entity("EmployeeProject.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("skills");
                });

            modelBuilder.Entity("EmployeeProject.Models.EmployeeSkill", b =>
                {
                    b.HasOne("EmployeeProject.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeProject.Models.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("EmployeeProject.Models.Employee", b =>
                {
                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("EmployeeProject.Models.Skill", b =>
                {
                    b.Navigation("EmployeeSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
