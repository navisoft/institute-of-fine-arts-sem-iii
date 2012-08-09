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
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        //one to many with member
        public ICollection<Members> Member { get; set; }

        //many to many with Menu
        public ICollection<Menus> Menu { get; set; }

        /**
         * Function: GetRoleWithID
         * List Menu through Role ID
         * @returns: Roles and list Menus
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public Roles GetRoleWithID()
        {
            Roles roles = new Roles();
            using (var db = new FineArtContext())
            {
                roles = (Roles)db.Roles.Include("Menu").Where(r => r.ID == this.ID).FirstOrDefault();
            }
            return roles;
        }
    }
}