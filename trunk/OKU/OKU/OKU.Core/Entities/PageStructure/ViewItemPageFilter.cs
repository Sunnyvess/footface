using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Entities.MaterialStructure;
using OKU.Core.Entities.CodeBookStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.PageStructure
{
    [Serializable]
    public class ViewItemPageFilter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Stranica")]
        public virtual Page Page { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Stranica")]
        public int PageId { get; set; }

        [Display(Name = "Pogled")]
        public virtual ViewItem ViewItem { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Pogled")]
        public int ViewItemId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Vrijednost")]
        public string Value { get; set; }
    }
}
