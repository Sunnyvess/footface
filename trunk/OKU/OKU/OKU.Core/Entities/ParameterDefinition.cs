using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class ParameterDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Faza")]
        public virtual Exam Exam { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Ispit")]
        public int ExamId { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
