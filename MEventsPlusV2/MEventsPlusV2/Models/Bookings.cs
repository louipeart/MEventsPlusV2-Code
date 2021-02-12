using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class Bookings
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "CPname")]
        public string CPname { get; set; }
        [StringLength(13, ErrorMessage = "Cost cannot be longer than 13 characters")]
        [Display(Name = "Cost")]
        public string Cost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(0:dd:mm:yyyy)", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public string Date { get; set; }
        [Required]
        [StringLength(7)]
        [Display(Name = "Time")]
        public string Time { get; set; }
        //public ICollection<Customer> Customers { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
