namespace LATICA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_COMPRA
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public int id_producto { get; set; }

        public int cantidad { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
