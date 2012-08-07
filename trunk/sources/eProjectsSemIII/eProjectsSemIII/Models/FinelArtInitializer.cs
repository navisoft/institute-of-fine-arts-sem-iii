using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eProjectsSemIII.Models
{
    public class FinelArtInitializer : DropCreateDatabaseIfModelChanges<FineArtContext>
    {
        public void initData(FineArtContext context)
        {
            this.Seed(context);
        }
        protected override void Seed(FineArtContext context)
        {
            var compatition = new List<Competitions>
            {
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-05"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg" },
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-06"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg"},
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-07"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg"},
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-08"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg"},
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-09"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg" },
                new Competitions {Name="Pain", StartDate = DateTime.Parse("2008-09-10"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/images/10.jpg" }
               
            };
            compatition.ForEach(s => context.Competitions.Add(s));
            context.SaveChanges();

            var award = new List<Awards>
            {
                new Awards { Description = "motobike",Competition = new List<Competitions>()},
                new Awards { Description = "Audion",Competition = new List<Competitions>()},
                new Awards { Description = "Toyota",Competition = new List<Competitions>()},
                new Awards { Description = "Rollroi",Competition = new List<Competitions>()},
                new Awards { Description = "Carson4",Competition = new List<Competitions>()},
                new Awards { Description = "Carson3",Competition = new List<Competitions>()},
                new Awards { Description = "Carson2",Competition = new List<Competitions>()},
                new Awards { Description = "Carson1",Competition = new List<Competitions>()},
                new Awards { Description = "Sh",Competition = new List<Competitions>()},
                new Awards { Description = "House",Competition = new List<Competitions>()}
               
            };
            award.ForEach(s => context.Awards.Add(s));
            context.SaveChanges();

            award[0].Competition.Add(compatition[0]);
            award[1].Competition.Add(compatition[1]);
            award[2].Competition.Add(compatition[2]);
            award[3].Competition.Add(compatition[3]);
            award[4].Competition.Add(compatition[4]);
            award[5].Competition.Add(compatition[5]);
            context.SaveChanges();


            var condition = new List<Conditions>
            {
                new Conditions {Description="not use document",Competition = new List<Competitions>() },
                new Conditions {Description="not use paper" ,Competition = new List<Competitions>()},
                new Conditions {Description="not use pain" ,Competition = new List<Competitions>()},
                new Conditions {Description="not use document" ,Competition = new List<Competitions>()},
                new Conditions {Description="not use document" ,Competition = new List<Competitions>()}
               
            };
            condition.ForEach(s => context.Conditions.Add(s));
            context.SaveChanges();

            condition[0].Competition.Add(compatition[0]);
            condition[1].Competition.Add(compatition[1]);
            condition[2].Competition.Add(compatition[2]);
            condition[3].Competition.Add(compatition[3]);
            condition[4].Competition.Add(compatition[4]);

            context.SaveChanges();

            var role = new List<Roles>
            {
                new Roles {Name = "Admin"},
                new Roles {Name = "Manager"},
                new Roles {Name = "Staff"},
                new Roles {Name = "Student"}

            };
            role.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var member = new List<Members>
            {
                new Members {Username="tinhphong",Password="123456", Name="Son",Address="Tp.HCM",Phone="0128.66.01281",Gender="Male",Birthday=DateTime.Parse("1988-09-05"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=1},
                new Members {Username="minhphong137",Password="1371988", Name="Phong",Address="Ba ria vung tau",Phone="0128.66.01282",Gender="Male",Birthday=DateTime.Parse("1988-09-06"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=2},
                new Members {Username="minhphong137",Password="1371988", Name="Phong",Address="Tp.HCM",Phone="0128.66.01283",Gender="Male",Birthday=DateTime.Parse("1988-09-07"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=3},
                new Members {Username="minhphong137",Password="1371988", Name="Kim",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=4}
              
               
            };
            member.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var kind = new List<Kinds>
            {
                new Kinds {Name = "Manager"},
                new Kinds {Name = "Admin"},
                new Kinds {Name = "Staff"},
                new Kinds {Name = "Student"}

               
                
            };
            kind.ForEach(s => context.Kinds.Add(s));
            context.SaveChanges();


            var design = new List<Designs>
            {
                new Designs {Name = "Painting a Farm", Description="Paining a Farm", MemberID = 1, KindID = 1},
                new Designs {Name = "Painting a Main", Description="Paining a main", MemberID = 1, KindID = 1},
                new Designs {Name = "Painting a Family", Description="Paining a family", MemberID = 2, KindID = 2},
                new Designs {Name = "Painting a World", Description="Paining a world", MemberID = 3, KindID = 3},
                new Designs {Name = "Painting a Bar Coffee", Description="Paining a bar coffee", MemberID = 4, KindID = 4}

                
            };
            design.ForEach(s => context.Designs.Add(s));
            context.SaveChanges();




            var exhibition = new List<Exhibitions>
            {
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-05"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-06"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-07"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-08"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-09"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Pain", StartDate = DateTime.Parse("2008-09-10"), EndDate = DateTime.Parse("2007-09-10") },
               
            };
            exhibition.ForEach(s => context.Exhibitions.Add(s));
            context.SaveChanges();

            var customer = new List<Customers>
            {
                new Customers {Name="Phong", Address="Ba ria vung tau",Phone="0128.66.01281",Gender="Male" },
                new Customers {Name="Son", Address="Tp.HCM",Phone="0128.66.01282",Gender="Male" },
                new Customers {Name="Phong", Address="TP.HCM",Phone="0128.66.01283",Gender="Male" },
                new Customers {Name="Kim", Address="TP.HCM",Phone="0128.66.01284",Gender="Female" },
              
               
            };
            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();




            var classs = new List<Classs>
            {
                new Classs {Name="0910E", Member = new List<Members>()},
                new Classs {Name="0910F", Member = new List<Members>()},
                new Classs {Name="0910G", Member = new List<Members>()},
                new Classs {Name="0910H", Member = new List<Members>()},
              
               
            };
            classs.ForEach(s => context.Classs.Add(s));
            context.SaveChanges();

            classs[0].Member.Add(member[0]);
            classs[1].Member.Add(member[1]);
            classs[2].Member.Add(member[2]);
            classs[3].Member.Add(member[3]);
            context.SaveChanges();

            var awardmember = new List<AwardMembers>
            {
                new AwardMembers {AwardID=1, MemberID =1,CompetitionID=1,Remark=10},
                new AwardMembers {AwardID=2, MemberID =1,CompetitionID=1,Remark=9},
                new AwardMembers {AwardID=3, MemberID =2,CompetitionID=2,Remark=8},
                new AwardMembers {AwardID=4, MemberID =3,CompetitionID=4,Remark=7},
               
              
               
            };
            awardmember.ForEach(s => context.AwardMembers.Add(s));
            context.SaveChanges();

            var designcompetition = new List<DesignCompetitions>
            {
                new DesignCompetitions {DesignId=1, MemberID =1,CompetitionID=1,Remark=10,Mark=10, DatePost = DateTime.Parse("2007-09-10") },
                new DesignCompetitions {DesignId=2, MemberID =1,CompetitionID=1,Remark=9,Mark=9, DatePost = DateTime.Parse("2007-09-10")},
                new DesignCompetitions {DesignId=3, MemberID =2,CompetitionID=2,Remark=8,Mark=8, DatePost = DateTime.Parse("2007-09-10")},
                new DesignCompetitions {DesignId=4, MemberID =3,CompetitionID=4,Remark=7,Mark=7, DatePost = DateTime.Parse("2007-09-10")},
               
              
               
            };
            designcompetition.ForEach(s => context.DesignCompetitions.Add(s));
            context.SaveChanges();

            var designexhibition = new List<DesignExhibitions>
            {
               new DesignExhibitions {DesignID=1, CustomerID =1,ExhibitionID=1,Price=100,PriceSold=80,IsSold=true, IsPaidStudent=false},
               new DesignExhibitions {DesignID=2, CustomerID =2,ExhibitionID=1,Price=100,PriceSold=80,IsSold=true, IsPaidStudent=false},
               new DesignExhibitions {DesignID=3, CustomerID =4,ExhibitionID=3,Price=100,PriceSold=80,IsSold=true, IsPaidStudent=false},
               new DesignExhibitions {DesignID=4, CustomerID =4,ExhibitionID=4,Price=100,PriceSold=80,IsSold=true, IsPaidStudent=false},
               
              
               
            };
            designexhibition.ForEach(s => context.DesignExhibitions.Add(s));
            context.SaveChanges();

            var menu = new List<Menus>
            {
                new Menus {Name = "Painting a Farm", Controller="Home", Action = "Index",Role = new List<Roles>(),Description="menu for action", Icon="/Content/Images/10.jpg", ParentID=1,Display=true},
                new Menus {Name = "Painting a Farm", Controller="Home", Action = "Index",Role = new List<Roles>(),Description="menu for action", Icon="/Content/Images/10.jpg", ParentID=1,Display=true},
                new Menus {Name = "Painting a Farm", Controller="Home", Action = "Index",Role = new List<Roles>(),Description="menu for action", Icon="/Content/Images/10.jpg", ParentID=1,Display=true},
                new Menus {Name = "Painting a Farm", Controller="Home", Action = "Index",Role = new List<Roles>(),Description="menu for action", Icon="/Content/Images/10.jpg", ParentID=1,Display=true},
                               
            };
            menu.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();

            menu[0].Role.Add(role[0]);
            menu[1].Role.Add(role[1]);
            menu[2].Role.Add(role[2]);
            menu[3].Role.Add(role[3]);
            context.SaveChanges();


        }
    }
}