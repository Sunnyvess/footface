using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.ProjectStructure
{
    [Serializable]
    public class Phase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Ispit")]
        public virtual Exam Exam { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Ispit")]
        public int ExamId { get; set; }

        [Display(Name = "Iteracije")]
        public virtual List<Iteration> Iterations { get; set; }

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
    
    }
}
