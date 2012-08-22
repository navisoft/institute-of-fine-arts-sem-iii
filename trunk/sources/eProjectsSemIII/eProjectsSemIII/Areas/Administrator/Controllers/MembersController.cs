using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Models;
using eProjectsSemIII.Areas.Administrator;
using eProjectsSemIII.Configs;
using System.Security.Cryptography;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: MemberController
     * Any user who wants to go to administrator page must login
     * Author: Le Dang Son
     * Date: 06/08/2012
     */
    public class MembersController : AuthenticationController
    {
        /**
         * Controller: Members
         * Action: Index
         * Show login form and check admin
         * 
         * @param name="form":data for login
         * @returns:if is admin:redirect to admin index page else show login form
         * 
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Members membersModels = new Members();
            decimal totalMember = membersModels.TotalMember();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalMember / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/members/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Members";
            return View(membersModels.ListMembers((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult MembersClass(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Classes classModels = new Classes();
                classModels.ID = idd;
                classModels = classModels.GetNavigationWithID("Member");
                ViewBag.Title += " Members of " + classModels.Name + " Class";
                List<Members> listMembers = classModels.Member.ToList();
                List<Members> listMembersNew = new List<Members>();
                listMembers.ForEach(delegate(Members member)
                {
                    member = member.GetMemberWithID();
                    listMembersNew.Add(member);
                });
                return View(listMembersNew);
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }

        public ActionResult Edit(string id, FormCollection form)
        {
            base.Authentication();
            base.LoadMenu();
            try
            {
                var db = new FineArtContext();
                int memberID = Convert.ToInt16(id);
                var member = db.Members.Include("Role").Include("Class").Where(m => m.ID == memberID).First();
                ViewBag.listRole = db.Roles.ToList();
                ViewBag.listClass = db.Classes.ToList();
                if (form["submit_member"] == null)
                {
                    form["Name"] = member.Name;
                    form["Username"] = member.Username;
                    form["Role"] = member.Role.ID.ToString();
                    form["Email"] = member.Email;
                    form["Address"] = member.Address;
                    form["Phone"] = member.Phone;
                    if (member.Class != null)
                    {
                        form["Class"] = member.Class.ID.ToString();
                    }
                    form["Gender"] = member.Gender;
                    form["Birthday"] = member.Birthday.ToString();
                    form["Datejoin"] = member.Datejoin.ToString();

                    ViewBag.dataForm = form;
                    return View();
                }
                else
                {
                    int roleID = Convert.ToInt16(form["Role"]);
                    var role = db.Roles.Where(r => r.ID == roleID).First();
                    int classID = Convert.ToInt16(form["Class"]);
                    var classs = db.Classes.Where(c => c.ID == classID).First();
                    member.Role = role;
                    member.Class = classs;
                    db.SaveChanges();
                    ViewBag.success = "Update member successfully!";
                    ViewBag.dataForm = form;
                    return View();
                }
            }
            catch
            {
                return null;
            }
        }

        public ActionResult Login(FormCollection form)
        {
            if (Session["user-loged"] != null)
            {
                if (Session["total_login"] != null && 4 - (int)Session["total_login"] <= 0)
                {
                    return Redirect("~/");
                }
                else
                {
                    if (form["submit_admin_login"] != null && form["submit_admin_login"] == "Login Admin")
                    {
                        Members membersModels = new Members();
                        Strings stringLib = new Strings();
                        MD5 md5Hash = MD5.Create();
                        string password = form["password"];
                        password = stringLib.GetMd5Hash(md5Hash, stringLib.GetMd5Hash(md5Hash, password) + "hashpassword");
                        membersModels = membersModels.GetMemberByUserAndPass(form["username"], password);
                        try
                        {
                            if (membersModels.Name != null && membersModels.Name != "")
                            {
                                Session["admin"] = membersModels;
                                return Redirect("/administrator/");
                            }
                            else
                            {
                                if (Session["total_login"] == null)
                                {
                                    Session["total_login"] = 1;
                                }
                                else
                                {
                                    string path = Server.MapPath("~/");
                                    Log log = new Log(path, "LoginController.Index");
                                    log.WriteLog("Username: " + form["username"] + " Password: " + form["password"]);
                                    Session["total_login"] = (int)Session["total_login"] + 1;
                                }
                                ViewBag.form_error = "Username or password wrong. Try again! You have to login " +
                                        (5 - (int)Session["total_login"]) + " time!";
                            }
                        }
                        catch (Exception e)
                        {
                            string path = Server.MapPath("~/");
                            Log log = new Log(path, "LoginController.Login");
                            if (Session["total_login"] == null)
                            {
                                Session["total_login"] = 1;
                            }
                            else
                            {
                                string pathother = Server.MapPath("~/");
                                Log objLog = new Log(path, "LoginController.Login");
                                objLog.WriteLog(e.Message.ToString());
                                log.WriteLog("Username: " + form["username"] + " Password: " + form["password"]);
                                Session["total_login"] = (int)Session["total_login"] + 1;
                            }
                            ViewBag.form_error = "Username or password wrong. Try again! You have to login " +
                                    (5 - (int)Session["total_login"]) + " time!";
                        }
                    }
                }
            }
            else
            {
                return Redirect("~/member");
            }
            return View();
        }
        /**
         * Controller: Members
         * Action: Logout
         * User logout system
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public ActionResult Logout()
        {
            Session["admin"] = null;
            return Redirect("/administrator/members/login");
        }

        public ActionResult Delete(string id)
        {
            //base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                List<Marks> listMark = db.Marks.Where(m => m.Staff.ID == idd).ToList();
                listMark.ForEach(delegate(Marks mark)
                {
                    mark.Staff = null;
                    db.SaveChanges();
                });
                Members member = db.Members.Where(m => m.ID == idd).First();
                db.Members.Remove(member);
                db.SaveChanges();
                return Redirect("~/administrator/members/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
    }
}
