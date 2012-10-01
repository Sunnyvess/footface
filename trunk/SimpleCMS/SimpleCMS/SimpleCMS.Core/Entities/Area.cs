using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    [Serializable]
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int AreaID { get; set; }

        [Display(Name = "Naslov")]
        public string Title { get; set; }

        [Display(Name = "Vrijeme")]
        public DateTime CreationDate { get; set; }
    }
}
