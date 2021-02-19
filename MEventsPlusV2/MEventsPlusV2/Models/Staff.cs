using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string FName { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "FName cannot be longer than 100 characters")]
        [Display(Name = "LName")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")] //Regular expression making sure letters are only used, uppercase letter must be used at the beginning, special characters are not allowed.
        public string LName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Telno cannot be longer than 11 characters")]
        [Display(Name = "Telno")]
        public string Telno { get; set; }
        [StringLength(50)]
        [Display(Name = "Jobrole")]
        public string Jobrole { get; set; }
        public ICollection<SInfo> SInfos { get; set; }
        public ICollection<SAddress> SAddresses { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
