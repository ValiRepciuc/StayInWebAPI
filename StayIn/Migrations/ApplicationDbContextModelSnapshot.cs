﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StayInAPI.Data;

#nullable disable

namespace StayIn.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StayInAPI.Models.Adress", b =>
                {
                    b.Property<int>("AdressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<int>("ZIP")
                        .HasColumnType("int");

                    b.HasKey("AdressId");

                    b.HasIndex("CountryId");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("StayInAPI.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("StayInAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("StayInAPI.Models.Customer_Adress", b =>
                {
                    b.Property<int>("CaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaId"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CaId");

                    b.HasIndex("AdressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Customer_Adress");
                });

            modelBuilder.Entity("StayInAPI.Models.Delivery_Guy", b =>
                {
                    b.Property<int>("DeliveryGuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryGuyId"));

                    b.Property<int>("CNP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("DeliveryGuyId");

                    b.ToTable("Delivery_Guy");
                });

            modelBuilder.Entity("StayInAPI.Models.Menu_Item", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menu_Item");
                });

            modelBuilder.Entity("StayInAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerAdressId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryGuyId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerAdressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryGuyId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("StayInAPI.Models.Order_Menu_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("QtyOrdered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("Order_Menu_Item");
                });

            modelBuilder.Entity("StayInAPI.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.HasIndex("AdressId");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("StayInAPI.Models.Adress", b =>
                {
                    b.HasOne("StayInAPI.Models.Country", "Country")
                        .WithMany("Adress")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("StayInAPI.Models.Customer_Adress", b =>
                {
                    b.HasOne("StayInAPI.Models.Adress", "Adress")
                        .WithMany("Customer_Adress")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StayInAPI.Models.Customer", "Customer")
                        .WithMany("Customer_Adress")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adress");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StayInAPI.Models.Menu_Item", b =>
                {
                    b.HasOne("StayInAPI.Models.Restaurant", "Restaurant")
                        .WithMany("Menu_Item")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("StayInAPI.Models.Order", b =>
                {
                    b.HasOne("StayInAPI.Models.Customer_Adress", "Customer_Adress")
                        .WithMany("Order")
                        .HasForeignKey("CustomerAdressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StayInAPI.Models.Customer", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StayInAPI.Models.Delivery_Guy", "Delivery_Guy")
                        .WithMany("Order")
                        .HasForeignKey("DeliveryGuyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StayInAPI.Models.Restaurant", "Restaurant")
                        .WithMany("Order")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Customer_Adress");

                    b.Navigation("Delivery_Guy");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("StayInAPI.Models.Order_Menu_Item", b =>
                {
                    b.HasOne("StayInAPI.Models.Menu_Item", "Menu_Item")
                        .WithMany("Order_Menu_Item")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StayInAPI.Models.Order", "Order")
                        .WithMany("Order_Menu_Item")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Menu_Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("StayInAPI.Models.Restaurant", b =>
                {
                    b.HasOne("StayInAPI.Models.Adress", "Adress")
                        .WithMany("Restaurant")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("StayInAPI.Models.Adress", b =>
                {
                    b.Navigation("Customer_Adress");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("StayInAPI.Models.Country", b =>
                {
                    b.Navigation("Adress");
                });

            modelBuilder.Entity("StayInAPI.Models.Customer", b =>
                {
                    b.Navigation("Customer_Adress");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("StayInAPI.Models.Customer_Adress", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("StayInAPI.Models.Delivery_Guy", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("StayInAPI.Models.Menu_Item", b =>
                {
                    b.Navigation("Order_Menu_Item");
                });

            modelBuilder.Entity("StayInAPI.Models.Order", b =>
                {
                    b.Navigation("Order_Menu_Item");
                });

            modelBuilder.Entity("StayInAPI.Models.Restaurant", b =>
                {
                    b.Navigation("Menu_Item");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}