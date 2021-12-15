using System.ComponentModel.DataAnnotations;

namespace MKT.Site.ViewModels
{
    public class ViewModelLogIn
    {

        [Required(ErrorMessage = "Se requiere Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        public string Email { get; set; }

    }
}