using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class Events
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Mname")]
        public string Mname { get; set; }
        [StringLength(10, ErrorMessage = "Price cannot be over 10 characters")]
        [Display(Name = "Price")]
        public string Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(0:dd:mm:yyyy)", ApplyFormatInEditMode = true)] //"The datatype attribute allows the data to be rendered on a screen using a DateTime datatype.
        [Display(Name = "Date")] 
        public string Date { get; set; }

        [StringLength(7, ErrorMessage = "Time cannot be longer than 7 characters")]
        [Display(Name = "Time")]
        public string Time { get; set; }
        [StringLength(100)]
        [Display(Name = "Availability")]
        public string Availability { get; set; }


        public ICollection<EAddress> EAddresses { get; set; }
        public ICollection<EInfo> EInfos { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
