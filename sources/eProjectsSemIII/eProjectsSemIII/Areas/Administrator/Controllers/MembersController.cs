using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Models;
using eProjectsSemIII.Areas.Administrator;

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
            ////base.Authentication();
            //base.LoadMenu();
            //int currentPage = Paging.GetPage(id);
            //decimal totalRecord = GlobalInfo.NumberRecordInPage;
            //Members membersModels = new Members();
            //decimal totalMember = membersModels.TotalMember();
            //int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalMember / totalRecord));
            //Paging.numPage = totalPage;
            //Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            //Paging.currentPage = currentPage;
            //string url = "administrator/members/index";
            //ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            //ViewBag.Title += " Members";
            //return View(membersModels.ListMembers((int)((currentPage - 1) * totalRecord), (int)totalRecord));
            return View();
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
                return Redirect("~/");
            }
        }

        public ActionResult Login(FormCollection form)
        {
            if (Session["total_login"] != null && 4 - (int)Session["total_login"] <= 0)
            {
                return Redirect("/");
            }
            else
            {
                if (form["submit_admin_login"] != null && form["submit_admin_login"] == "Login Admin")
                {
                    Members membersModels = new Members();
                    membersModels = membersModels.GetMemberByUserAndPass(form["username"], form["password"]);
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
    }
}
