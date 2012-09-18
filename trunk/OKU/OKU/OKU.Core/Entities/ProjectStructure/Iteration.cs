using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.ProjectStructure
{
    [Serializable]
    public class Iteration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Faza")]
        public virtual Phase Phase { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Faza")]
        public int PhaseId { get; set; }

        // options

        [Required]
        [Display(Name = "Je spremno za izvršavanje")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Je ispunjeno")]
        public bool IsFinished { get; set; }

        [Display(Name = "Početak")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Kraj")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Izaberi slike od unesene vrijednosti")]
        [StringLength(50)]
        public string DigitalMaterialMinSelector { get; set; }

        [Display(Name = "Izaberi slike do unesene vrijednosti")]
        [StringLength(50)]
        public string DigitalMaterialMaxSelector { get; set; }
    }
}
