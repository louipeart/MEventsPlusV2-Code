using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEventsPlusV2.Models
{
    public class CAddress
    {
        public int ID { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Postcode cannot be longer than 10 characters")]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }
        [StringLength(100)]
        [Display(Name = "State")]
        public string State { get; set; }
        public ICollection<CAddress> CAddresses { get; set; }
    }
}
