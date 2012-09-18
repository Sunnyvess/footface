using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.MaterialStructure
{
    public class AttendeeMaterialVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Faza")]
        public virtual Phase Phase { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Faza")]
        public int PhaseId { get; set; }

        [Display(Name = "Pristupnik")]
        public virtual Attendee Attendee { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Pristupnik")]
        public int AttendeeId { get; set; }

        [Display(Name = "Verzija grupe materijala")]
        public virtual MaterialVersion MaterialVersion { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Verzija grupe materijala")]
        public int MaterialVersionId { get; set; }

        [Required]
        [Display(Name = "Redni broj verzije materijala")]
        public int OrdinalPosition { get; set; }

        [Required]
        [Display(Name = "Vrsta/dubina strukture")]
        public int StructureDescriminatorValue { get; set; }

        public Enums.StructureDescriminator StructureDescriminator
        {
            get { return (Enums.StructureDescriminator)StructureDescriminatorValue; }
            set { StructureDescriminatorValue = (int)value; }
        }

        [Display(Name = "Materijali")]
        public virtual List<DigitalMaterial> DigitalMaterials { get; set; }

        [Display(Name = "Put do foldera sa sadržajem ispitanika")]
        [StringLength(500)]
        public string FileSystemBatchPath { get; set; }

        [Display(Name = "Grupa ispitanika")]
        public virtual AttendeeGroup AttendeeGroup { get; set; }

        [Display(Name = "Grupa ispitanika")]
        public int? AttendeeGroupId { get; set; }
    }
}
