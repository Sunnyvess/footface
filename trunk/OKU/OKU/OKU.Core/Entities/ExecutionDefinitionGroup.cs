using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class ExecutionDefinitionGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Definicije izvršavanja")]
        public virtual List<ExecutionDefinition> ExecutionDefinitions { get; set; }

        [Display(Name = "Grupa korisnika")]
        public virtual UserGroup UserGroup { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Grupa korisnika")]
        public int UserGroupId { get; set; }

        [Display(Name = "Grupa ispitanika")]
        public virtual AttendeeGroup AttendeeGroup { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Grupa ispitanika")]
        public int AttendeeGroupId { get; set; }
    }
}
