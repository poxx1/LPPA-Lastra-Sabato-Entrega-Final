using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Entities.Models
{
    public class Address : IdentityBase
    {
        public int UserId { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string DireccionCompleta { get; set; }
        public string CodigoPostal { get; set; }

        public virtual User User { get; set; }
    }
}
