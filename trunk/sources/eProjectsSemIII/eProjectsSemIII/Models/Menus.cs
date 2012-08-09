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

        //[Required(ErrorMessage = "Number of credits is required.")]
        public int ParentID { get; set; }

        public string Icon { get; set; }
        //[Required(ErrorMessage = "Description is required.")]
      
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
            var db = new FineArtContext();
            var query = db.Menus.Include("Role")
                .Where(m=>m.Controller == ((this.Controller == "index")?"":this.Controller)
                    && m.Action == ((this.Action == "index")?"":this.Action))
                    .FirstOrDefault();
            if (query != null)
            {
                var query2 = query.Role.Where(r => r.ID == roleID).FirstOrDefault();
                if (query2 == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /**
         * Function: ListMenu
         * Get list menus system
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public List<Menus> ListMenu()
        {
            var db = new FineArtContext();
            var query = db.Menus.ToList();
            return query;
        }
    }
}