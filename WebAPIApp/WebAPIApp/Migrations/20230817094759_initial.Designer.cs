﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIApp.Models;

namespace WebAPIApp.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20230817094759_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("WebAPIApp.Models.Disk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FreeSpace")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int?>("PCId")
                        .HasColumnType("int");

                    b.Property<decimal>("VolumeSize")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("PCId");

                    b.ToTable("Disk");
                });

            modelBuilder.Entity("WebAPIApp.Models.PC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PcItems")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PCs");
                });

            modelBuilder.Entity("WebAPIApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPIApp.Models.Disk", b =>
                {
                    b.HasOne("WebAPIApp.Models.PC", null)
                        .WithMany("Disks")
                        .HasForeignKey("PCId");
                });

            modelBuilder.Entity("WebAPIApp.Models.PC", b =>
                {
                    b.Navigation("Disks");
                });
#pragma warning restore 612, 618
        }
    }
}