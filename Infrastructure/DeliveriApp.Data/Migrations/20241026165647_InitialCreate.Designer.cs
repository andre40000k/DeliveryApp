﻿// <auto-generated />
using System;
using DeliveriApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeliveriApp.Data.Migrations
{
    [DbContext(typeof(DeliveryContext))]
    [Migration("20241026165647_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("DeliveriApp.Domein.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeliveriTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("OrderWeight")
                        .HasColumnType("REAL");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxDistanceFromCafe")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinDistanceFromCafe")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.Order", b =>
                {
                    b.HasOne("DeliveriApp.Domein.Entities.Region", "Region")
                        .WithMany("Orders")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.Region", b =>
                {
                    b.HasOne("DeliveriApp.Domein.Entities.City", "City")
                        .WithMany("Regions")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.City", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("DeliveriApp.Domein.Entities.Region", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
