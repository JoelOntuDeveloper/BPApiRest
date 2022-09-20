using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DBContext.DBRepository.Models;

namespace DBContext.DBRepository
{
    public partial class BancoDbContext : DbContext
    {
        public BancoDbContext()
        {
        }

        public BancoDbContext(DbContextOptions<BancoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=Banco;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasOne(d => d.IdentificacionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Identificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientePersona");
            });

            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.HasKey(e => e.NumeroCuenta)
                    .HasName("PK__tmp_ms_x__E039507A21075B49");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentaCliente");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.TipoMovimiento).IsFixedLength();

                entity.HasOne(d => d.NumeroCuentaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.NumeroCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoCuenta");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Identificacion)
                    .HasName("PK__Persona__D6F931E4EFBF39C4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
