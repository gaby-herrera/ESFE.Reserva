using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.DAL;

public partial class DbHotelContext : DbContext
{
    public DbHotelContext()
    {
    }

    public DbHotelContext(DbContextOptions<DbHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoH> EstadoHs { get; set; }

    public virtual DbSet<EstadoR> EstadoRs { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<ReservaEN> Reservas { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Temporadum> Temporada { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642494E1DCA");

            entity.ToTable("Cliente");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoH>(entity =>
        {
            entity.HasKey(e => e.IdEstadoH).HasName("PK__EstadoH__C7C71E797F3DE374");

            entity.ToTable("EstadoH");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoR>(entity =>
        {
            entity.HasKey(e => e.IdEstadoR).HasName("PK__EstadoR__C7C71E03ED16A923");

            entity.ToTable("EstadoR");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF90152DA0553");

            entity.ToTable("Habitacion");

            entity.HasOne(d => d.IdEstadoHNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdEstadoH)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdEst__46E78A0C");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdTip__45F365D3");
        });

        modelBuilder.Entity<ReservaEN>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__0E49C69D658D3B39");

            entity.ToTable("Reserva");

            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdClien__47DBAE45");

            entity.HasOne(d => d.IdEstadoRNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdEstadoR)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdEstad__49C3F6B7");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdHabit__48CFD27E");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdTarif__4AB81AF0");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa).HasName("PK__Tarifa__78F1A91D0FC6C989");

            entity.ToTable("Tarifa");

            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Temporada)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTemporadaNavigation).WithMany(p => p.Tarifas)
                .HasForeignKey(d => d.IdTemporada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarifa__IdTempor__4BAC3F29");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Tarifas)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarifa__IdTipoHa__44FF419A");
        });

        modelBuilder.Entity<Temporadum>(entity =>
        {
            entity.HasKey(e => e.IdTemporada).HasName("PK__Temporad__80F41821C98DD6DE");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__AB75E87CFB493263");

            entity.ToTable("TipoHabitacion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
