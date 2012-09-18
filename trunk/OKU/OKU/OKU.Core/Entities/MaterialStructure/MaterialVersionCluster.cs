using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.MaterialStructure
{
    [Serializable]
    public class MaterialVersionCluster
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

        [Display(Name = "Grupe materijala strukture")]
        public virtual Cluster Cluster { get; set; }

        [Required]
        [Display(Name = "Grupe materijala strukture")]
        public int ClusterId { get; set; }

        [Display(Name = "Verzija grupe materijala")]
        public virtual MaterialVersion MaterialVersion { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Verzija grupe materijala")]
        public int MaterialVersionId { get; set; }

        [Required]
        [Display(Name = "Redni broj u verzija grupe materijala")]
        public int OrdinalPosition { get; set; }
    }
}
