using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.MaterialStructure
{
    [Serializable]
    public class Cluster
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

        [Display(Name = "Verzija grupe materijala")]
        public virtual List<MaterialVersionCluster> MaterialVersion { get; set; }

        [Display(Name = "Grupe osnova")]
        public virtual List<Unit> Units { get; set; }

        [Required]
        [Display(Name = "Šifra")]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Vrsta/dubina strukture")]
        public int StructureDescriminatorValue { get; set; }

        public Enums.StructureDescriminator StructureDescriminator
        {
            get { return (Enums.StructureDescriminator)StructureDescriminatorValue; }
            set { StructureDescriminatorValue = (int)value; }
        }
    }
}
