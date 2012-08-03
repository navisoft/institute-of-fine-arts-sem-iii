using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Kinds
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Designs> Design { get; set; }
    }
}