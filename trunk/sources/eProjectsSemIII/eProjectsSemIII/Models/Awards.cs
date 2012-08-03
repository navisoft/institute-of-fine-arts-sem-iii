using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Awards
    {
        public int ID { get; set; }
        public string Description { get; set; }
        // many to many with competition
        public ICollection<Competitions> Competition { get; set; }
       // public ICollection<Students> Student { get; set; }
      
    }
}