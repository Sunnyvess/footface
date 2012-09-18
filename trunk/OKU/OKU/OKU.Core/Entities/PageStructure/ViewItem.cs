using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Entities.MaterialStructure;
using OKU.Core.Entities.CodeBookStructure;
using OKU.Core.Infrastructure.Validation;
using System.Collections.Generic;

namespace OKU.Core.Entities.PageStructure
{
    [Serializable]
    public class ViewItem
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

        [Required]
        [Display(Name = "Šifra")]
        [StringLength(100)]
        public string Code { get; set; }

        [Display(Name = "Opis")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Vrijednost")]
        public string Value { get; set; }

        [Required]
        [Display(Name = "Prikaži stavku pogleda")]
        public bool ShowViewItem { get; set; }

        [Required]
        [Display(Name = "Redni broj")]
        public int OrdinalPosition { get; set; }

        [Display(Name = "Set pogleda")]
        public virtual ViewItemSet ViewItemSet { get; set; }

        [Display(Name = "Filtrirane stranice")]
        public virtual List<ViewItemPageFilter> ViewItemPageFilters { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Set pogleda")]
        public int ViewItemSetId { get; set; }

        [Display(Name = "Zadatak")]
        public virtual Unit Unit { get; set; }

        [Display(Name = "Zadatak")]
        public int? UnitId { get; set; }

        [Display(Name = "Čestica")]
        public virtual Item Item { get; set; }

        [Display(Name = "Čestica")]
        public int? ItemId { get; set; }

        [Display(Name = "Materijal")]
        public virtual DigitalMaterial DigitalMaterial { get; set; }

        [Display(Name = "Materijal")]
        public int? DigitalMaterialId { get; set; }

        [Display(Name = "Kodni plan")]
        public virtual CodePlan CodePlan { get; set; }

        [Display(Name = "Kodni plan")]
        public int? CodePlanId { get; set; }

        [Display(Name = "Izabrani unos kodnog plana")]
        public virtual CodePlanEntry CodePlanEntry { get; set; }

        [Display(Name = "Izabrani unos kodnog plana")]
        public int? CodePlanEntryId { get; set; }

        [Required]
        [Display(Name = "Vrsta pogleda")]
        public int ViewItemDescriminatorValue { get; set; }

        public Enums.ViewItemDescriminator ViewItemDescriminator
        {
            get { return (Enums.ViewItemDescriminator)ViewItemDescriminatorValue; }
            set { ViewItemDescriminatorValue = (int)value; }
        }

        [Required]
        [Display(Name = "Sadrži zapis o poziciji na slikovnoj mreži")]
        public bool IsGridEntry { get; set; }

        [Display(Name = "Udaljenost od vrha slike")]
        public int? PartPerThousandFromTop { get; set; }

        [Display(Name = "Udaljenost od lijevog ruba slike")]
        public int? PartPerThousandFromLeft { get; set; }
    }
}
