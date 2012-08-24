using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Models;
using System.Text;
using eProjectsSemIII.Configs;
using System.Dynamic;

namespace eProjectsSemIII.Controllers
{

    public class DesignsKind
    {
        public Designs Design { get; set; }
        public Members Member { get; set; }
    }
    public class DesignController : AuthenticationController
    {
        //
        // GET: /Designs/

        public ActionResult Index(string id)
        {
            base.Authentication();
            var db = new FineArtContext();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            decimal totalDesign = db.Designs.Count();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
            if (currentPage > totalPage)
            {
                currentPage = totalPage;
            }
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            var design = db.Designs.Include("Member").Include("Kind").Include("Competition")
                              .OrderBy(p => p.ID)
                              .Skip((int)((currentPage - 1) * totalRecord))
                              .Take((int)totalRecord)
                              .ToList();
            ViewBag.pagingString = Paging.GenerateLinkPaging("design/index");
            return View(design);
        }
        public ActionResult Detail(string id,FormCollection form)
        {
            base.Authentication();
            if (id != null && Validator.ISAlias(id))
            {
                var db = new FineArtContext();
                var design = db.Designs.Include("Member").Include("Competition").Include("Kind").Single(g => g.Alias == id);
                var markDesign = db.Marks.Include("Staff").Where(m => m.Design.ID == design.ID).ToList();
                if (markDesign.Count > 0)
                {
                    ViewBag.mark = markDesign.Average(m => m.Mark);
                }
                else
                {
                    ViewBag.mark = "Not set";
                }
                ViewBag.markDesign = markDesign;
                string username = Session["user-loged"].ToString();
                Members member = db.Members.Where(m => m.Username == username).FirstOrDefault();
                if (member != null)
                {
                    var competition = db.Competitions.Include("Staffs").Where(c => c.ID == design.Competition.ID && c.EndDate > DateTime.Now).FirstOrDefault();
                    if (competition != null)
                    {
                        var mem = competition.Staffs.Where(s => s.ID == member.ID).FirstOrDefault();
                        if (mem != null)
                        {
                            ViewBag.isStaff = true;
                            if (form["submit_mark"] != null)
                            {
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append("<ul>");
                                if (form["mark"] == null || Convert.ToInt16(form["mark"]) < 1 || Convert.ToInt16(form["mark"]) > 5)
                                {
                                    stringBuilder.Append("<li>Please choose mark for this design.</li>");
                                }
                                if (stringBuilder.ToString() != "<ul>")
                                {
                                    stringBuilder.Append("</ul>");
                                    ViewBag.error = stringBuilder.ToString();
                                    ViewBag.dataForm = form;
                                }
                                else
                                {
                                    var mark = db.Marks.Where(m => m.Staff.ID == member.ID && m.Design.ID == design.ID).FirstOrDefault();
                                    if (mark != null)
                                    {
                                        mark.Mark = Convert.ToInt16(form["mark"]);
                                        mark.ReMark = form["remark"].Trim();
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        mark = new Marks
                                        {
                                            Mark = Convert.ToInt16(form["mark"]),
                                            ReMark = form["remark"].Trim(),
                                            Design = design,
                                            Staff = member,
                                        };
                                        db.Marks.Add(mark);
                                        db.SaveChanges();
                                    }
                                    ViewBag.success = true;
                                }
                            }
                        }
                    }
                }
                return View(design);
            }
            else
            {
                return Redirect("~/");
            }
        }

        public ActionResult Search(string id)
        {
            base.Authentication();
            if (id != null)
            {
                var db = new FineArtContext();
                string[] txtSearch = id.Split('-');
                List<Designs> listDesigns = new List<Designs>();
                int i = 0;
                for (i = 0; i < txtSearch.Length; i++)
                {
                    string searchTxt = txtSearch[i];
                    var designs = db.Designs.Where(d => d.Name.Contains(searchTxt)).ToList();
                    if (designs.Count > 0)
                    {
                        designs.ForEach(delegate(Designs des)
                        {
                            listDesigns.Add(des);
                        });
                    }
                }
                listDesigns = listDesigns.Distinct().ToList();
                return View(listDesigns);
            }
            else
            {
                return Redirect("~/design");
            }
        }

