using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.CodeBookStructure
{
    [Serializable]
    public class CodePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Lista kodnih planova djece")]
        public virtual List<CodePlan> ChildCodePlans { get; set; }

        [Display(Name = "Kodni plan roditelj")]
        public virtual CodePlan CodePlanParent { get; set; }

        [Display(Name = "Kodni plan")]
        public int? CodePlanParentId { get; set; }

        [Display(Name = "Vrijednost za dohvat preko unosa roditelja")]
        public int? EntryValueSelector { get; set; }

        [Display(Name = "Faza")]
        public virtual Phase Phase { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Faza")]
        public int PhaseId { get; set; }

        [Display(Name = "Kodni unosi")]
        public virtual List<CodePlanEntry> CodePlanEntries { get; set; }

        [Display(Name = "Vrsta unosa kodnog plana")]
        public int CodePlanTypeValue { get; set; }

        public Enums.CodePlanType CodePlanType
        {
            get { return (Enums.CodePlanType) CodePlanTypeValue; }
            set { CodePlanTypeValue = (int) value; }
        }

        [Display(Name = "Validacijsko pravilo")]
        [StringLength(500)]
        public string ValidationRegEx { get; set; }

        [Required]
        [Display(Name = "Kodni plan se koristi u mrežnom prikazu")]
        public bool IsCodePlanForGridView { get; set; }

        [Display(Name = "Akcija pri korištenju kodnog plana")]
        public int CodePlanActionOnSelectionValue { get; set; }

        public Enums.ActionOnSelection CodePlanActionOnSelection
        {
            get { return (Enums.ActionOnSelection)CodePlanActionOnSelectionValue; }
            set { CodePlanActionOnSelectionValue = (int)value; }
        }

        [Display(Name = "Vrsta polja za unos teksta")]
        public int? TextBoxTypeValue { get; set; }

        public Enums.TextBoxType TextBoxType
        {
            get { return (Enums.TextBoxType)TextBoxTypeValue; }
            set { TextBoxTypeValue = (int)value; }
        }

        [Display(Name = "Naziv varijable")]
        [StringLength(200)]
        public string VariableName { get; set; }

        [Display(Name = "Opis varijable")]
        public string VariableDescription { get; set; }

        [Display(Name = "Naslov")]
        [StringLength(200)]
        public string Heading { get; set; }

        [Display(Name = "Početni tekst")]
        public string BeginTekst { get; set; }

        [Display(Name = "Završni tekst")]
        public string EndTekst { get; set; }
    }
}
