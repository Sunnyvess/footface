using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SimpleCMS.Core.Infrastructure.Validation;

namespace SimpleCMS.Core.Entities
{
    [Serializable]
    public class Content
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identifikator")]
        public int Id { get; set; }

        public virtual ContentContainer ContentContainer { get; set; }

        [RequiredForeignKey]
        public int ContentContainerId { get; set; }

        public virtual News News { get; set; }

        public virtual Link Link { get; set; }


    }
}
