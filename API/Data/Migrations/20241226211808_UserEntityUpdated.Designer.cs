﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241226211808_UserEntityUpdated")]
    partial class UserEntityUpdated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("API.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Instruments", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bloomberg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cusip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Exchange")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Isin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MarketCap")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sedol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SubIndustry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instruments");
                });
#pragma warning restore 612, 618
        }
    }
}
