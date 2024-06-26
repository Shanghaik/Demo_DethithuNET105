﻿// <auto-generated />
using System;
using KhanhPG_SE05335.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KhanhPG_SE05335.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KhanhPG_SE05335.Models.Lophoc", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Khoa")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLop");

                    b.ToTable("Lophocs");
                });

            modelBuilder.Entity("KhanhPG_SE05335.Models.Sinhvien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LophocMaLop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nganh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LophocMaLop");

                    b.ToTable("Sinhviens");
                });

            modelBuilder.Entity("KhanhPG_SE05335.Models.Sinhvien", b =>
                {
                    b.HasOne("KhanhPG_SE05335.Models.Lophoc", "Lophoc")
                        .WithMany("Sinhviens")
                        .HasForeignKey("LophocMaLop");

                    b.Navigation("Lophoc");
                });

            modelBuilder.Entity("KhanhPG_SE05335.Models.Lophoc", b =>
                {
                    b.Navigation("Sinhviens");
                });
#pragma warning restore 612, 618
        }
    }
}
