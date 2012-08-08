using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eProjectsSemIII.Models
{
    public class FinelArtInitializer : DropCreateDatabaseIfModelChanges<FineArtContext>
    {
        protected override void Seed(FineArtContext context)
        {
            var compatition = new List<Competitions>
            {
                new Competitions {Name="Pain1", StartDate = DateTime.Parse("2008-09-05"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-1.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..." },
                new Competitions {Name="Pain2", StartDate = DateTime.Parse("2008-09-06"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-2.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..."},
                new Competitions {Name="Pain3", StartDate = DateTime.Parse("2008-09-07"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-3.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..."},
                new Competitions {Name="Pain4", StartDate = DateTime.Parse("2008-09-08"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-1.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..."},
                new Competitions {Name="Pain5", StartDate = DateTime.Parse("2008-09-09"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-2.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..." },
                new Competitions {Name="Pain6", StartDate = DateTime.Parse("2008-09-10"), EndDate = DateTime.Parse("2007-09-10") ,Images="/Content/Images/competitions/competition-3.jpg",summary="The Gentletude Design Award is an international award for typhographic design students.The Award is run by the NGO Gentletude, a not-for-profit organization founded by Cristina Milani. he award aims is to encourage.Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications..." },
               
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
                new Awards { Description = "House",Competition = new List<Competitions>()},
               
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
                new Conditions {Description="not use document" ,Competition = new List<Competitions>()},
               
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
                new Roles {Name = "Administrator"},
                new Roles {Name = "Manager"},
                new Roles {Name = "Staff"},
                new Roles {Name = "Student"},

            };
            role.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var member = new List<Members>
            {
                new Members {Images="/Content/Images/students/student-1.jpg",Username="minhphong1",Password="123456", Name="Son",Address="Ba ria vung tau",Phone="0128.66.01281",Gender="Male",Birthday=DateTime.Parse("1988-09-05"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=1},
                new Members {Images="/Content/Images/students/student-2.jpg", Username="minhphong2",Password="123456", Name="Son",Address="Tp.HCM",Phone="0128.66.01282",Gender="Male",Birthday=DateTime.Parse("1988-09-06"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=2},
                new Members {Images="/Content/Images/students/student-3.jpg", Username="minhphong3",Password="123456", Name="Phong",Address="Tp.HCM",Phone="0128.66.01283",Gender="Male",Birthday=DateTime.Parse("1988-09-07"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=3},
                new Members {Images="/Content/Images/students/student-4.jpg", Username="minhphong4",Password="123456", Name="Kim",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=4},
                new Members {Images="/Content/Images/students/student-4.jpg", Username="minhphong5",Password="123456", Name="Kim1",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),RoleID=4},
              
               
            };
            member.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var kind = new List<Kinds>
            {
                new Kinds {Name = "Graphic Design"},
                new Kinds {Name = "Photography"},
                new Kinds {Name = "Illustration"},
                new Kinds {Name = "Animation"},
                new Kinds {Name = "Multiple Disciplines"},
                new Kinds {Name = "Students Only"},
            };
            kind.ForEach(s => context.Kinds.Add(s));
            context.SaveChanges();


            var design = new List<Designs>
            {
                new Designs {
                    Name = "The Climate Change Ad Competition 2012", 
                    Description="TZIPAC is excited to launch The Eros Award 2012. This is an international juried competition that celebrates the magic of fine art nude photography, honouring the finest in classic and contemporary nude photography..", 
                    MemberID = 4, KindID = 1,CompetitionID=1,Mark=10,Remark=10,DatePost=DateTime.Parse("1988-09-06"),Images="competition-1.jpg"
                },
                new Designs {
                    Name = "ILFORD Student Photo Competition 2012", 
                    Description="Climate change is recognized as a priority challenge that humanity is facing in the 21st century and some of its consequences – like increased frequency and intensity of natural hazards – are already being felt. The..", 
                    MemberID = 4, KindID = 1,CompetitionID=2,Mark=10,Remark=9,DatePost=DateTime.Parse("1988-09-06"),Images="competition-1.jpg"
                },
                new Designs {
                    Name = "Embracing Our Differences 2013", 
                    Description="The theme of the competition is FAMILY. There is no limit to the number of entries permitted per student. Images must be printed on ILFORD black and white darkroom paper. Negatives or digital files will be called..", 
                    MemberID =4, KindID = 2,CompetitionID=3,Mark=10,Remark=8,DatePost=DateTime.Parse("1988-09-06"),Images="competition-1.jpg"
                },
                new Designs {
                    Name = "Pink Lady Food Photographer Of The Year 2013", 
                    Description="Embracing Our Differences invites artists, photographers, professionals, amateurs, teachers and students to participate in its new visual art exhibit celebrating diversity. 45 artists will be selected for the exhibit...", 
                    MemberID = 4, KindID = 3,CompetitionID=4,Mark=10,Remark=7,DatePost=DateTime.Parse("1988-09-06"),Images="competition-1.jpg"
                },
                new Designs {
                    Name = "Greenham Common Open 2012 Competition", 
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    MemberID = 5, KindID = 4,CompetitionID=1,Mark=6,Remark=10,DatePost=DateTime.Parse("1988-09-06"),Images="competition-1.jpg"
                },

                
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
                new Menus {Name = "Home Page", Controller="Index", Action = "Index",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="home_icon.png", ParentID=-1,Display=true},
                new Menus {Name = "Logout", Controller="Index", Action = "Logout",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                new Menus {Name = "Menus", Controller="Index", Action = "Menus",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                new Menus {Name = "Roles", Controller="Index", Action = "Roles",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                               
            };
            menu.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();

            menu[0].Role.Add(role[0]);
            menu[1].Role.Add(role[0]);
            menu[2].Role.Add(role[0]);
            menu[3].Role.Add(role[0]);
            context.SaveChanges();

            
        }
    }
}