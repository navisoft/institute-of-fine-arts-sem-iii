using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using System.Text;
using eProjectsSemIII.Libs;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: RolesController
     * Manage Roles System
     * Author: Le Dang Son
     * Date: 08/08/2012
     */
    public class RolesController : AuthenticationController
    {
        /**
         * Controller: Roles
         * Action: Index
         * List all roles system
         * Author: Le Dang Son
         * Date: 08/08/2012
         */

        public ActionResult Index()
        {
            base.Authentication();
            base.LoadMenu();
            Roles rolesModels = new Roles();
            ViewBag.listRole = rolesModels.ListRole();
            ViewBag.Title += " Roles";
            return View();
        }

        public ActionResult Add(FormCollection form)
        {
            base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            ViewBag.listMenu = db.Menus.ToList();
            if (form["submit_role"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type role name</li>");
                }
                if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                {
                    stringBuilder.Append("<li>Please type role alias</li>");
                }
                else
                {
                    try
                    {
                        string alias = form["Alias"].Trim().ToString();
                        var role = db.Roles.Where(c => c.Alias == alias).First();
                        stringBuilder.Append("<li>This role alias had been exists in database, try a different</li>");
                    }
                    catch { }
                }
                int[] IDMenus = stringsLibs.ListID(form["Menus"]);
                ViewBag.IDMenus = IDMenus;
                ICollection<Menus> listMenus = db.Menus.Where(s => IDMenus.Contains(s.ID)).ToList();
                if (stringBuilder.ToString() == "<ul>")
                {
                    Roles roles = new Roles
                    {
                        Name = form["Name"].Trim(),
                        Alias = form["Alias"].Trim(),
                        Description = form["Description"].Trim(),
                        Menu = listMenus
                    };
                    db.Roles.Add(roles);
                    db.SaveChanges();
                    ViewBag.success = "Add role success!";
                }
                else
                {
                    stringBuilder.Append("</ul>");
                    ViewBag.error = stringBuilder.ToString();
                    ViewBag.dataForm = form;
                }
            }

            return View();
        }

        public ActionResult Edit(string id, FormCollection form)
        {
            base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                var listMenu = db.Menus.ToList();
                ViewBag.listMenu = listMenu;
                Roles role = db.Roles.Include("Menu").Where(r => r.ID == idd).First();
                ICollection<Menus> listMenus;
                int[] IDMenus;
                if (form["submit_role"] == null)
                {
                    form["Name"] = role.Name;
                    form["Alias"] = role.Alias;
                    form["Description"] = role.Description;
                    ViewBag.dataForm = form;
                    listMenus = role.Menu;
                    IDMenus = new int[listMenus.Count];
                    int i = 0;
                    foreach (Menus menu in listMenus)
                    {
                        IDMenus[i] = menu.ID;
                        i++;
                    }
                    ViewBag.IDMenus = IDMenus;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type role name</li>");
                    }
                    if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                    {
                        stringBuilder.Append("<li>Please type role alias</li>");
                    }
                    else
                    {
                        string alias = form["Alias"].Trim().ToString();
                        if (alias != role.Alias)
                        {
                            try
                            {
                                role = db.Roles.Where(c => c.Alias == alias).First();
                                stringBuilder.Append("<li>This role alias had been exists in database, try a different</li>");
                            }
                            catch { }
                        }
                    }
                    if (role.ID != 1)
                    {
                        IDMenus = stringsLibs.ListID(form["Menus"]);
                        listMenus = db.Menus.Where(s => IDMenus.Contains(s.ID)).ToList();
                        ViewBag.IDMenus = IDMenus;
                    }
                    else
                    {
                        listMenus = listMenu;
                        IDMenus = new int[listMenus.Count];
                        int i = 0;
                        foreach (Menus menu in listMenus)
                        {
                            IDMenus[i] = menu.ID;
                            i++;
                        }
                        ViewBag.IDMenus = IDMenus;
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        role = db.Roles.Where(r => r.ID == idd).First();
                        role.Name = form["Name"].Trim();
                        role.Alias = form["Alias"].Trim();
                        role.Description = form["Description"].Trim();
                        role.Menu = listMenus;
                        db.SaveChanges();
                    }
                    else
                    {
                        stringBuilder.Append("</ul>");
                        ViewBag.error = stringBuilder.ToString();
                        ViewBag.dataForm = form;
                    }
                }
            }
            catch
            {

            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                if (idd != 1)
                {
                    var db = new FineArtContext();
                    var role = db.Roles.Where(r => r.ID == idd).First();
                    var members = db.Members.Where(m => m.Role.ID == role.ID).ToList();
                    members.ForEach(delegate(Members member)
                    {
                        member.Role = null;
                        db.SaveChanges();
                    });
                    db.Roles.Remove(role);
                    db.SaveChanges();
                }
                return Redirect("~/administrator/roles/");
            }
            catch
            {
                return Redirect("~/");
            }
        }

    }
}
