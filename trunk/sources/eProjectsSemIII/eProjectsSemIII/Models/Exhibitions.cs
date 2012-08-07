using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Exhibitions
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name must be at least 20 characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

         [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        // relationship many to many with design and Customers

    }
}