using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.MaterialStructure;

namespace OKU.Core.Entities
{
    [Serializable]
    public class Attendee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Šifra")]
        [StringLength(100)]
        public string Code { get; set; }

        [Display(Name = "Profilni podatci")]
        public List<ParameterValue> ParameterValues { get; set; }
        
        [Display(Name = "Pristupnici")]
        public virtual List<AttendeeMaterialVersion> AttendeeMaterialStructures { get; set; }

        public override string ToString()
        {
            return this.Code;
        }
    }
}
