using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Menus
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        [Required(ErrorMessage = "Number of credits is required.")]
        public int ParentID { get; set; }

        public string Icon { get; set; }
        [Required(ErrorMessage = "Description is required.")]
      
        public string Description { get; set; }
        public bool Display { get; set; }

        //many to many with Roles
        public ICollection<Roles> Role { get; set; }

        /**
         * Function: CheckMenuOfRole
         * Check exists of menu by roleID
         * @param name="roleID": role ID of user
         * @returns: 
         * true: exists menu with role
         * false: not exists menu with role
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public bool CheckMenuOfRole(int roleID)
        {
            using (var db = new FineArtContext())
            {
                var query = from m in db.Menus.Include("Role")
                            where m.Controller == this.Controller && m.Action == this.Action
                            select m;
                foreach (Menus menus in query)
                {
                    ICollection<Roles> listRole = menus.Role;
                    foreach (Roles roles in listRole)
                    {
                        if (roles.ID == roleID)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}