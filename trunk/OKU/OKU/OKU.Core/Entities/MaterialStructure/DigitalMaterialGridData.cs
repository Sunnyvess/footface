using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;
using OKU.Core.Entities.MaterialStructure;

namespace OKU.Core.Entities.MaterialStructure
{
    public class DigitalMaterialGridData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Materijal")]
        public int DigitalMaterialId { get; set; }
    }
}
