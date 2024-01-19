﻿// <auto-generated />
using CurrencyConverter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyConverter.Migrations
{
    [DbContext(typeof(CurrencyConverterContext))]
    [Migration("20231215104903_initialMigrationMonify")]
    partial class initialMigrationMonify
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("CurrencyConverter.Data.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ConvertibilityIndex")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CurrencyConverter.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Conversions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Plan")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CurrencyConverter.Data.Entities.UserCurrency", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "CurrencyId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("UserCurrencies");
                });

            modelBuilder.Entity("CurrencyConverter.Data.Entities.UserCurrency", b =>
                {
                    b.HasOne("CurrencyConverter.Data.Entities.Currency", "Currency")
                        .WithMany("Users")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CurrencyConverter.Data.Entities.User", "User")
                        .WithMany("Currencies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CurrencyConverter.Data.Entities.Currency", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CurrencyConverter.Data.Entities.User", b =>
                {
                    b.Navigation("Currencies");
                });
#pragma warning restore 612, 618
        }
    }
}