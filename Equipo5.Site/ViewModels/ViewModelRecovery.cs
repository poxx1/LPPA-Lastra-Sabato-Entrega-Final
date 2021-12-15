using System.ComponentModel.DataAnnotations;

namespace MKT.Site.ViewModels
{
    public class ViewModelRecovery
    {
        [EmailAddress]
        [Required(ErrorMessage = "Se requiere Email")]
        public string Email { get; set; }


    }
}