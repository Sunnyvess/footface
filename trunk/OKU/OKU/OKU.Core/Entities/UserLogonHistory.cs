using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OKU.Core.Entities.ProjectStructure;
using System.ComponentModel.DataAnnotations;

namespace OKU.Core.Entities
{
    [Serializable]
    public class UserLogonHistory
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         [Display(Name = "Identifikator")]
         public int Id { get; set; }

         [Display(Name = "Naziv")]
         [StringLength(300)]
         public string UserLogin { get; set; }

         [Display(Name = "Id")]
         [StringLength(300)]
         public string UserIdValue { get; set; }

         [Display(Name = "Stvarna lozinka")]
         [StringLength(100)]
         public string RealPassword { get; set; }

         [Display(Name = "Unesena lozinka")]
         [StringLength(100)]
         public string EnteredPassword { get; set; }

         [Display(Name = "LogonTime")]
         public DateTime? LogonTime { get; set; }

         [Display(Name = "LogoutTime")]
         public DateTime? LogoutTime { get; set; }

         [Display(Name = "UserAgent")]
         [StringLength(1000)]
         public string UserAgent { get; set; }

         [Display(Name = "HostAddress")]
         [StringLength(1000)]
         public string HostAddress { get; set; }

         [Display(Name = "UserUrlReferrer")]
         [StringLength(1000)]
         public string UserUrlReferrer { get; set; }

         [Display(Name = "LogonSuccess")]
         public bool LogonSuccess { get; set; }

    }
}
