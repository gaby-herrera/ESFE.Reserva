using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.DAL.DataContext;

public partial class DbHotelSystemContext : DbContext
{
    public DbHotelSystemContext()
    {
    }

    public DbHotelSystemContext(DbContextOptions<DbHotelSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoH> EstadoHs { get; set; }

    public virtual DbSet<EstadoR> EstadoRs { get; set; }

    public virtual DbSet<EN.Habitacion> Habitacions { get; set; }

    public virtual DbSet<EN.Reserva> Reservas { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;DataBase=DbHotelSystem;Integrated Security=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D59466422778DA42");

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
            entity.HasKey(e => e.IdEstadoH).HasName("PK__EstadoH__C7C71E790A95096F");

            entity.ToTable("EstadoH");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoR>(entity =>
        {
            entity.HasKey(e => e.IdEstadoR).HasName("PK__EstadoR__C7C71E038E48E0CC");

            entity.ToTable("EstadoR");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EN.Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__Habitaci__8BBBF9013C146280");

            entity.ToTable("Habitacion");

            entity.HasOne(d => d.IdEstadoHNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdEstadoH)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdEst__412EB0B6");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Habitacio__IdTip__4222D4EF");
        });

        modelBuilder.Entity<EN.Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__0E49C69DE7742DC2");

            entity.ToTable("Reserva");

            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdClien__4316F928");

            entity.HasOne(d => d.IdEstadoRNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdEstadoR)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdEstad__440B1D61");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reserva__IdHabit__44FF419A");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PK__TipoHabi__AB75E87C4D8263BD");

            entity.ToTable("TipoHabitacion");

            entity.Property(e => e.Imgs).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
