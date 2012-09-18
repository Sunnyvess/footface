using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Entities.PageStructure;
using OKU.Core.Entities.MaterialStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class ExecutionDefinition
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

        [Display(Name = "Setovi stranica")]
        public virtual PageSet PageSet { get; set; }

        [Display(Name = "Setovi stranica")]
        public int? PageSetId { get; set; }

        [Display(Name = "Grupa definicija izvršavanja")]
        public virtual ExecutionDefinitionGroup ExecutionDefinitionGroup { get; set; }

        [Display(Name = "Grupa definicija izvršavanja")]
        public int? ExecutionDefinitionGroupId { get; set; }

        [Display(Name = "Je spremno za izvršavanje")]
        public bool IsActive { get; set; }

        [Display(Name = "Je ispunjeno")]
        public bool IsFinished { get; set; }

        [Display(Name = "Vrijeme zadavanja")]
        public DateTime ExecutionCreated { get; set; }

        [Display(Name = "Vrijeme početka ispunjavanja")]
        public DateTime? ExecutionStartTime { get; set; }

        [Display(Name = "Vrijeme kraja izvršavanja")]
        public DateTime? ExecutionFinished { get; set; }

        [InverseProperty("DefinedExecutionDefinitions")]
        [Display(Name = "Moderator")]
        public virtual UserProject DefinedByUser { get; set; }

        [Display(Name = "Moderator")]
        public int? DefinedByUserId { get; set; }

        [InverseProperty("ExecutedExecutionDefinitions")]
        [Display(Name = "Unosač")]
        public virtual UserProject ExecutedByUser { get; set; }

        [Display(Name = "Unosač")]
        public int? ExecutedByUserId { get; set; }

        [Display(Name = "Pristupnik")]
        public virtual AttendeeMaterialVersion AttendeeMaterialStructure { get; set; }

        [Display(Name = "Pristupnik")]
        public int? AttendeeMaterialStructureId { get; set; }

        [Display(Name = "Napomena")]
        public string Remark { get; set; }

    }
}
