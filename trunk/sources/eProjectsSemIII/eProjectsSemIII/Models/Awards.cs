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
        public ICollection<Students> Student { get; set; }
        public ICollection<Competitions> Competition { get; set; }
    }
}