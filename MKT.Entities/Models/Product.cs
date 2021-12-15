using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MKT.Entities.Models
{
    public class Product : IdentityBase
    {
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int CategoryId { get; set; }
        public byte[] FotoProducto { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> DetalleOrder { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}