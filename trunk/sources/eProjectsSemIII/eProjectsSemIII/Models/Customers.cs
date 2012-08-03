using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        //many to many
        public ICollection<Designs> Design { get; set; }
        public ICollection<Exhibitions> Exhibition { get; set; }
       
    }
}