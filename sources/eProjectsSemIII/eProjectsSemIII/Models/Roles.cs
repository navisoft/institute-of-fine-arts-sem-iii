using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Roles
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The name must be at least 20 characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        //one to many with member
        public ICollection<Members> Member { get; set; }

        //many to many with Menu
        public ICollection<Menus> Menu { get; set; }

        public bool GetMenuRole()
        {
            using (var db = new FineArtContext())
            {
                var query = (from r in db.Roles
                            where r.ID == this.ID
                            select new { Menu }).FirstOrDefault();

            }
            return true;
        }
    }
}