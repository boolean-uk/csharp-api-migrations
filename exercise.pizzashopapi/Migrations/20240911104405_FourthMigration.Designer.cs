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
    [Migration("20240911104405_FourthMigration")]
    partial class FourthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
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
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("piiza_id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.HasKey("PizzaId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders");
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
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.HasOne("exercise.pizzashopapi.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
