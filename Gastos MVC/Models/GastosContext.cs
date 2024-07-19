using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gastos_MVC.Models;

public partial class GastosContext : DbContext
{
    public GastosContext()
    {
    }

    public GastosContext(DbContextOptions<GastosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compradore> Compradores { get; set; }

    public virtual DbSet<ListadoDeGasto> ListadoDeGastos { get; set; }

    public virtual DbSet<TipoDeGasto> TipoDeGastos { get; set; }

    public virtual DbSet<VGastosPorCategoria> VGastosPorCategoria { get; set; }

    public virtual DbSet<VGastosTotale> VGastosTotales { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-80L0P0A\\SQLEXPRESS; Database=Gastos; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compradore>(entity =>
        {
            entity.HasKey(e => e.CompradorId).HasName("PK__Comprado__E521A8ADDC70C57B");

            entity.Property(e => e.CompradorId).HasColumnName("CompradorID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ListadoDeGasto>(entity =>
        {
            entity.HasKey(e => e.ListadoGastosId).HasName("PK__Listado___F7EA67E6D5374F33");

            entity.ToTable("Listado_de_gastos");

            entity.Property(e => e.ListadoGastosId).HasColumnName("ListadoGastosID");
            entity.Property(e => e.CompradorId).HasColumnName("CompradorID");
            entity.Property(e => e.DetalleCompra)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoGastosId).HasColumnName("TipoGastosID");

            entity.HasOne(d => d.Comprador).WithMany(p => p.ListadoDeGastos)
                .HasForeignKey(d => d.CompradorId)
                .HasConstraintName("CompradorID_FK");

            entity.HasOne(d => d.TipoGastos).WithMany(p => p.ListadoDeGastos)
                .HasForeignKey(d => d.TipoGastosId)
                .HasConstraintName("TipoGastosID_FK");
        });

        modelBuilder.Entity<TipoDeGasto>(entity =>
        {
            entity.HasKey(e => e.TipoGastosId).HasName("PK__Tipo_de___B1D091DB3AD193B7");

            entity.ToTable("Tipo_de_gastos");

            entity.Property(e => e.TipoGastosId).HasColumnName("TipoGastosID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VGastosPorCategoria>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGastosPorCategoria");

            entity.Property(e => e.Comprador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoGasto)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VGastosTotale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGastosTotales");

            entity.Property(e => e.CompradorId).HasColumnName("CompradorID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalGastado).HasColumnName("total_gastado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
