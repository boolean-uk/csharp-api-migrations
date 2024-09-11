﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using exercise.pizzashopapi.Data;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nigel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dave"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Felix"
                        });
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer id");

                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("pizza id");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.HasKey("CustomerId", "PizzaId");

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
                            Name = "Cheese & Pineapple",
                            Price = 8m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vegan Cheese Tastic",
                            Price = 2m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kebab & Pommes Frites",
                            Price = 5m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
