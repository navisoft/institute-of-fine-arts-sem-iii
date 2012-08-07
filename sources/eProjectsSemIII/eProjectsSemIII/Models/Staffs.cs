using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Staffs
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Datejoin { get; set; }
        //many to many
        public ICollection<Classs> Class { get; set; }
        public ICollection<Competitions> Competition { get; set; }
        public ICollection<Designs> Design { get; set; }


    }
}