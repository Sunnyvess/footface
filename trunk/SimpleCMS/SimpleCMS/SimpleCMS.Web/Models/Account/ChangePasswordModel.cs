using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleCMS.Web.Models.Account
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "{0} je obavezna.")]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0} je obavezna.")]
        [StringLength(100, ErrorMessage = "Lozinka mora sadržavati najmanje {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi novu lozinku")]
        [Compare("NewPassword", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }
    }
}