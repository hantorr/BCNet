using System;
using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Front.Models
{
    public partial class BlockChainTXContext : DbContext
    {
        public BlockChainTXContext(): base("name=BlockChainTXContext")
        {
        }

        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cuentas>(entity =>
            //{
            //    entity.Property(e => e.Cuenta)
            //        .IsRequired()
            //        .HasMaxLength(10);

            //    entity.Property(e => e.CuentaBc)
            //        .IsRequired()
            //        .HasColumnName("CuentaBC");

            //    entity.Property(e => e.Nombre)
            //        .IsRequired()
            //        .HasMaxLength(300);
            //});

            //modelBuilder.Entity<Transacciones>(entity =>
            //{
            //    entity.HasIndex(e => e.CuentasId)
            //        .HasName("IX_FK_CuentasTransacciones");

            //    entity.Property(e => e.IdTxBc)
            //        .IsRequired()
            //        .HasColumnName("IdTxBC");

            //    entity.Property(e => e.Monto).IsRequired();

            //    entity.HasOne(d => d.Cuentas)
            //        .WithMany(p => p.Transacciones)
            //        .HasForeignKey(d => d.CuentasId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CuentasTransacciones");
            //});
        }
    }
}
