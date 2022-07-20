using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CompraDetalles = new HashSet<CompraDetalle>();
            ProductosCategoria = new HashSet<ProductosCategoria>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Precio { get; set; }
        public string? Imagen { get; set; }
        public string? Categoria { get; set; }
        public int? Stock { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<CompraDetalle> CompraDetalles { get; set; }
        public virtual ICollection<ProductosCategoria> ProductosCategoria { get; set; }
    }
}
