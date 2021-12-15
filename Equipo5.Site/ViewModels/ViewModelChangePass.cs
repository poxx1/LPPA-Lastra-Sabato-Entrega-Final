using System.ComponentModel.DataAnnotations;

namespace MKT.Site.ViewModels
{
    public class ViewModelChangePass
    {

        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password no Coincide")]
        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password_ { get; set; }





    }
}