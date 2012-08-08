using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eProjectsSemIII.Models;
namespace eProjectsSemIII.Areas.Administrator.Models
{
    public class MenusAdmin : Menus
    {
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