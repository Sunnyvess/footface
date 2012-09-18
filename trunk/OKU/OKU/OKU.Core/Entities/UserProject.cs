using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class UserProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Korisnik")]
        public virtual User User { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Korisnik")]
        public int UserId { get; set; }

        [Display(Name = "Iteracija")]
        public virtual Iteration Iteration { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Iteracija")]
        public int IterationId { get; set; }

        [Display(Name = "Grupa korisnika")]
        public virtual UserGroup UserGroup { get; set; }

        [Display(Name = "Grupa korisnika")]
        public int? UserGroupId { get; set; }

        [Display(Name = "Uloga")]
        public virtual Role Role { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Uloga")]
        public int RoleId { get; set; }

        [InverseProperty("DefinedByUser")]
        [Display(Name = "Pristupnici")]
        public virtual List<ExecutionDefinition> DefinedExecutionDefinitions { get; set; }

        [InverseProperty("ExecutedByUser")]
        [Display(Name = "Pristupnici")]
        public virtual List<ExecutionDefinition> ExecutedExecutionDefinitions { get; set; }
    }
}
