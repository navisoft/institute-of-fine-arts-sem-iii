using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Roles
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        //one to many with member
        public ICollection<Members> Member { get; set; }

        //many to many with Menu
        public ICollection<Menus> Menu { get; set; }
     
    }
}