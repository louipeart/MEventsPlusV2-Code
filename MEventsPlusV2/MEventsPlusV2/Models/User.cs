using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "FName")]
        public string FName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [StringLength(100)]
        [Display(Name = "LName")]
        public string LName { get; set; }
        [Display(Name = "UserName")]
        public string UserName
        {
            get
            { return LName + "," + FName ; }
        }
    }
}
