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
        [StringLength(100)]
        [Display(Name = "LName")]
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
    }
}
