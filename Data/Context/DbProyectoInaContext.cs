using System;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public partial class DbProyectoInaContext : DbContext
{
    public DbProyectoInaContext()
    {
    }

    public DbProyectoInaContext(DbContextOptions<DbProyectoInaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleFactura> TbDetalleFacturas { get; set; }

    public virtual DbSet<TbFactura> TbFacturas { get; set; }

    public virtual DbSet<TbJugador> TbJugadors { get; set; }

    public virtual DbSet<TbPersona> TbPersonas { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbRegistroJuego> TbRegistroJuegos { get; set; }

    public virtual DbSet<TbTipoCliente> TbTipoClientes { get; set; }

    public virtual DbSet<TbTipoPago> TbTipoPagos { get; set; }

    public virtual DbSet<TbTipoVentum> TbTipoVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:dbINA");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.Cedula);

            entity.ToTable("tbClientes");

            entity.Property(e => e.Cedula)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.DescMax).HasColumnName("descMax");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Foto)
                .HasColumnType("image")
                .HasColumnName("foto");
            entity.Property(e => e.TipoCliente).HasColumnName("tipoCliente");

            entity.HasOne(d => d.CedulaNavigation).WithOne(p => p.TbCliente)
                .HasForeignKey<TbCliente>(d => d.Cedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbClientes_tbPersona1");

            entity.HasOne(d => d.TipoClienteNavigation).WithMany(p => p.TbClientes)
                .HasForeignKey(d => d.TipoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbClientes_tbTipoClientes");
        });

        modelBuilder.Entity<TbDetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFactura).HasName("PK__tbDetall__DFF38252D90CBF47");

            entity.ToTable("tbDetalleFactura");

            entity.Property(e => e.IdDetalleFactura).HasColumnName("idDetalleFactura");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.TbDetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaDetalle");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TbDetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoDetalle");
        });

        modelBuilder.Entity<TbFactura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__tbFactur__3CD5687E83A7E396");

            entity.ToTable("tbFactura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("idCliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteFactura");

            entity.HasOne(d => d.TipoPagoNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.TipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoPagoFactura");

            entity.HasOne(d => d.TipoVentaNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.TipoVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoVentaFactura");
        });

        modelBuilder.Entity<TbJugador>(entity =>
        {
            entity.HasKey(e => e.Cedula);

            entity.ToTable("tbJugador");

            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TbPersona>(entity =>
        {
            entity.HasKey(e => e.Cedula);

            entity.ToTable("tbPersona");

            entity.Property(e => e.Cedula)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("apellido2");
            entity.Property(e => e.FechaNac)
                .HasColumnType("datetime")
                .HasColumnName("fechaNac");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__tbProduc__07F4A132002DBD50");

            entity.ToTable("tbProducto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta).HasColumnName("precioVenta");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<TbRegistroJuego>(entity =>
        {
            entity.ToTable("tbRegistroJuego");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.Tiempo).HasColumnName("tiempo");

            entity.HasOne(d => d.CedulaNavigation).WithMany(p => p.TbRegistroJuegos)
                .HasForeignKey(d => d.Cedula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbRegistroJuego_tbJugador");
        });

        modelBuilder.Entity<TbTipoCliente>(entity =>
        {
            entity.ToTable("tbTipoClientes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TbTipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("PK__tbTipoPa__AC5BA85B06A4B2CF");

            entity.ToTable("tbTipoPago");

            entity.Property(e => e.IdTipoPago).HasColumnName("idTipoPago");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TbTipoVentum>(entity =>
        {
            entity.HasKey(e => e.IdTipoVenta).HasName("PK__tbTipoVe__955AAFEA399384B0");

            entity.ToTable("tbTipoVenta");

            entity.Property(e => e.IdTipoVenta).HasColumnName("idTipoVenta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
