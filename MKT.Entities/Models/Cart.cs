using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MKT.Entities.Models
{
    public class Cart : IdentityBase
    {
        public Cart()
        {
            this.Creado = DateTime.Now;
            this.Modificado = DateTime.Now;
        }
        public int UsuarioId { get; set; }
        public DateTime Creado { get; set; }
        public DateTime Modificado { get; set; }

        public virtual User Usuario { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}