using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Korisničko ime")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Lozinka")]
        [StringLength(100)]
        public string Password { get; set; }

        [Display(Name = "Ime")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Pretplate")]
        public virtual List<Site> Subscriptions { get; set; }
    }
}
