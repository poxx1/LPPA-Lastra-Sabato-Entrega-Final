using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MKT.Entities.Models
{
    public class User : IdentityBase
    {
        private const string RequiredField = " es un campo requerido";

        public User()
        {
            FechaAlta = DateTime.Now;
            Bloqueo = 0;
            EmailConfirmed = false;
        }

        [Display(Name = "Nombre de Usuario")]
        public string NombreWeb { get; set; }

        public int Bloqueo { get; set; }
        public int IntentosLogin { get; set; }

        [Required(ErrorMessage = "Nombre" + RequiredField)]
        [MaxLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido" + RequiredField)]
        [MaxLength(30)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Documento" + RequiredField)]

        public int Documento { get; set; }
        [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento es invalida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        [Required(ErrorMessage = "Fecha" + RequiredField)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaAlta { get; set; }

        public int Telefono { get; set; }


        [Required(ErrorMessage = "Password" + RequiredField)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Las passwords no coinciden")]
        [Required(ErrorMessage = "Password" + RequiredField)]
        [Display(Name = "Ingrese nuevamente la password")]
        [DataType(DataType.Password)]
        public string Password_ { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Email" + RequiredField)]
        public string Email { get; set; }
        [NotMapped]
        [EmailAddress]
        [Required(ErrorMessage = "Email" + RequiredField)]
        [Display(Name = "Ingrese nuevamente el Email")]
        [Compare(nameof(Email), ErrorMessage = "Email no Coincide")]
        public string Email_ { get; set; }


        public bool EmailConfirmed { get; set; }
        public string UserToken { get; set; }
        public int RolId { get; set; }

        public virtual ICollection<Cart> Carrito { get; set; }
        public virtual ICollection<Address> Direccion { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
