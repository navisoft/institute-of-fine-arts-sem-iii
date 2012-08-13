using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Marks
    {
        public int ID { get; set; }
        public Members Staff { get; set; }
        public int Mark { get; set; }
        public string ReMark { get; set; }
        public Designs Design { get; set; }
        public Competitions Competition { get; set; }
    }
}