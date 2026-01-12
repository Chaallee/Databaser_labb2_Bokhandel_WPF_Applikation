using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

public partial class BokhandelContext : DbContext
{
    public BokhandelContext()
    {
    }

    public BokhandelContext(DbContextOptions<BokhandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<Lagersaldo> Lagersaldos { get; set; }

    public virtual DbSet<Orderdetaljer> Orderdetaljers { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Bokhandel_Labb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.Property(e => e.Butiksnamn).IsFixedLength();
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasOne(d => d.Författare).WithMany(p => p.Böckers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Böcker_Författare");

            entity.HasOne(d => d.Förlags).WithMany(p => p.Böckers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Böcker_Förlag");
        });

        modelBuilder.Entity<Lagersaldo>(entity =>
        {
            entity.HasOne(d => d.Butiks).WithMany(p => p.Lagersaldos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lagersaldo_Butiker");

            entity.HasOne(d => d.Isbn13Navigation).WithMany(p => p.Lagersaldos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lagersaldo_Böcker");
        });

        modelBuilder.Entity<Orderdetaljer>(entity =>
        {
            entity.HasOne(d => d.Isbn13Navigation).WithMany(p => p.Orderdetaljers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orderdetaljer_Böcker");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetaljers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orderdetaljer_Ordrar");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasOne(d => d.Kund).WithMany(p => p.Ordrars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordrar_Kunder");
        });

        modelBuilder.Entity<TitlarPerFörfattare>(entity =>
        {
            entity.ToView("TitlarPerFörfattare");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