        public ActionResult ParseSearch(string txt_search)
        {
            base.Authentication();
            txt_search = txt_search.Replace(' ', '-').ToLower();
            return Redirect("~/design/search/"+txt_search);
        }

        public ActionResult Kind(string id,string param)
        {
            base.Authentication();
            try
            {
                if (id != null && Validator.ISAlias(id))
                {
                    var db = new FineArtContext();
                    int currentPage = Paging.GetPage(param);
                    decimal totalRecord = GlobalInfo.NumberRecordInPage;
                    var kind = db.Kinds.Include("Design")
                        .Where(k => k.Alias == id)
                        .Single();
                    decimal totalDesign = kind.Design.Count;
                    int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
                    if (currentPage > totalPage)
                    {
                        currentPage = totalPage;
                    }
                    var designs = kind.Design
                        .Join(db.Members, d => d.Member.ID, m => m.ID, (Design, Member) => new { Design = Design, Member = Member })
                        .OrderBy(p => p.Design.ID)
                        .Skip((int)((currentPage - 1) * totalRecord))
                        .Take((int)totalRecord)
                        .ToList();
                    List<DesignsKind> listDesign = new List<DesignsKind>();
                    DesignsKind designKind;
                    foreach (var item in designs)
                    {
                        designKind = new DesignsKind { Design = item.Design, Member = item.Member };
                        listDesign.Add(designKind);
                    }
                    Paging.numPage = totalPage;
                    Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
                    Paging.currentPage = currentPage;
                    ViewBag.pagingString = Paging.GenerateLinkPaging("design/kind/" + id);
                    ViewBag.Title = kind.Name;
                    return View(listDesign);
                }
                else
                {
                    return Redirect("~/");
                }
            }
            catch
            {
                return Redirect("~/");
            }
        }

        public ActionResult Exhibition(string id, string param)
        {
            base.Authentication();
            try
            {
                if (id != null && Validator.ISAlias(id))
                {
                    var db = new FineArtContext();
                    int currentPage = Paging.GetPage(param);
                    decimal totalRecord = GlobalInfo.NumberRecordInPage;
                    var exhibition = db.Exhibitions.Include("Designs")
                        .Where(k => k.Alias == id)
                        .Single();
                    decimal totalDesign = exhibition.Designs.Count;
                    int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
                    if (currentPage > totalPage)
                    {
                        currentPage = totalPage;
                    }
                    var designs = exhibition.Designs
                        .Join(db.Members, d => d.Member.ID, m => m.ID, (Design, Member) => new { Design = Design, Member = Member })
                        .OrderBy(p => p.Design.ID)
                        .Skip((int)((currentPage - 1) * totalRecord))
                        .Take((int)totalRecord)
                        .ToList();
                    List<DesignsKind> listDesign = new List<DesignsKind>();
                    DesignsKind designKind;
                    foreach (var item in designs)
                    {
                        designKind = new DesignsKind { Design = item.Design, Member = item.Member };
                        listDesign.Add(designKind);
                    }
                    Paging.numPage = totalPage;
                    Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
                    Paging.currentPage = currentPage;
                    ViewBag.pagingString = Paging.GenerateLinkPaging("design/exhibition/" + id);
                    ViewBag.Title = exhibition.Name;
                    return View(listDesign);
                }
                else
                {
                    return Redirect("~/");
                }
            }
            catch
            {
                return Redirect("~/");
            }
        }

