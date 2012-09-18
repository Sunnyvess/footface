using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.MaterialStructure
{
    [Serializable]
    public class DigitalMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Vrsta")]
        public virtual DigitalMaterialType MaterialType { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Vrsta")]
        public int MaterialTypeId { get; set; }

        [Display(Name = "Ime datoteke")]
        [StringLength(1000)]
        public string DigitalMaterialFileName { get; set; }

        [Display(Name = "Grupa osnove")]
        public virtual Unit Unit { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Grupa osnove")]
        public int UnitId { get; set; }

        [Display(Name = "Pristupnik")]
        public virtual AttendeeMaterialVersion AttendeeMaterialStructure { get; set; }

        [Display(Name = "Pristupnik")]
        public int? AttendeeMaterialStructureId { get; set; }
    }
}
