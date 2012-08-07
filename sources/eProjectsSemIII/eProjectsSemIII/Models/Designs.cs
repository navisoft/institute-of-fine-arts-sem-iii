using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Designs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The Description must be at least 50 characters long.", MinimumLength = 6)]
        public string Description { get; set; }
        //one to many
        public int MemberID { get; set; }
        public Members Member { get; set; }
        //one to many
        public int KindID { get; set; }
        public Kinds Kind { get; set; }
     
     
    }
}