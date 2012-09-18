using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class UserGroup
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

        [Display(Name = "Korisnici")]
        public virtual List<UserProject> UserProjects { get; set; }
    }
}
