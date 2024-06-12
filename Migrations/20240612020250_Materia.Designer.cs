﻿// <auto-generated />
using System;
using Inscripciones.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inscripciones.Migrations
{
    [DbContext(typeof(InscripcionesContext))]
    [Migration("20240612020250_Materia")]
    partial class Materia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Inscripciones.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoNombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("alumnos");
                });

            modelBuilder.Entity("Inscripciones.Models.AnioCarrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("carreraid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("carreraid");

                    b.ToTable("AnioCarreras");
                });

            modelBuilder.Entity("Inscripciones.Models.Carrera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("carreras");
                });

            modelBuilder.Entity("Inscripciones.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("aniocarreraId")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("aniocarreraId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Inscripciones.Models.inscripciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("alumnosid")
                        .HasColumnType("int");

                    b.Property<int>("carreraid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("alumnosid");

                    b.HasIndex("carreraid");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Inscripciones.Models.AnioCarrera", b =>
                {
                    b.HasOne("Inscripciones.Models.Carrera", "carrera")
                        .WithMany()
                        .HasForeignKey("carreraid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carrera");
                });

            modelBuilder.Entity("Inscripciones.Models.Materia", b =>
                {
                    b.HasOne("Inscripciones.Models.AnioCarrera", "aniocarrera")
                        .WithMany()
                        .HasForeignKey("aniocarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aniocarrera");
                });

            modelBuilder.Entity("Inscripciones.Models.inscripciones", b =>
                {
                    b.HasOne("Inscripciones.Models.Alumno", "alumnos")
                        .WithMany()
                        .HasForeignKey("alumnosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inscripciones.Models.Carrera", "carrera")
                        .WithMany()
                        .HasForeignKey("carreraid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("alumnos");

                    b.Navigation("carrera");
                });
#pragma warning restore 612, 618
        }
    }
}
