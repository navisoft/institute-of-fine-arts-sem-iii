using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Competitions
    {

        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Images { get; set; }
        public string summary { get; set; }

        //many to many
        public ICollection<Conditions> Condition { get; set; }
        public ICollection<Awards> Award { get; set; }

        //one to many with design
        public ICollection<Designs> Design { get; set; }
       
    }
}