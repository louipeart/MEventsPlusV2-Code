using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class Customer : User
    {
        public int ID1 { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(0:dd:mm:yyyy)", ApplyFormatInEditMode = true)]
        [Display(Name = "Dateofbirth")]
        public DateTime Dateofbirth { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Telno cannot be longer than 11 characters")] //Error message allows the user to be restricted to the aunt of characters they use
        [Display(Name = "Telno")]
        public string Telno { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public ICollection<User> Userss { get; set; }
        public ICollection<CAddress> CAddresses { get; set; }
        public ICollection<CInfo> CInfos { get; set; }
       //public ICollection<Bookings> Bookings { get; set; }
    }
}
