using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoNotas.Models;

namespace ProyectoNotas.DAL.DataContext;

public partial class NotasContext : DbContext
{
    public NotasContext()
    {
    }

    public NotasContext(DbContextOptions<NotasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nota> Notas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Idnota).HasName("PK__notas__51C85724AAE5F30F");

            entity.ToTable("notas");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Titulo)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
