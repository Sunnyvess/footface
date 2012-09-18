using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OKU.Core.Entities;
using OKU.Core.Infrastructure.Extensions;

namespace OKU.Web.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "{0} je obavezno.")]
        [Display(Name = "Korisničko ime")]
        [StringLength(100, ErrorMessage = "{0} smije sadržavati najviše {1} znakova.")]
        public string UserName { get; set; }

        [Display(Name = "Ime")]
        [StringLength(100, ErrorMessage = "{0} smije sadržavati najviše {1} znakova.")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [StringLength(100, ErrorMessage = "{0} smije sadržavati najviše {1} znakova.")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "{0} je obavezna.")]
        [StringLength(100, ErrorMessage = "{0} mora sadržavati najmanje {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
        public string ConfirmPassword { get; set; }

        public void CopyValuesToCoreEntity(User coreEntity)
        {
            if (coreEntity == null)
            {
                throw new ArgumentNullException("coreEntity");
            }

            coreEntity.UserName = this.UserName;
            coreEntity.FirstName = this.FirstName;
            coreEntity.LastName = this.LastName;
            coreEntity.Password = this.Password;
        }
    }
}