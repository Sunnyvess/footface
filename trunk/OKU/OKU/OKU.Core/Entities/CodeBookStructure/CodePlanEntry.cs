using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.CodeBookStructure
{
    [Serializable]
    public class CodePlanEntry
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

        [Display(Name = "Kodni plan")]
        public virtual CodePlan CodePlan { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Kodni plan")]
        public int CodePlanId { get; set; }
        
        [Required]
        [Display(Name = "Naziv")]
        [StringLength(4000)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Vrijednost")]
        public string Value { get; set; }

        [Required]
        [Display(Name = "Redni broj")]
        public int OrdinalPosition { get; set; }
    }
}
