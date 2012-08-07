using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;

namespace eProjectsSemIII.Models
{
    public class Roles
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        //one to many with member
        public ICollection<Members> Member { get; set; }

        ////many to many with Menu
        public ICollection<Menus> Menu { get; set; }
        public Roles GetMenuRole()
        {
            Roles role = new Roles();
            using (var db = new FineArtContext())
            {
                var query = (from r in db.Roles
                             where r.ID == this.ID
                             select r).FirstOrDefault();
                role = (Roles)query;
            }
            return role;
        }
    }
}