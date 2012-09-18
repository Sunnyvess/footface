using System;
using System.ComponentModel.DataAnnotations;
using OKU.Core.Infrastructure.Validation;

namespace OKU.Core.Entities
{
    [Serializable]
    public class ParameterValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Display(Name = "Naziv atributa")]
        public virtual ParameterDefinition ParameterDefinition { get; set; }

        [RequiredForeignKey]
        [Display(Name = "Naziv atributa")]
        public int ParameterDefinitionId { get; set; }

        [Display(Name = "Pristupnik")]
        public virtual Attendee Attendee { get; set; }

        [Display(Name = "Pristupnik")]
        public int? AttendeeId { get; set; }

        [Required]
        [Display(Name = "Vrijednost")]
        [StringLength(100)]
        public string Value { get; set; }
    }
}
