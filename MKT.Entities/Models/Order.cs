using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Entities.Models
{
    public class Order : IdentityBase
    {
        public Order()
        {
            Fecha = DateTime.Now;
        }
        public int UsuarioId { get; set; }

        public int DireccionId { get; set; }

        public int CarritoId { get; set; }

        public DateTime Fecha { get; set; }
        public virtual Address Direccion { get; set; }
        public virtual Cart Carrito { get; set; }
        public virtual User Usuario { get; set; }
    }
}
