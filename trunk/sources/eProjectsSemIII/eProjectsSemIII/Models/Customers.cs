using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Customers
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name must be at least 20 characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Address must be at least 50 characters long.", MinimumLength = 6)]
        public string Address { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Phone must be at least 20 characters long.", MinimumLength = 6)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Gender must be at least 10 characters long.", MinimumLength = 3)]
        public string Gender { get; set; }
      
        // relationship many to many with design and Exhibitions
       
    }
}