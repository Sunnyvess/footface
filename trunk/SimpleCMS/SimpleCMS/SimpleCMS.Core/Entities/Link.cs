using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMS.Core.Entities
{
    public class Link
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        public string LinkName { get; set; }

        public string LinkPath { get; set; }


    }
}
