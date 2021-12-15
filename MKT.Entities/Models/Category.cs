using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MKT.Entities.Models
{
    public class Category : IdentityBase
    {
        public string Nombre { get; set; }

        public virtual ICollection<Product> Producto { get; set; }



    }
}