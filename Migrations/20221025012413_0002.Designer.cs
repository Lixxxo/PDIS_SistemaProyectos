﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaProyectos.Database;

#nullable disable

namespace SistemaProyectos.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20221025012413_0002")]
    partial class _0002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaProyectos.Model.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("ntext")
                        .HasColumnName("Name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("Name");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("ntext")
                        .HasColumnName("State");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("ntext")
                        .HasColumnName("Name");

                    b.Property<double>("Progress")
                        .HasColumnType("float")
                        .HasColumnName("Progress");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("ntext")
                        .HasColumnName("State");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("SistemaProyectos.Model.TaskMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("Date")
                        .HasColumnName("Date");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskMaterials");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Task", b =>
                {
                    b.HasOne("SistemaProyectos.Model.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SistemaProyectos.Model.TaskMaterial", b =>
                {
                    b.HasOne("SistemaProyectos.Model.Material", null)
                        .WithMany("TaskMaterials")
                        .HasForeignKey("MaterialId");

                    b.HasOne("SistemaProyectos.Model.Task", null)
                        .WithMany("TaskMaterials")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Material", b =>
                {
                    b.Navigation("TaskMaterials");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("SistemaProyectos.Model.Task", b =>
                {
                    b.Navigation("TaskMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}
