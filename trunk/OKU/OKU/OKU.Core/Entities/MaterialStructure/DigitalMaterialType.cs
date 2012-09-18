using System;
using System.ComponentModel.DataAnnotations;

namespace OKU.Core.Entities.MaterialStructure
{
    [Serializable]
    public class DigitalMaterialType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Vrsta sadržaja")]
        [StringLength(100)]
        public string ContentType { get; set; }
    }
}
