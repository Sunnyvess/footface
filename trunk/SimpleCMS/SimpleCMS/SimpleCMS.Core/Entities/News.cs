using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    [Serializable]
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        [Required]
        public string HeadLine { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
