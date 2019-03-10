﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MooreMarket.Data;

namespace MooreMarket.Migrations
{
    [DbContext(typeof(MooreMarketContext))]
    [Migration("20190310191735_AddMarkets")]
    partial class AddMarkets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MooreMarket.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("MooreMarket.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<int>("IsPerishable");

                    b.Property<int>("KeepFreezer");

                    b.Property<int>("KeepFridge");

                    b.Property<int>("KeepRoom");

                    b.Property<string>("Name");

                    b.Property<float>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("ShelfLifeFreezer");

                    b.Property<string>("ShelfLifeFridge");

                    b.Property<string>("ShelfLifeRoom");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MooreMarket.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MooreMarket.Models.UserMarket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MarketId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMarkets");
                });

            modelBuilder.Entity("MooreMarket.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountType");

                    b.Property<string>("Email");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MooreMarket.Models.VendorMarket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MarketId");

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.HasIndex("VendorId");

                    b.ToTable("VendorMarkets");
                });

            modelBuilder.Entity("MooreMarket.Models.Product", b =>
                {
                    b.HasOne("MooreMarket.Models.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MooreMarket.Models.UserModel", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MooreMarket.Models.UserMarket", b =>
                {
                    b.HasOne("MooreMarket.Models.Market", "Market")
                        .WithMany("UserMarkets")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MooreMarket.Models.UserModel", "User")
                        .WithMany("UserMarkets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MooreMarket.Models.VendorMarket", b =>
                {
                    b.HasOne("MooreMarket.Models.Market", "Market")
                        .WithMany("VendorMarkets")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MooreMarket.Models.UserModel", "Vendor")
                        .WithMany("VendorMarkets")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}