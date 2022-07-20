using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            ProductosCategoria = new HashSet<ProductosCategoria>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<ProductosCategoria> ProductosCategoria { get; set; }
    }
}