        public ActionResult Competition(string id, string param)
        {
            base.Authentication();
            try
            {
                if (id != null && Validator.ISAlias(id))
                {
                    var db = new FineArtContext();
                    int currentPage = Paging.GetPage(param);
                    decimal totalRecord = GlobalInfo.NumberRecordInPage;
                    var competition = db.Competitions.Include("Design")
                        .Where(k => k.Alias == id)
                        .Single();
                    decimal totalDesign = competition.Design.Count;
                    int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
                    if (currentPage > totalPage)
                    {
                        currentPage = totalPage;
                    }
                    var designs = competition.Design
                        .Join(db.Members, d => d.Member.ID, m => m.ID, (Design, Member) => new { Design = Design, Member = Member })
                        .OrderBy(p => p.Design.ID)
                        .Skip((int)((currentPage - 1) * totalRecord))
                        .Take((int)totalRecord)
                        .ToList();
                    List<DesignsKind> listDesign = new List<DesignsKind>();
                    DesignsKind designKind;
                    foreach (var item in designs)
                    {
                        designKind = new DesignsKind { Design = item.Design, Member = item.Member };
                        listDesign.Add(designKind);
                    }
                    Paging.numPage = totalPage;
                    Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
                    Paging.currentPage = currentPage;
                    ViewBag.pagingString = Paging.GenerateLinkPaging("design/competition/" + id);
                    ViewBag.Title = competition.Name;
                    return View(listDesign);
                }
                else
                {
                    return Redirect("~/");
                }
            }
            catch
            {
                return Redirect("~/");
            }
        }

        public ActionResult Submit(string id, FormCollection form, HttpPostedFileBase Images)
        {
            base.Authentication();
            if (id != null)
            {
                if (Validator.ISAlias(id))
                {
                    try
                    {
                        var db = new FineArtContext();
                        bool IsSold = false;
                        decimal PriceSold = 0;
                        bool IsPaidStudent = false;
                        Competitions competition = db.Competitions
                            .Include("Award")
                            .Include("Condition")
                            .Include("Kind")
                            .Where(c => c.Alias == id && c.DeadlineDate > DateTime.Now).First();
                        if (form["submit_design"] == null)
                        {

                        }
                        else
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("<ul>");
                            if (form["Name"].Trim() == "")
                            {
                                stringBuilder.Append("<li>Design name not blank.</li>");
                            }

                            if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                            {
                                stringBuilder.Append("<li>Design alias not blank. Only contain a-z and \"-\"</li>");
                            }
                            else
                            {
                                string alias = form["Alias"].Trim();
                                var designExists = db.Designs.Where(d => d.Alias == alias).FirstOrDefault();
                                if (designExists != null)
                                {
                                    stringBuilder.Append("<li>This alias has been exists in database, try other</li>");
                                }
                            }

                            if (Images == null)
                            {
                                stringBuilder.Append("<li>Please choose your design image</li>");
                            }
                            if (form["Kind"] == "-1")
                            {
                                stringBuilder.Append("<li>Please choose kind for your design</li>");
                            }

                            if (form["IsSold"] == "on")
                            {
                                IsSold = true;
                                if (!Validator.ISPrice(form["PriceSold"]))
                                {
                                    stringBuilder.Append("<li>Please type price for your design</li>");
                                }
                            }
                            else if (form["PriceSold"] != "")
                            {
                                stringBuilder.Append("<li>You have not chosen to sell this design</li>");
                            }
                            if (form["IsPaidStudent"] == "on")
                            {
                                IsPaidStudent = true;
                                if (form["IsSold"] == null)
                                {
                                    stringBuilder.Append("<li>You have not chosen to sell this design</li>");
                                }
                            }

                            if (stringBuilder.ToString() != "<ul>")
                            {
                                ViewBag.dataForm = form;
                                stringBuilder.Append("</ul>");
                                ViewBag.error = stringBuilder.ToString();
                            }
                            else
                            {
                                ImagesClass imageLibs = new ImagesClass(Images);
                                string fileNameThumb = Server.MapPath("~/Content/Images/designs/thumbnails/" + form["Alias"] + ".jpg");
                                string fileNameBig = Server.MapPath("~/Content/Images/designs/bigimages/" + form["Alias"] + ".jpg");
                                imageLibs.ResizeAndCreateImage(fileNameThumb, 190);
                                imageLibs.ResizeAndCreateImage(fileNameBig, 700);
                                string username = Session["user-loged"].ToString();
                                Members member = db.Members.Where(m => m.Username == username).First();
                                int kindID = Convert.ToInt16(form["Kind"]);

                                Kinds kind = competition.Kind.Where(k => k.ID == kindID).First();
                                if (IsSold)
                                {
                                    PriceSold = Convert.ToDecimal(form["PriceSold"]);
                                }
                                else
                                {
                                    PriceSold = 0;
                                }
                                Designs design = new Designs
                                {
                                    Name = form["Name"].Trim(),
                                    Alias = form["Alias"].Trim(),
                                    Images = form["Alias"].Trim() + ".jpg",
                                    Competition = competition,
                                    DatePost = DateTime.Now,
                                    Description = form["Description"].Trim(),
                                    IsSold = IsSold,
                                    IsPaidStudent = IsPaidStudent,
                                    PriceSold = PriceSold,
                                    Member = member,
                                    Kind = kind
                                };
                                db.Designs.Add(design);
                                db.SaveChanges();
                                Session["success"] = form["Alias"];
                                return Redirect("~/design/submit/" + competition.Alias + "#submition");
                            }
                        }

                        return View(competition);
                    }
                    catch
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    return Redirect("~/");
                }
            }
            else
            {
                return Redirect("~/");
            }
        }

