﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exercise.pizzashopapi.Data;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250203124057_secondMigrations2")]
    partial class secondMigrations2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exercise.pizzashopapi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "John Doe",
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Jane Doe",
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderToppingsId")
                        .HasColumnType("integer");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.OrderToppings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ToppingId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ToppingId");

                    b.ToTable("OrderToppings");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Pepperoni",
                            Price = 10.00m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Cheese",
                            Price = 8.00m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Mushrooms",
                            Price = 9.00m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Pepperoni",
                            Price = 5m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Cheese",
                            Price = 6m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Mushrooms",
                            Price = 7m,
                            UpdatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.HasOne("exercise.pizzashopapi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exercise.pizzashopapi.Models.Pizza", "Pizza")
                        .WithMany("Orders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.OrderToppings", b =>
                {
                    b.HasOne("exercise.pizzashopapi.Models.Order", "Order")
                        .WithMany("OrderToppings")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exercise.pizzashopapi.Models.Topping", "Topping")
                        .WithMany("OrderToppings")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Navigation("OrderToppings");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Pizza", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Topping", b =>
                {
                    b.Navigation("OrderToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
