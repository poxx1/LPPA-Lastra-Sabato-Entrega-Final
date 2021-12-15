using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace MKT.Entities.Models
{
    public class OrderDetail : IdentityBase
    {
        public int OrderId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Producto { get; set; }
    }
}
