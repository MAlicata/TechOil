﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechOil.DataAccess;

#nullable disable

namespace TechOil.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230924221804_techOil2509")]
    partial class techOil2509
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TechOil.Entities.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cod_proyecto");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("direccion");

                    b.Property<int>("EstadoProyecto")
                        .HasColumnType("int")
                        .HasColumnName("estado_proyecto");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nombre");

                    b.HasKey("CodProyecto");

                    b.ToTable("Proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 9,
                            Direccion = "San Miguel de Tucuman",
                            EstadoProyecto = 2,
                            Nombre = "Planta de Gas - Zona 1"
                        });
                });

            modelBuilder.Entity("TechOil.Entities.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cod_servicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("descr");

                    b.Property<int>("EstadoServicio")
                        .HasColumnType("int")
                        .HasColumnName("estado_servicio");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("valor_hora");

                    b.HasKey("CodServicio");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            CodServicio = 5,
                            Descr = "Servicio de Refinamiento de Gas",
                            EstadoServicio = 1,
                            ValorHora = 100m
                        });
                });

            modelBuilder.Entity("TechOil.Entities.Trabajo", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cod_trabajo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("cant_horas");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int")
                        .HasColumnName("cod_proyecto");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int")
                        .HasColumnName("cod_servicio");

                    b.Property<decimal>("Costo")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("costo");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<decimal>("ValorHora")
                        .HasColumnType("Decimal")
                        .HasColumnName("valor_hora");

                    b.HasKey("CodTrabajo");

                    b.HasIndex("CodProyecto");

                    b.HasIndex("CodServicio");

                    b.ToTable("Trabajos");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 2,
                            CantHoras = 20,
                            CodProyecto = 9,
                            CodServicio = 5,
                            Costo = 2000m,
                            Fecha = new DateTime(2023, 9, 24, 19, 18, 4, 526, DateTimeKind.Local).AddTicks(7204),
                            ValorHora = 100m
                        });
                });

            modelBuilder.Entity("TechOil.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cod_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("clave");

                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("usuario_email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("nombre");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.HasKey("CodUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 1,
                            Clave = "588acee9920f023bfe4b60ff2def822ee7612d12f620db6677d637e799315884",
                            Dni = 12345678,
                            Email = "matias@hotmail.com.ar",
                            Nombre = "Matias",
                            Tipo = 1
                        });
                });

            modelBuilder.Entity("TechOil.Entities.Trabajo", b =>
                {
                    b.HasOne("TechOil.Entities.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechOil.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
