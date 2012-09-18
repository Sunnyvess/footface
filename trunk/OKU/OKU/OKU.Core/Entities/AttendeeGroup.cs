using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.MaterialStructure;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class AttendeeGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Iteracija")]
        public virtual Iteration Iteration { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Iteracija")]
        public int IterationId { get; set; }

        [Display(Name = "Pristupnici")]
        public virtual List<AttendeeMaterialVersion> AttendeeMaterialVersions { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
