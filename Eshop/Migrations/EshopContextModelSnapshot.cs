﻿// <auto-generated />
using System;
using Eshop.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eshop.Migrations
{
    [DbContext(typeof(EshopContext))]
    partial class EshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eshop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Eshop.Models.OrderProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Eshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Count")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 23.5,
                            Name = "Product1",
                            Price = 6427.9899999999998
                        },
                        new
                        {
                            Id = 2,
                            Count = 89.0,
                            Name = "Product2",
                            Price = 8159.9899999999998
                        },
                        new
                        {
                            Id = 3,
                            Count = 19.5,
                            Name = "Product3",
                            Price = 142.99000000000001
                        },
                        new
                        {
                            Id = 4,
                            Count = 36.0,
                            Name = "Product4",
                            Price = 5240.9899999999998
                        },
                        new
                        {
                            Id = 5,
                            Count = 11.5,
                            Name = "Product5",
                            Price = 7464.9899999999998
                        },
                        new
                        {
                            Id = 6,
                            Count = 51.0,
                            Name = "Product6",
                            Price = 9961.9899999999998
                        },
                        new
                        {
                            Id = 7,
                            Count = 7.5,
                            Name = "Product7",
                            Price = 3876.9899999999998
                        },
                        new
                        {
                            Id = 8,
                            Count = 73.0,
                            Name = "Product8",
                            Price = 5562.9899999999998
                        },
                        new
                        {
                            Id = 9,
                            Count = 19.5,
                            Name = "Product9",
                            Price = 9361.9899999999998
                        },
                        new
                        {
                            Id = 10,
                            Count = 66.0,
                            Name = "Product10",
                            Price = 9730.9899999999998
                        });
                });

            modelBuilder.Entity("Eshop.Models.OrderProduct", b =>
                {
                    b.HasOne("Eshop.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eshop.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Eshop.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Eshop.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
