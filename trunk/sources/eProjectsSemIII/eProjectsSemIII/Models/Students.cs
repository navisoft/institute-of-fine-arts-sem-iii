using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Students
    {
        public int ID { get; set; }
         [Required(ErrorMessage = "username is required.")]
        public string Username { get; set; }
         [Required(ErrorMessage = "password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "name is required.")]
        //[Column("FirstName")]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        public int Address { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Datejoin { get; set; }
        //many to may
        public ICollection<Competitions> Competition { get; set; }
        public ICollection<Awards> Award { get; set; }
        public ICollection<Classs> Class { get; set; }
        //one to many
        public ICollection<Designs> Design { get; set; }
    }
}