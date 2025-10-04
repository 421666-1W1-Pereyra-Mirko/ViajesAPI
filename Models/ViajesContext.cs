using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ViajesAPI.Models;

public partial class ViajesContext : DbContext
{
    public ViajesContext()
    {
    }

    public ViajesContext(DbContextOptions<ViajesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Excursion> Excursiones { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<ViajeDetalle> ViajeDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Excursion>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ViajeDetalle>(entity =>
        {
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Excursion).WithMany(p => p.ViajeDetalles)
                .HasForeignKey(d => d.ExcursionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViajeDetalles_Excursiones");

            entity.HasOne(d => d.Viaje).WithMany(p => p.ViajeDetalles)
                .HasForeignKey(d => d.ViajeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ViajeDetalles_Viajes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
