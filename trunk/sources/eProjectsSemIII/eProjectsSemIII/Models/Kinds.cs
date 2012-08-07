using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Kinds
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Name must be at least 20 characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        //one to many with design
        public ICollection<Designs> Design { get; set; }
    }
}