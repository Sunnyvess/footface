using System.ComponentModel.DataAnnotations;

namespace OKU.Web.Models.Account
{
    public class LogInModel
    {
        [Required(ErrorMessage = "{0} je obavezno.")]
        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} je obavezna.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }
    }
}