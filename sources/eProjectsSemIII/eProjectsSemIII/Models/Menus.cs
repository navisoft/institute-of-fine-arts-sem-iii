using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Menus
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        [Required(ErrorMessage = "Number of credits is required.")]
        [Range(0, 5, ErrorMessage = "Number of credits must be between 0 and 9.")]
        public int ParentID { get; set; }

        public string Icon { get; set; }
        [Required(ErrorMessage = "Description is required.")]
      
        public string Description { get; set; }
        public bool Display { get; set; }

        //many to many with Roles
        public ICollection<Roles> Role { get; set; }

    }
}