        public ActionResult Edit(string id, FormCollection form, HttpPostedFileBase Images)
        {
            base.Authentication();
            if (id != null && Validator.ISAlias(id))
            {
                var db = new FineArtContext();
                string username = Session["user-loged"].ToString();
                var design = db.Designs
                    .Include("Competition")
                    .Include("Member")
                    .Include("Kind")
                    .Where(a => a.Alias == id && a.Competition.DeadlineDate > DateTime.Now && a.Member.Username == username)
                    .First();

                bool IsSold = false;
                decimal PriceSold = 0;
                bool IsPaidStudent = false;
                Competitions competition = db.Competitions
                    .Include("Award")
                    .Include("Condition")
                    .Include("Kind")
                    .Where(c => c.ID == design.Competition.ID).First();
                if (form["submit_design"] == null)
                {
                    form["Name"] = design.Name;
                    form["Alias"] = design.Alias;
                    form["Description"] = design.Description;
                    form["Kind"] = design.Kind.ID.ToString();
                    if (design.IsSold)
                    {
                        form["IsSold"] = "on";
                    }
                    if (design.IsPaidStudent)
                    {
                        form["IsPaidStudent"] = "on";
                    }
                    if (design.PriceSold != 0)
                    {
                        form["PriceSold"] = design.PriceSold.ToString();
                    }
                    ViewBag.dataForm = form;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Design name not blank.</li>");
                    }

                    if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                    {
                        stringBuilder.Append("<li>Design alias not blank. Only contain a-z and \"-\"</li>");
                    }
                    else
                    {
                        if (design.Alias != form["Alias"].Trim())
                        {
                            string alias = form["Alias"].Trim();
                            var designExists = db.Designs.Where(d => d.Alias == alias).FirstOrDefault();
                            if (designExists != null)
                            {
                                stringBuilder.Append("<li>This alias has been exists in database, try other</li>");
                            }
                        }
                    }
                    if (form["Kind"] == "-1")
                    {
                        stringBuilder.Append("<li>Please choose kind for your design</li>");
                    }

                    if (form["IsSold"] == "on")
                    {
                        IsSold = true;
                        if (!Validator.ISPrice(form["PriceSold"]))
                        {
                            stringBuilder.Append("<li>Please type price for your design</li>");
                        }
                    }
                    else if (form["PriceSold"] != "")
                    {
                        stringBuilder.Append("<li>You have not chosen to sell this design</li>");
                    }
                    if (form["IsPaidStudent"] == "on")
                    {
                        IsPaidStudent = true;
                        if (form["IsSold"] == null)
                        {
                            stringBuilder.Append("<li>You have not chosen to sell this design</li>");
                        }
                    }

                    if (stringBuilder.ToString() != "<ul>")
                    {
                        ViewBag.dataForm = form;
                        stringBuilder.Append("</ul>");
                        ViewBag.error = stringBuilder.ToString();
                    }
                    else
                    {
                        if (Images != null)
                        {
                            string fileOldName = Server.MapPath("~/Content/Images/designs/thumbnails/" + design.Images);
                            FilesClass.DeleteFile(fileOldName);
                            fileOldName = Server.MapPath("~/Content/Images/designs/bigimages/" + design.Images);
                            FilesClass.DeleteFile(fileOldName);
                            ImagesClass imageLibs = new ImagesClass(Images);
                            string fileNameThumb = Server.MapPath("~/Content/Images/designs/thumbnails/" + form["Alias"] + ".jpg");
                            string fileNameBig = Server.MapPath("~/Content/Images/designs/bigimages/" + form["Alias"] + ".jpg");
                            imageLibs.ResizeAndCreateImage(fileNameThumb, 190);
                            imageLibs.ResizeAndCreateImage(fileNameBig, 700);
                        }
                        else
                        {
                            if (design.Alias != form["Alias"].Trim())
                            {
                                string path = "~/Content/Images/designs/";
                                string fileOldName = Server.MapPath(path + "thumbnails/" + design.Images);
                                string fileNewName = Server.MapPath(path + "thumbnails/" + form["Alias"] + ".jpg");
                                FilesClass.RenameFile(fileOldName, fileNewName);
                                fileOldName = Server.MapPath(path + "bigimages/" + design.Images);
                                fileNewName = Server.MapPath(path + "bigimages/" + form["Alias"] + ".jpg");
                                FilesClass.RenameFile(fileOldName, fileNewName);
                            }
                        }
                        Members member = db.Members.Where(m => m.Username == username).First();
                        int kindID = Convert.ToInt16(form["Kind"]);

                        Kinds kind = competition.Kind.Where(k => k.ID == kindID).First();
                        if (IsSold)
                        {
                            PriceSold = Convert.ToDecimal(form["PriceSold"]);
                        }
                        else
                        {
                            PriceSold = 0;
                        }
                        design.Name = form["Name"].Trim();
                        design.Alias = form["Alias"].Trim();
                        design.Images = form["Alias"].Trim() + ".jpg";
                        design.DatePost = DateTime.Now;
                        design.Description = form["Description"].Trim();
                        design.IsSold = IsSold;
                        design.IsPaidStudent = IsPaidStudent;
                        design.PriceSold = PriceSold;
                        design.Kind = kind;
                        db.SaveChanges();
                        ViewBag.designAlias = form["Alias"].Trim();
                        Session["success"] = form["Alias"];
                        return Redirect("~/design/edit/" + form["Alias"] +"#submition");
                    }
                }
                return View(competition);
            }
            else
            {
                return null;
            }
        }

        public ActionResult Delete(string id)
        {
            base.Authentication();
            try
            {
                if (id != null && Validator.ISAlias(id))
                {
                    var db = new FineArtContext();
                    string username = Session["user-loged"].ToString();
                    var design = db.Designs.Where(d => d.Alias == id && d.Member.Username == username).First();
                    var customer = db.Customers.Where(c => c.Design.ID == design.ID).ToList();
                    customer.ForEach(delegate(Customers cust)
                    {
                        cust.Design = null;
                    });
                    var mark = db.Marks.Where(m => m.Design.ID == design.ID).ToList();
                    mark.ForEach(delegate(Marks markItem)
                    {
                        db.Marks.Remove(markItem);
                    });
                    db.SaveChanges();
                    db.Designs.Remove(design);
                    db.SaveChanges();
                    return Redirect("~/member/profile");
                }
                else
                {
                    return Redirect("~/");
                }
            }
            catch
            {
                return Redirect("~/");
            }
        }
    }
}
