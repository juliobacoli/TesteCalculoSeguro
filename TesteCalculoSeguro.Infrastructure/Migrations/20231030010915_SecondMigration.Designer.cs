﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteCalculoSeguro.Infrastructure.Persistence;

#nullable disable

namespace TesteCalculoSeguro.Infrastructure.Migrations
{
    [DbContext(typeof(SeguroDbContext))]
    [Migration("20231030010915_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Segurado", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeguroId")
                        .HasColumnType("int");

                    b.HasKey("Cpf");

                    b.HasIndex("SeguroId");

                    b.ToTable("Segurado");
                });

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Seguro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Seguro");
                });

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeguroId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SeguroId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Segurado", b =>
                {
                    b.HasOne("TesteCalculoSeguro.Domain.Entities.Seguro", null)
                        .WithMany("Segurado")
                        .HasForeignKey("SeguroId");
                });

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("TesteCalculoSeguro.Domain.Entities.Seguro", null)
                        .WithMany("Veiculo")
                        .HasForeignKey("SeguroId");
                });

            modelBuilder.Entity("TesteCalculoSeguro.Domain.Entities.Seguro", b =>
                {
                    b.Navigation("Segurado");

                    b.Navigation("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}