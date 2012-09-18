using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OKU.Core.Entities.ProjectStructure
{
    public class Cycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Skraceni naziv")]
        [StringLength(100)]
        public string ShortName { get; set; }

        [Display(Name = "Ispiti")]
        public virtual List<Exam> Exams { get; set; }

        [Display(Name = "Projekt")]
        public virtual Project Project { get; set; }

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
