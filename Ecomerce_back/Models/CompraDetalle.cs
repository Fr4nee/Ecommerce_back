using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class CompraDetalle
    {
        public CompraDetalle()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
