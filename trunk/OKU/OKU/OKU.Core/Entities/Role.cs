using System;
using System.ComponentModel.DataAnnotations;

namespace OKU.Core.Entities
{
    [Serializable]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
