using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.ProjectStructure
{
    [Serializable]
    public class Exam
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

        [Display(Name = "Projekt")]
        public virtual Cycle Cycle { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Projekt")]
        public int ProjectId { get; set; }

        [Display(Name = "Faze")]
        public virtual List<Phase> Phases { get; set; }

        // options

        [Required]
        [Display(Name = "Je spremno za izvršavanje")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Je ispunjeno")]
        public bool IsFinished { get; set; }

        [Required]
        [Display(Name = "Ispit koristi materijale unutar sistema (skenirani materijali)")]
        public bool IsUsingFileSystemMaterials { get; set; }

        [Display(Name = "Put do foldera")]
        [StringLength(500)]
        public string FileSystemRootPath { get; set; }

        [Display(Name = "Početak")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Kraj")]
        public DateTime? EndTime { get; set; }
    }
}
