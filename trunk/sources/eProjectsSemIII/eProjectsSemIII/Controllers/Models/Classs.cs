using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Classs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StaffID { get; set; }
        public Staffs Staff { get; set; }
        public ICollection<Students> Student { get; set; }
    }
}