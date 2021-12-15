using MKT.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MKT.Entities.Models
{
    public class CartItem : IdentityBase
    {

        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Cantidad { get; set; }
        [XmlIgnore]
        public virtual Cart Cart { get; set; }
        [XmlIgnore]
        public virtual Product Product { get; set; }
    }
}
