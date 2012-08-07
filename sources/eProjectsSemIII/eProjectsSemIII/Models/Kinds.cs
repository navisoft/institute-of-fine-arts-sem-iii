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
        public string Name { get; set; }

        //one to many with design
        public ICollection<Designs> Design { get; set; }
    }
}