using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;
using OKU.Core.Entities.MaterialStructure;

namespace OKU.Core.Entities.PageStructure
{
    [Serializable]
    public class PageSet
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

        [Display(Name = "Stranice")]
        public virtual List<Page> Pages { get; set; }

        [Required]
        [Display(Name = "Šifra")]
        [StringLength(100)]
        public string Code { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Redni broj")]
        public int OrdinalPosition { get; set; }

        [Display(Name = "Pridružena struktura")]
        public int StructureDescriminatorValue { get; set; }

        public Enums.StructureDescriminator StructureDescriminator
        {
            get { return (Enums.StructureDescriminator)StructureDescriminatorValue; }
            set { StructureDescriminatorValue = (int)value; }
        }

        [Display(Name = "Pristupnik")]
        public virtual AttendeeMaterialVersion AttendeeMaterialStructure { get; set; }

        [Display(Name = "Pristupnik")]
        public int? AttendeeMaterialStructureId { get; set; }


        [Display(Name = "Verzija grupe materijala")]
        public virtual MaterialVersion MaterialVersion { get; set; }


        [Display(Name = "Verzija grupe materijala")]
        public int? MaterialVersionId { get; set; }

        [Display(Name = "Grupe materijala strukture")]
        public virtual Cluster Cluster { get; set; }


        [Display(Name = "Grupe materijala strukture")]
        public int? ClusterId { get; set; }

        [Display(Name = "Grupa osnove")]
        public virtual Unit Unit { get; set; }


        [Display(Name = "Grupa osnove")]
        public int? UnitId { get; set; }

        [Display(Name = "Čestica")]
        public virtual Item Item { get; set; }

        [Display(Name = "Čestica")]
        public int? ItemId { get; set; }
    }
}
