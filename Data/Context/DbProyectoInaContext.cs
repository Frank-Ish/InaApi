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

    public virtual DbSet<TbPersona> TbPersonas { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbTipoCliente> TbTipoClientes { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.\\MSSQLSERVER01;Initial Catalog=dbProyectoINA;Trusted_Connection=True;TrustServerCertificate=True;");

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

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__tbRoles__3C872F76F8F2B0A4");

            entity.ToTable("tbRoles");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("idRol");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
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

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => new { e.Cedula, e.IdRol }).HasName("PK_Usuario");

            entity.ToTable("tbUsuarios");

            entity.Property(e => e.Cedula)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("cedula");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("date")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbUsuarios_tbRoles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
