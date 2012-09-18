using System;
using System.ComponentModel.DataAnnotations;

namespace OKU.Core.Entities
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Korisničko ime")]
        [StringLength(100)]
        public string UserName { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(100)]
        public string Password { get; set; }

        [Display(Name = "Ime")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [StringLength(100)]
        public string LastName { get; set; }
    }
}
