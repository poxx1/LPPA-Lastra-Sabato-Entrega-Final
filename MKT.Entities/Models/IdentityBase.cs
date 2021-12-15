using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace MKT.Entities.Models
{
    public class IdentityBase
    {
        [Key]
        public int Id { get; set; }

    }
}
