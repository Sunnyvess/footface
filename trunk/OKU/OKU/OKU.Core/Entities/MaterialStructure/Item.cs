using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Entities.ProjectStructure;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities.MaterialStructure
{
    [Serializable]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Faza")]
        public virtual Phase Phase { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Faza")]
        public int PhaseId { get; set; }

        [Display(Name = "Grupa osnove")]
        public virtual Unit Unit { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Grupa osnove")]
        public int UnitId { get; set; }

        [Required]
        [Display(Name = "Šifra")]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Redni broj")]
        public int OrdinalPosition { get; set; }

        [Display(Name = "Osnova")]
        [StringLength(4000)]
        public string ItemBase { get; set; }

        [Required]
        [Display(Name = "Prikaži osnovu")]
        public bool ShowItemBase { get; set; }

        [Display(Name = "Odgovor")]
        [StringLength(4000)]
        public string ItemAnswer { get; set; }

        [Required]
        [Display(Name = "Prikaži prikaži odgovor")]
        public bool ShowItemAnswer { get; set; }

        [Display(Name = "Rješenje")]
        [StringLength(4000)]
        public string ItemSolution { get; set; }

        [Required]
        [Display(Name = "Prikaži rješenje")]
        public bool ShowItemSolution { get; set; }

        [Required]
        [Display(Name = "Vrsta/dubina strukture")]
        public int StructureDescriminatorValue { get; set; }

        public Enums.StructureDescriminator StructureDescriminator
        {
            get { return (Enums.StructureDescriminator)StructureDescriminatorValue; }
            set { StructureDescriminatorValue = (int)value; }
        }
    }
}
