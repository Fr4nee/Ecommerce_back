using System;
using System.Collections.Generic;

namespace Ecomerce_back.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Contraseña { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
