using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Exhibitions
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        //many to many
        public ICollection<Designs> Design { get; set; }
        public ICollection<Customers> Customer { get; set; }
    
    }
}