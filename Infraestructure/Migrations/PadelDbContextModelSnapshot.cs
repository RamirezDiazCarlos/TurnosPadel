﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PadelDbContext))]
    partial class PadelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Domain.Entities.Cancha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClubId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Canchas");
                });

            modelBuilder.Entity("Domain.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CVU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroDeCanchas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clubes");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CanchaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TurnoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.HasIndex("TurnoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BloqueReserva")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CanchaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cupo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CanchaId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PosicionEnCancha")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Cancha", b =>
                {
                    b.HasOne("Domain.Entities.Club", "Club")
                        .WithMany("Canchas")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Domain.Entities.Cancha", "Cancha")
                        .WithMany()
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");

                    b.Navigation("Turno");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.HasOne("Domain.Entities.Cancha", "Cancha")
                        .WithMany("Turnos")
                        .HasForeignKey("CanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cancha");
                });

            modelBuilder.Entity("Domain.Entities.Cancha", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Domain.Entities.Club", b =>
                {
                    b.Navigation("Canchas");
                });
#pragma warning restore 612, 618
        }
    }
}
