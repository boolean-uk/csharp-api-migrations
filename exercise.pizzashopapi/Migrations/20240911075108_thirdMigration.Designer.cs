﻿// <auto-generated />
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
    [Migration("20240911075108_thirdMigration")]
    partial class thirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("exercise.pizzashopapi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Princess Peach"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Knuckles Star"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Princess Cheeks"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Luigi Peach"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sandy Daisy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Knuckles Peach"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Knuckles Star"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Spongebob Cheeks"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sandy the Hedgehog"
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customerId");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("pizzaId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("CustomerId", "PizzaId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            PizzaId = 1,
                            Id = 1
                        },
                        new
                        {
                            CustomerId = 2,
                            PizzaId = 2,
                            Id = 2
                        },
                        new
                        {
                            CustomerId = 3,
                            PizzaId = 3,
                            Id = 3
                        },
                        new
                        {
                            CustomerId = 4,
                            PizzaId = 4,
                            Id = 4
                        },
                        new
                        {
                            CustomerId = 5,
                            PizzaId = 5,
                            Id = 5
                        },
                        new
                        {
                            CustomerId = 6,
                            PizzaId = 6,
                            Id = 6
                        },
                        new
                        {
                            CustomerId = 7,
                            PizzaId = 7,
                            Id = 7
                        },
                        new
                        {
                            CustomerId = 8,
                            PizzaId = 8,
                            Id = 8
                        },
                        new
                        {
                            CustomerId = 9,
                            PizzaId = 9,
                            Id = 9
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Grass & Ketchup Pizza",
                            Price = 9m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Grass & Ketchup Pizza",
                            Price = 15m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tomato & Expired Milk Pizza",
                            Price = 17m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tomato & California Reaper Pizza",
                            Price = 15m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Candy & Cheese Pizza",
                            Price = 11m
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mold & Expired Milk Pizza",
                            Price = 9m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cheese & California Reaper Pizza",
                            Price = 18m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tomato & Cheese Pizza",
                            Price = 12m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Grass & Expired Milk Pizza",
                            Price = 18m
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.HasOne("exercise.pizzashopapi.Models.Customer", "Customer")
                        .WithOne("Order")
                        .HasForeignKey("exercise.pizzashopapi.Models.Order", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exercise.pizzashopapi.Models.Pizza", "Pizza")
                        .WithOne("Order")
                        .HasForeignKey("exercise.pizzashopapi.Models.Order", "PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Customer", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Pizza", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
