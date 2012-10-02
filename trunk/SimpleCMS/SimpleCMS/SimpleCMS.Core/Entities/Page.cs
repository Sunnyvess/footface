using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Redni broj stranice")]
        public int PageNumber { get; set; }

        [Display(Name = "Naslov")]
        [StringLength(100)]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Kategorije")]
        public virtual List<ContentContainer> ContentContainers { get; set; }
    }
}
