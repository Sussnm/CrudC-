using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Profesor.Models
{
    public partial class ConexionContext : DbContext
    {
        public ConexionContext()
            : base("name=ConexionContext")
        {
        }

        public virtual DbSet<bdc_area> bdc_area { get; set; }
        public virtual DbSet<bdc_centroCosto> bdc_centroCosto { get; set; }
        public virtual DbSet<bdc_clase> bdc_clase { get; set; }
        public virtual DbSet<bdc_cuenta_activo> bdc_cuenta_activo { get; set; }
        public virtual DbSet<bdc_cuenta_pasivo> bdc_cuenta_pasivo { get; set; }
        public virtual DbSet<bdc_infoActivo> bdc_infoActivo { get; set; }
        public virtual DbSet<bdc_nom_cuenta_activo> bdc_nom_cuenta_activo { get; set; }
        public virtual DbSet<bdc_nom_cuenta_pasivo> bdc_nom_cuenta_pasivo { get; set; }
        public virtual DbSet<bdc_subclase> bdc_subclase { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bdc_area>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_area)
                .HasForeignKey(e => e.fk_area);

            modelBuilder.Entity<bdc_centroCosto>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_centroCosto)
                .HasForeignKey(e => e.fk_centroCosto);

            modelBuilder.Entity<bdc_clase>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_clase)
                .HasForeignKey(e => e.fk_clase);

            modelBuilder.Entity<bdc_cuenta_activo>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_cuenta_activo)
                .HasForeignKey(e => e.fk_cuenta_activo);

            modelBuilder.Entity<bdc_cuenta_pasivo>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_cuenta_pasivo)
                .HasForeignKey(e => e.fk_cuenta_pasivo);

            modelBuilder.Entity<bdc_infoActivo>()
                .Property(e => e.fech_compra)
                .IsUnicode(false);

            modelBuilder.Entity<bdc_nom_cuenta_activo>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_nom_cuenta_activo)
                .HasForeignKey(e => e.fk_nom_cuenta_activo);

            modelBuilder.Entity<bdc_nom_cuenta_pasivo>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_nom_cuenta_pasivo)
                .HasForeignKey(e => e.fk_nom_cuenta_pasivo);

            modelBuilder.Entity<bdc_subclase>()
                .HasMany(e => e.bdc_infoActivo)
                .WithOptional(e => e.bdc_subclase)
                .HasForeignKey(e => e.fk_subclase);
        }
    }
}
