﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PandC.Models;

#nullable disable

namespace PandC.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230417175649_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PandC.Models.C", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CategoryId");

                    b.ToTable("Cs");
                });

            modelBuilder.Entity("PandC.Models.Join", b =>
                {
                    b.Property<int>("JoinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId1")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId1")
                        .HasColumnType("int");

                    b.HasKey("JoinId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("ProductId1");

                    b.ToTable("Joins");
                });

            modelBuilder.Entity("PandC.Models.P", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductId");

                    b.ToTable("Ps");
                });

            modelBuilder.Entity("PandC.Models.Join", b =>
                {
                    b.HasOne("PandC.Models.C", "C")
                        .WithMany("Joins")
                        .HasForeignKey("CategoryId1");

                    b.HasOne("PandC.Models.P", "P")
                        .WithMany("joins")
                        .HasForeignKey("ProductId1");

                    b.Navigation("C");

                    b.Navigation("P");
                });

            modelBuilder.Entity("PandC.Models.C", b =>
                {
                    b.Navigation("Joins");
                });

            modelBuilder.Entity("PandC.Models.P", b =>
                {
                    b.Navigation("joins");
                });
#pragma warning restore 612, 618
        }
    }
}