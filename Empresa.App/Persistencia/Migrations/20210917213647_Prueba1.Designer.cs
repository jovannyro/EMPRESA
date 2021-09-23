﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210917213647_Prueba1")]
    partial class Prueba1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CIF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Dominio.Cliente", b =>
                {
                    b.HasBaseType("Dominio.Persona");

                    b.Property<int?>("EsClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("EsClienteId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Dominio.Empleado", b =>
                {
                    b.HasBaseType("Dominio.Persona");

                    b.Property<int?>("EmpleadorId")
                        .HasColumnType("int");

                    b.Property<int>("SueldoBruto")
                        .HasColumnType("int");

                    b.HasIndex("EmpleadorId");

                    b.HasDiscriminator().HasValue("Empleado");
                });

            modelBuilder.Entity("Dominio.Directivo", b =>
                {
                    b.HasBaseType("Dominio.Empleado");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<int?>("DirigeId")
                        .HasColumnType("int");

                    b.Property<int?>("SubordinadoId")
                        .HasColumnType("int");

                    b.HasIndex("DirigeId");

                    b.HasIndex("SubordinadoId");

                    b.HasDiscriminator().HasValue("Directivo");
                });

            modelBuilder.Entity("Dominio.Cliente", b =>
                {
                    b.HasOne("Dominio.Empresa", "EsCliente")
                        .WithMany()
                        .HasForeignKey("EsClienteId");

                    b.Navigation("EsCliente");
                });

            modelBuilder.Entity("Dominio.Empleado", b =>
                {
                    b.HasOne("Dominio.Empresa", "Empleador")
                        .WithMany()
                        .HasForeignKey("EmpleadorId");

                    b.Navigation("Empleador");
                });

            modelBuilder.Entity("Dominio.Directivo", b =>
                {
                    b.HasOne("Dominio.Empresa", "Dirige")
                        .WithMany()
                        .HasForeignKey("DirigeId");

                    b.HasOne("Dominio.Empleado", "Subordinado")
                        .WithMany()
                        .HasForeignKey("SubordinadoId");

                    b.Navigation("Dirige");

                    b.Navigation("Subordinado");
                });
#pragma warning restore 612, 618
        }
    }
}