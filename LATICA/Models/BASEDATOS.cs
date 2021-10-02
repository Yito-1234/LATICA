using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LATICA.Models
{
    public partial class BASEDATOS : DbContext
    {
        public BASEDATOS()
            : base("name=BASEDATOS1")
        {
        }

        public virtual DbSet<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLE_COMPRA)
                .WithRequired(e => e.PRODUCTO)
                .HasForeignKey(e => e.id_producto)
                .WillCascadeOnDelete(false);
        }
    }
}
