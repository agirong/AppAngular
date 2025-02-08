using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppAngular.Server.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("USER_AARON")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.HasKey(e => e.Idtransaction).HasName("TRANSACCION_PK");

            entity.ToTable("TRANSACCION");

            entity.Property(e => e.Idtransaction)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDTRANSACTION");
            entity.Property(e => e.Idusuario)
                .HasColumnType("NUMBER")
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.Monto)
                .HasColumnType("NUMBER(15,2)")
                .HasColumnName("MONTO");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Transaccions)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK_TRANSACCION_USUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("USUARIO_PK");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Idusuario)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });
        modelBuilder.HasSequence("USUARIO_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
