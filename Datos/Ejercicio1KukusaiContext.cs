using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public partial class Ejercicio1KukusaiContext : DbContext
{
    public Ejercicio1KukusaiContext()
    {
    }

    public Ejercicio1KukusaiContext(DbContextOptions<Ejercicio1KukusaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asociado> Asociados { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=Ejercicio1Kukusai;Trusted_Connection=True; User ID=sa; Password=pass@word1;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asociado>(entity =>
        {
            entity.HasKey(e => e.IdAsociado).HasName("PK__Asociado__2911C4069513796F");

            entity.ToTable("Asociado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Asociados)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Asociado__IdDepa__1273C1CD");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DB6B99EC7");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
