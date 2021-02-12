using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class CInfo
    {
        public int ID { get; set; }
        [StringLength(100)]
        [Display(Name = "FName")]
        public string FName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "LName")]
        public string LName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(0:dd:mm:yyyy)", ApplyFormatInEditMode = true)]
        [Display(Name = "Dateofbirth")]
        public DateTime Dateofbirth { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Telno cannot be longer than 11 characters")]
        [Display(Name = "Telno")]
        public string Telno { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public ICollection<CInfo> CInfos { get; set; }
    }
}
