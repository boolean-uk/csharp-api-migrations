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
    [Migration("20240912121232_SecondMigration")]
    partial class SecondMigration
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
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("integer")
                        .HasColumnName("PizzaId");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("CustomerId");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("OrderId");

                    b.HasKey("PizzaId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("exercise.pizzashopapi.Models.Order", b =>
                {
                    b.HasOne("exercise.pizzashopapi.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exercise.pizzashopapi.Models.Pizza", "pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("pizza");
                });
#pragma warning restore 612, 618
        }
    }
}
