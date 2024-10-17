﻿// <auto-generated />
using System;
using CMS.DBServices.Dbcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMS.DBServices.Migrations
{
    [DbContext(typeof(CMSAppDBContext))]
    [Migration("20241017162508_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CMS.Models.Courier", b =>
                {
                    b.Property<int>("CourierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourierID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourierId"), 1L, 1);

                    b.Property<string>("CourierName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CourierId");

                    b.ToTable("Courier", (string)null);
                });

            modelBuilder.Entity("CMS.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("CMS.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"), 1L, 1);

                    b.Property<string>("RouteName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("CMS.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentId"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("ShipmentAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ShipmentPrice")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<double>("ShipmentWeight")
                        .HasColumnType("float");

                    b.Property<int>("VendorId")
                        .HasColumnType("int")
                        .HasColumnName("VendorID");

                    b.HasKey("ShipmentId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("CMS.Models.ShipmentsBooked", b =>
                {
                    b.Property<int>("ShipmentBookedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShipmentBookedID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentBookedId"), 1L, 1);

                    b.Property<int>("CourierId")
                        .HasColumnType("int")
                        .HasColumnName("CourierID");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int")
                        .HasColumnName("ShipmentID");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    b.HasKey("ShipmentBookedId")
                        .HasName("PK__Shipment__D2CB3F41C3C0A7C1");

                    b.ToTable("ShipmentsBooked", (string)null);
                });

            modelBuilder.Entity("CMS.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("CMS.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CMS.Models.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VendorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VendorAddress")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("VendorEmail")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("VendorId");

                    b.HasIndex(new[] { "UserId" }, "UQ__Vendors__1788CC4D656BF494")
                        .IsUnique();

                    b.HasIndex(new[] { "VendorEmail" }, "UQ__Vendors__F0E72A773491B1DB")
                        .IsUnique();

                    b.ToTable("Vendors");
                });
#pragma warning restore 612, 618
        }
    }
}
