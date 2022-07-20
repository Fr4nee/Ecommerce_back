using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class ProductosCategoria
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
