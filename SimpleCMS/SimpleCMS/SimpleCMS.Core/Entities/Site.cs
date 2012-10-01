using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    [Serializable]
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int SiteID { get; set; }

        [Display(Name = "Naslov")]
        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Vrijeme")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Vlasnik")]
        public User Owner { get; set; }

        [Display(Name = "Pretplatnici")]
        public virtual List<User> Subscribers { get; set; }

        [Display(Name = "Stranice")]
        public virtual List<Page> Pages { get; set; }

    }
}
