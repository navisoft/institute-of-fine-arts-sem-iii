using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Awards
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // many to many with competition
        public ICollection<Competitions> Competition { get; set; }
       
      
    }
}