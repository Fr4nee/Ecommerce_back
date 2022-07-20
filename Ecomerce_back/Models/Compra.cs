using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class Compra
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public double? Monto { get; set; }
        public int IdCompraDetalle { get; set; }
        public bool Realizado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual CompraDetalle IdCompraDetalleNavigation { get; set; } = null!;
    }
}
