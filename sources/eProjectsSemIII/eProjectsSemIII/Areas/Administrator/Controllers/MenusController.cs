using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using System.Text;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: MenusController
     * Manage Menus System
     * Author: Le Dang Son
     * Date: 08/08/2012
     */
    public class MenusController : AuthenticationController
    {

        /**
         * Controller: Menus
         * Action: Index
         * List All menu system
         * Author: Le Dang Son
         * Date: 08/08/2012
         */
        public ActionResult Index()
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                List<Menus> listMenu = new FineArtContext().Menus.ToList();
                ViewBag.Title += " Menus";
                listMenu.ForEach(delegate(Menus menu)
                {
                    if (menu.Controller == "")
                    {
                        menu.Controller = "Index";
                    }
                    if (menu.Action == "")
                    {
                        menu.Action = "Index";
                    }
                    Strings stringsLibs = new Strings();
                    menu.Controller = stringsLibs.Capacital(menu.Controller);
                    menu.Action = stringsLibs.Capacital(menu.Action);
                });
                ViewBag.listMenu = listMenu;
                return View();
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult MenusRole(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                try
                {
                    int idd = Convert.ToInt16(id);
                    Roles role = new Roles();
                    role.ID = idd;
                    role = role.GetRoleWithID();
                    List<Menus> listMenu = role.Menu.ToList();
                    listMenu.ForEach(delegate(Menus menu)
                    {
                        if (menu.Controller == "")
                        {
                            menu.Controller = "Index";
                        }
                        if (menu.Action == "")
                        {
                            menu.Action = "Index";
                        }
                        Strings stringsLibs = new Strings();
                        menu.Controller = stringsLibs.Capacital(menu.Controller);
                        menu.Action = stringsLibs.Capacital(menu.Action);
                    });
                    ViewBag.RoleID = idd;
                    ViewBag.Title += " Menus for " + role.Name;
                    ViewBag.listMenu = listMenu;
                }
                catch
                {

                }
                return View();
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult AddMenuRole(string id, FormCollection form)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                try
                {
                    var db = new FineArtContext();
                    int roleID = Convert.ToInt16(id);
                    var role = db.Roles.Include("Menu").Where(r => r.ID == roleID).First();
                    var listMenus = db.Menus.ToList();
                    listMenus = listMenus.Except(role.Menu).ToList();
                    ViewBag.listMenus = listMenus;
                    if (form["submit_menu"] != null)
                    {
                        Strings stringModels = new Strings();
                        int[] IDMenus = stringModels.ListID(form["Menus"]);
                        ICollection<Menus> listMenu = db.Menus.Where(s => IDMenus.Contains(s.ID)).ToList();
                        foreach (Menus menu in listMenu)
                        {
                            role.Menu.Add(menu);
                        }
                        db.SaveChanges();
                        return Redirect("~/administrator/menus/addmenurole/" + roleID);
                    }
                    return View();
                }
                catch
                {
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult RemoveMenuRole(string id, string param)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int idd = Convert.ToInt16(id);
                    int paramm = Convert.ToInt16(param);
                    var db = new FineArtContext();
                    Roles role = db.Roles.Include("Menu").Where(r => r.ID == paramm).First();
                    var listMenu = role.Menu;
                    var menu = db.Menus.Where(m => m.ID == idd && m.ParentID != -1).First();
                    listMenu.Remove(menu);
                    db.SaveChanges();
                    return Redirect("~/administrator/menus/menusrole/" + idd);
                }
                catch
                {
                    Session["admin"] = null;
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Disable(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int idd = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    Menus menu = db.Menus.Where(m => m.ID == idd).First();
                    menu.Display = false;
                    db.SaveChanges();
                    return Redirect("~/administrator/menus/");
                }
                catch
                {
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Enable(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int idd = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    Menus menu = db.Menus.Where(m => m.ID == idd).First();
                    menu.Display = true;
                    db.SaveChanges();
                    return Redirect("~/administrator/menus/");
                }
                catch
                {
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Add(FormCollection form, HttpPostedFileBase Icon)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                var db = new FineArtContext();
                var query = db.Menus.Where(m => m.ParentID == -1);
                if (form["submit_menu"] != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type menu name</li>");
                    }
                    else
                    {
                        try
                        {
                            string name = form["Name"];
                            var menu = db.Menus.Where(m => m.Name == name).First();
                            stringBuilder.Append("<li>This menu had been exists in database. Try a different.</li>");
                        }
                        catch
                        {

                        }
                    }

                    int Parent = Convert.ToInt16(form["Parent"]);
                    bool Display = false;
                    if (Parent != -1)
                    {
                        try
                        {
                            Menus menu = db.Menus.Where(m => m.ID == Parent && m.ParentID == -1).First();
                            if (form["Display"] == "on")
                            {
                                Display = true;
                            }
                        }
                        catch
                        {
                            stringBuilder.Append("<li>Please chose parent menu for this menu</li>");
                        }
                    }
                    else
                    {
                        Display = true;
                        if (Icon == null)
                        {
                            stringBuilder.Append("<li>Please chose icon for this menu</li>");
                        }
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        if (Icon != null)
                        {
                            ImagesClass imageClass = new ImagesClass(Icon);
                            string path = Server.MapPath("~/Content/Images/admins/menu-icon" + form["Alias"] + ".jpg");
                            imageClass.CreateNewImage(path, 18, 16);
                        }
                        Menus menu = new Menus
                        {
                            Name = form["Name"].Trim(),
                            Controller = form["Controller"].Trim(),
                            Action = form["Action"].Trim(),
                            Description = form["Description"].Trim(),
                            Display = Display,
                            Icon = form["Alias"].Trim() + ".jpg",
                            ParentID = Parent
                        };
                        db.Menus.Add(menu);
                        db.SaveChanges();
                        ViewBag.success = "Add menu success!";
                    }
                    else
                    {
                        stringBuilder.Append("</ul>");
                        ViewBag.error = stringBuilder.ToString();
                        ViewBag.dataForm = form;
                    }
                }
                ViewBag.parentMenu = query;
                return View();
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
        public ActionResult Edit(string id, FormCollection form, HttpPostedFileBase Icon)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                try
                {
                    var db = new FineArtContext();
                    var query = db.Menus.Where(m => m.ParentID == -1);
                    int idd = Convert.ToInt16(id);
                    var menu = db.Menus.Where(m => m.ID == idd).FirstOrDefault();
                    if (form["submit_menu"] == null)
                    {
                        form["Name"] = menu.Name;
                        form["Controller"] = menu.Controller;
                        form["Action"] = menu.Action;
                        if (menu.Display)
                        {
                            form["Display"] = "on";
                        }
                        form["Parent"] = menu.ParentID.ToString();
                        form["Description"] = menu.Description;
                    }
                    else
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("<ul>");
                        Strings stringsLibs = new Strings();
                        if (form["Name"].Trim() == "")
                        {
                            stringBuilder.Append("<li>Please type menu name</li>");
                        }
                        else
                        {
                            if (form["Name"].Trim() != menu.Name)
                            {
                                try
                                {
                                    string name = form["Name"];
                                    menu = db.Menus.Where(m => m.Name == name).First();
                                    stringBuilder.Append("<li>This menu had been exists in database. Try a different.</li>");
                                }
                                catch
                                {

                                }
                            }
                        }
                        int Parent = Convert.ToInt16(form["Parent"]);
                        bool Display = false;
                        if (Parent != -1)
                        {
                            try
                            {
                                menu = db.Menus.Where(m => m.ID == Parent && m.ParentID == -1).First();
                                if (form["Display"] == "on")
                                {
                                    Display = true;
                                }
                            }
                            catch
                            {
                                stringBuilder.Append("<li>Please chose parent menu for this menu</li>");
                            }
                        }
                        else
                        {
                            Display = true;
                        }
                        if (stringBuilder.ToString() == "<ul>")
                        {
                            if (Icon != null)
                            {
                                ImagesClass imageClass = new ImagesClass(Icon);
                                string path = Server.MapPath("~/Content/Images/admins/menu-icon" + form["Alias"] + ".jpg");
                                imageClass.CreateNewImage(path, 18, 16);
                            }
                            menu = db.Menus.Where(m => m.ID == idd).First();
                            menu.Name = form["Name"].Trim();
                            menu.Controller = form["Controller"].Trim();
                            menu.Action = form["Action"].Trim();
                            menu.Description = form["Description"].Trim();
                            menu.Display = Display;
                            menu.Icon = form["Alias"].Trim() + ".jpg";
                            menu.ParentID = Parent;
                            db.SaveChanges();
                            ViewBag.success = "Update menu success!";
                            base.LoadMenu();
                        }
                        else
                        {
                            stringBuilder.Append("</ul>");
                            ViewBag.error = stringBuilder.ToString();
                            ViewBag.dataForm = form;
                        }
                    }
                    ViewBag.dataForm = form;
                    ViewBag.parentMenu = query;
                    return View();
                }
                catch
                {
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
        public ActionResult Delete(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int idd = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    Menus menu = db.Menus.Where(m => m.ID == idd && m.ParentID != -1).First();
                    db.Menus.Remove(menu);
                    db.SaveChanges();
                    return Redirect("~/administrator/menus");
                }
                catch
                {
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
    }
}
