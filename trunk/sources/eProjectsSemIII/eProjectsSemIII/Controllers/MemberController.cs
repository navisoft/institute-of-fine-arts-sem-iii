using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;

namespace eProjectsSemIII.Controllers
{
    public class MemberController : AuthenticationController
    {
        //
        // GET: /Members/

        public ActionResult Index(FormCollection form)
        {
            try
            {
                HttpCookie userCookie = new HttpCookie("username");
                userCookie = Request.Cookies["username"];
                HttpCookie passCookie = new HttpCookie("password");
                passCookie = Request.Cookies["password"];
                MD5 md5Hash = MD5.Create();
                Strings stringLib = new Strings();
                if (userCookie != null && passCookie != null)
                {
                    Members memberOther = new FineArtContext()
                            .Members
                            .Where(m => m.Username == userCookie.Value && m.Password == passCookie.Value)
                            .First();
                    if (memberOther == null)
                    {
                        return View();
                    }
                    else
                    {
                        Session["user-loged"] = userCookie.Value;
                        return Redirect("~/");
                    }
                }
                else
                {
                    if (form["submit-login"] != null)
                    {
                        try
                        {
                            string username = form["username"];
                            string password = form["password"];
                            password = stringLib.GetMd5Hash(md5Hash, stringLib.GetMd5Hash(md5Hash, password) + "hashpassword");
                            Response.Write(password);
                            Members member = new FineArtContext()
                                .Members
                                .Where(m => m.Username == username && m.Password == password)
                                .First();
                            if (member == null)
                            {
                                ViewBag.error = "Username or password wrong. Try again!";
                                return View();
                            }
                            else
                            {
                                Session["user-loged"] = username;
                                if (form["remember"] == "on")
                                {
                                    Response.Cookies["username"].Value = form["username"];
                                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(31);
                                    Response.Cookies["password"].Value = password;
                                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(31);
                                }
                                return Redirect("~/");
                            }
                        }
                        catch
                        {
                            ViewBag.error = "Username or password wrong. Try again!";
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Register(FormCollection form, HttpPostedFileBase Images)
        {
            if (Session["user-loged"] == null)
            {
                if (form["submit-register"] != null)
                {
                    var db = new FineArtContext();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    if (form["name"].Trim() == "" || form["name"].Trim().ToLower() == "full name")
                    {
                        stringBuilder.Append("<li>Please type your full name.</li>");
                    }
                    if (form["username"].Trim() == "" || form["username"].Trim().ToLower() == "username")
                    {
                        stringBuilder.Append("<li>Please type username.</li>");
                    }
                    else
                    {
                        string username = form["username"].Trim();
                        Members member = db.Members.Where(m => m.Username == username).FirstOrDefault();
                        if (member != null)
                        {
                            stringBuilder.Append("<li>Has been exists this username in database. Try other username.</li>");
                        }
                    }
                    if (!Validator.ISEmail(form["email"]))
                    {
                        stringBuilder.Append("<li>Email not valid.</li>");
                    }
                    else if (form["email"] != form["verifyemail"])
                    {
                        stringBuilder.Append("<li>Please verify email.</li>");
                    }
                    else
                    {
                        string email = form["email"].Trim();
                        Members member = db.Members.Where(m => m.Email == email).FirstOrDefault();
                        if (member != null)
                        {
                            stringBuilder.Append("<li>This email has been using. Try other email.</li>");
                        }
                    }

                    if (form["password"].Trim() == "" || form["password"].Trim().ToLower() == "password")
                    {
                        stringBuilder.Append("<li>Please type password.</li>");
                    }
                    else if (form["password"] != form["verifypassword"])
                    {
                        stringBuilder.Append("<li>Please verify password.</li>");
                    }
                    string birthday = form["day"] + "/" + form["month"] + "/" + form["year"];
                    DateTime Birthday = new DateTime();
                    try
                    {
                        Birthday = DateTime.Parse(birthday);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Your birthday not valid.</li>");
                    }

                    if (form["address"].Trim() == "" || form["address"].Trim().ToLower() == "address")
                    {
                        stringBuilder.Append("<li>Please type your address.</li>");
                    }

                    if (form["phone"].Trim() == "" || form["phone"].Trim().ToLower() == "phone")
                    {
                        stringBuilder.Append("<li>Please type your phone.</li>");
                    }
                    else if (!Validator.ISPhoneNumber(form["phone"]))
                    {
                        stringBuilder.Append("<li>Your phone number not valid.</li>");
                    }

                    if (Images == null)
                    {
                        stringBuilder.Append("<li>Please choose your avatar.</li>");
                    }
                    string gender;
                    switch (form["gender"])
                    {
                        case "0": gender = "Male"; break;
                        case "1": gender = "Female"; break;
                        default: gender = "Male"; break;
                    }

                    if (stringBuilder.ToString() == "<ul>")
                    {
                        MD5 md5Hash = MD5.Create();
                        Strings stringLib = new Strings();
                        string password = stringLib.GetMd5Hash(md5Hash, stringLib.GetMd5Hash(md5Hash, form["password"]) + "hashpassword");
                        eProjectsSemIII.Models.Roles role = db.Roles.Where(r => r.ID == 4).First();
                        ImagesClass imageLib = new ImagesClass(Images);
                        string path = Server.MapPath("~/Content/Images/students/" + form["username"] + ".jpg");
                        imageLib.CreateNewImage(path, 200, 240);
                        Members member = new Members
                        {
                            Name = form["name"].Trim(),
                            Username = form["username"].Trim(),
                            Password = password,
                            Email = form["email"].Trim(),
                            Birthday = Birthday,
                            Address = form["address"].Trim(),
                            Phone = form["phone"].Trim(),
                            Gender = gender,
                            Datejoin = DateTime.Now,
                            Images = form["username"].Trim() + ".jpg",
                            Role = role,
                        };
                        db.Members.Add(member);
                        db.SaveChanges();
                        ViewBag.success = true;
                    }
                    else
                    {
                        ViewBag.dataForm = form;
                        stringBuilder.Append("</ul>");
                        ViewBag.error = stringBuilder.ToString();
                    }
                }
            }
            else
            {
                return Redirect("~/");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user-loged"] = null;
            if (Request.Cookies["username"] != null)
            {
                HttpCookie userCookie = new HttpCookie("username");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }
            if (Request.Cookies["password"] != null)
            {
                HttpCookie passCookie = new HttpCookie("password");
                passCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(passCookie);
            }
            return Redirect("~/member");
        }
    }
}
