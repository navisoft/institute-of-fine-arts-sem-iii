using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Classs
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //many to many with members
        public ICollection<Members> Member { get; set; }
                
    }
}