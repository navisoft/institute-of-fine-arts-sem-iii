using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Designs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StudentID { get; set; }
        public Students Student { get; set; }
        //one to many
        public int KindID { get; set; }
        public Kinds Kind { get; set; }
        //many to many
        public ICollection<Competitions> Competition { get; set; }
        public ICollection<Staffs> Staff { get; set; }
        public ICollection<Exhibitions> Exhibition { get; set; }
        public ICollection<Customers> Customer { get; set; }
    }
}