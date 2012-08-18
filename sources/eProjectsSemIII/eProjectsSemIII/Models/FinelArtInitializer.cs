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
                new Competitions {
                    Name="The Eros Award 2012",
                    Alias="the-eros-award-2012", 
                    StartDate = DateTime.Parse("2012-09-10"), EndDate = DateTime.Parse("2012-12-10") ,DeadlineDate = DateTime.Parse("2012-07-05"),
                    Images="the-eros-award-2012.jpg",
                    Summary="TZIPAC is excited to launch The Eros Award 2012. This is an international juried competition that celebrates the magic of fine art nude photography, honouring the finest in classic and contemporary nude photography.." },
                new Competitions {
                    Name="The Climate Change Ad Competition 2012",
                    Alias="the-climate-change-ad-competition-2012",  
                    StartDate = DateTime.Parse("2012-06-06"), EndDate = DateTime.Parse("2012-09-10") ,DeadlineDate = DateTime.Parse("2012-6-10"),
                    Images="the-climate-change-ad-competition-2012.jpg",
                    Summary="Climate change is recognized as a priority challenge that humanity is facing in the 21st century and some of its consequences – like increased frequency and intensity of natural hazards – are already being felt. The.."},
                new Competitions {
                    Name="ILFORD Student Photo Competition 2012",
                    Alias="ilford-student-photo-competition-2012",  
                    StartDate = DateTime.Parse("2012-06-07"), EndDate = DateTime.Parse("2012-08-15") ,DeadlineDate = DateTime.Parse("2012-06-10"),
                    Images="ilford-student-photo-competition-2012.jpg",
                    Summary="The theme of the competition is FAMILY. There is no limit to the number of entries permitted per student. Images must be printed on ILFORD black and white darkroom paper. Negatives or digital files will be called.."},
                new Competitions {
                    Name="Embracing Our Differences 2013",
                    Alias="embracing-our-differences-2013",  
                    StartDate = DateTime.Parse("2012-07-08"), EndDate = DateTime.Parse("2012-09-07") ,DeadlineDate = DateTime.Parse("2012-07-20"),
                    Images="embracing-our-differences-2013.jpg",
                    Summary="Embracing Our Differences invites artists, photographers, professionals, amateurs, teachers and students to participate in its new visual art exhibit celebrating diversity. 45 artists will be selected for the exhibit..."},
                new Competitions {
                    Name="Pink Lady Food Photographer Of The Year 2013",
                    Alias="pink-lady-food-photographer-of-the-year-2013",  
                    StartDate = DateTime.Parse("2012-09-09"), EndDate = DateTime.Parse("2012-10-09") ,DeadlineDate = DateTime.Parse("2012-09-19"),
                    Images="pink-lady-food-photographer-of-the-year-2013.jpg",
                    Summary="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,.." },
                new Competitions {
                    Name="Greenham Common Open 2012 Competition",
                    Alias="greenham-common-open-2012-competition",  
                    StartDate = DateTime.Parse("2012-07-10"), EndDate = DateTime.Parse("2012-09-10") ,DeadlineDate = DateTime.Parse("2012-07-20"),
                    Images="greenham-common-open-2012-competition.jpg",
                    Summary="New Greenham Arts is based on the de-commissioned American nuclear air base at Greenham Common. Our current visual arts strategy explores the geographic, political and emotional themes drawn from the significance.." },
               
            };
            compatition.ForEach(s => context.Competitions.Add(s));
            context.SaveChanges();

            var award = new List<Awards>
            {
                new Awards {Name="1 International winner", Description = "1,000 Euro per student or team (up to four members)",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="2 International runners-up", Description = "500 Euro for each",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="10 international finalists", Description = "Gentletude Award Certificate",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="1st prizes", Description = "3000 Euro",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="2st prizes", Description = "1000 Euro",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="1 International winner", Description = "The jury will also award up to a maximum of 4, non-monetary, special mentions",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="1st Place", Description = " R$ 6.000,00 (approx. 3,000 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="2nd Place", Description = "R$ 3.000,00 (approx. 1,500 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="3rd Place", Description = "R$ 1.000,00 (approx. 500 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="First Award", Description = "5,000 $",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Name="Award of Merit", Description = "(for 5 caricaturists) is 1,000 $",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
               
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
                new Conditions {Name="Condition Name1", Description="The Competition is open to all the caricaturists from all over the world.",Competition = new List<Competitions>(),DateUpdate=DateTime.Now },
                new Conditions {Name="Condition Name2",Description="The competition open to all photographers, creative professionals, publishers, agencies, representatives, students and teachers from all the world." ,Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Conditions {
                    Name="Condition Name3",
                    Description="Books that are published with a 2011 or 2012 copyright or that were released in 2011 or 2012 are eligible. The contest is for published books, but ISBN is not required. Submission of galley copies is permissible if finished copies are not yet available.E-books and audio-books are eligible, but there’re no separate categories for them at this time." ,
                    Competition = new List<Competitions>(),DateUpdate=DateTime.Now
                },
                new Conditions {Name="Condition Name4",Description="The competition is open to amateur and professional photographers worldwide." ,Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Conditions {Name="Condition Name5",Description="All cartoonists from all over the world are welcome to enter the competition." ,Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
               
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
                new Roles {Name = "Administrator",Alias = "administrator"},
                new Roles {Name = "Manager",Alias = "manager"},
                new Roles {Name = "Staff",Alias = "staff"},
                new Roles {Name = "Student",Alias = "student"},
            };
            role.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            

            var kind = new List<Kinds>
            {
                new Kinds {Name = "Graphic Design",Alias = "graphic-design",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Kinds {Name = "Photography",Alias = "photography",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Kinds {Name = "Illustration",Alias = "illustration",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Kinds {Name = "Animation",Alias = "animation",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Kinds {Name = "Multiple Disciplines",Alias = "multiple-disciplines",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Kinds {Name = "Students Only",Alias = "students-only",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
            };
            kind.ForEach(s => context.Kinds.Add(s));
            context.SaveChanges();

            kind[0].Competition.Add(compatition[0]);
            kind[1].Competition.Add(compatition[1]);
            kind[2].Competition.Add(compatition[2]);
            kind[3].Competition.Add(compatition[3]);
            context.SaveChanges();

            var member = new List<Members>
            {
                new Members {Images="minhphong1.jpg",Username="minhphong1",Password="123456", Name="Le Dang Son",Address="Ba ria vung tau",Phone="0128.66.01281",Gender="Male",Birthday=DateTime.Parse("1988-09-05"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[0]},//1
                new Members {Images="minhphong2.jpg", Username="minhphong2",Password="123456", Name="Le Dang Son",Address="Tp.HCM",Phone="0128.66.01282",Gender="Male",Birthday=DateTime.Parse("1988-09-06"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[1]},//2
                new Members {Images="minhphong3.jpg", Username="minhphong3",Password="123456", Name="Nguyen Thanh Phong",Address="Tp.HCM",Phone="0128.66.01283",Gender="Male",Birthday=DateTime.Parse("1988-09-07"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3
                new Members {Images="minhphong4.jpg", Username="minhphong4",Password="123456", Name="Hoang My Kim",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong5.jpg", Username="minhphong5",Password="123456", Name="Cao Minh Phong",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong6.jpg", Username="minhphong6",Password="123456", Name="Nguyen Van Teo",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong7.jpg", Username="minhphong7",Password="123456", Name="Luu Ba Thanh",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong8.jpg", Username="minhphong8",Password="123456", Name="Cao Minh Phong",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong9.jpg", Username="minhphong9",Password="123456", Name="Hoang Hai Yen",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4
                new Members {Images="minhphong10.jpg", Username="minhphong10",Password="123456", Name="Jenny Nguyen",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3
                new Members {Images="minhphong11.jpg", Username="minhphong11",Password="123456", Name="Luu Khai Phong",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3
                new Members {Images="minhphong12.jpg", Username="minhphong12",Password="123456", Name="Hoang Nhat Kim",Address="Tp.HCM",Phone="0128.66.01284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3
              
               
            };
            member.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var classs = new List<Classes>
            {
                new Classes {Name="0910E",Alias = "0910e", Member = new List<Members>(),DateUpdate = DateTime.Now},
                new Classes {Name="0910F",Alias = "0910f", Member = new List<Members>(),DateUpdate = DateTime.Now},
                new Classes {Name="0910G",Alias = "0910g", Member = new List<Members>(),DateUpdate = DateTime.Now},
                new Classes {Name="0910H",Alias = "0910h", Member = new List<Members>(),DateUpdate = DateTime.Now},
            };
            classs.ForEach(s => context.Classes.Add(s));
            context.SaveChanges();

            classs[0].Member.Add(member[3]);
            classs[1].Member.Add(member[4]);
            classs[2].Member.Add(member[5]);
            classs[3].Member.Add(member[6]);
            classs[3].Member.Add(member[7]);
            classs[3].Member.Add(member[8]);
            context.SaveChanges();
            var design = new List<Designs>
            {
                new Designs {
                    Name = "The Climate Change Ad Competition 2012",Alias = "the-climate-change-ad-competition-2012",
                    Description="TZIPAC is excited to launch The Eros Award 2012. This is an international juried competition that celebrates the magic of fine art nude photography, honouring the finest in classic and contemporary nude photography..", 
                    MemberID = 4, KindID = 1,CompetitionID=1,DatePost=DateTime.Parse("1988-09-06"),Kind = kind[0],
                    Images="the-climate-change-ad-competition-2012.jpg"
                },
                new Designs {
                    Name = "ILFORD Student Photo Competition 2012",Alias = "ilford-student-photo-competition-2012",
                    Description="Climate change is recognized as a priority challenge that humanity is facing in the 21st century and some of its consequences – like increased frequency and intensity of natural hazards – are already being felt. The..", 
                    MemberID = 4, KindID = 1,CompetitionID=1,DatePost=DateTime.Parse("1988-09-06"),Kind = kind[0],
                    Images="ilford-student-photo-competition-2012.jpg"
                },
                new Designs {
                    Name = "Embracing Our Differences 2013",Alias = "embracing-our-differences-2013",
                    Description="The theme of the competition is FAMILY. There is no limit to the number of entries permitted per student. Images must be printed on ILFORD black and white darkroom paper. Negatives or digital files will be called..", 
                    MemberID =4, KindID = 2,CompetitionID=1,DatePost=DateTime.Parse("1988-09-06"),Kind = kind[0],
                    Images="embracing-our-differences-2013.jpg"
                },
                new Designs {
                    Name = "Pink Lady Food Photographer Of The Year 2013",Alias = "pink-lady-food-photographer-of-the-year-2013",
                    Description="Embracing Our Differences invites artists, photographers, professionals, amateurs, teachers and students to participate in its new visual art exhibit celebrating diversity. 45 artists will be selected for the exhibit...", 
                    MemberID = 4, KindID = 3,CompetitionID=4,DatePost=DateTime.Parse("1988-09-06"),Kind = kind[0],
                    Images="pink-lady-food-photographer-of-the-year-2013.jpg"
                },
                new Designs {
                    Name = "Greenham Common Open 2012 Competition",Alias = "greenham-common-open-2012-competition",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    MemberID = 5, KindID = 4,CompetitionID=1,DatePost=DateTime.Parse("1988-09-06"),Kind = kind[0],
                    Images="greenham-common-open-2012-competition.jpg"
                },

                
            };
            design.ForEach(s => context.Designs.Add(s));
            context.SaveChanges();

            var mark = new List<Marks>
            {
                new Marks{Design=design[0],Staff=member[9],Mark=5},
                new Marks{Design=design[0],Staff=member[10],Mark=5},
                new Marks{Design=design[0],Staff=member[11],Mark=5},
                new Marks{Design=design[1],Staff=member[9],Mark=4},
                new Marks{Design=design[1],Staff=member[10],Mark=5},
                new Marks{Design=design[1],Staff=member[11],Mark=5},
                new Marks{Design=design[2],Staff=member[9],Mark=3},
                new Marks{Design=design[2],Staff=member[10],Mark=5},
                new Marks{Design=design[2],Staff=member[11],Mark=5},

            };

            mark.ForEach(mm => context.Marks.Add(mm));
            context.SaveChanges();
            
            var exhibition = new List<Exhibitions>
            {
                new Exhibitions {Name="Exhibition graphic design summer 2012",Alias="exhibition-graphic-design-summer-2012",Image="exhibition-graphic-design-summer-2012.jpg", StartDate = DateTime.Parse("2008-09-05"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Spring 2012 exhibition",Alias="spring-2012-exhibition",Image="spring-2012-exhibition.jpg", StartDate = DateTime.Parse("2008-09-06"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Exhibition, to family life",Alias="exhibition-to-family-life",Image="exhibition-to-family-life.jpg", StartDate = DateTime.Parse("2008-09-07"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Outdoor Exhibition 2013",Alias="outdoor-exhibition-2013",Image="outdoor-exhibition-2013.jpg", StartDate = DateTime.Parse("2008-09-08"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Annual Exhibition June 2011",Alias="annual-exhibition-june-2011",Image="annual-exhibition-june-2011.jpg", StartDate = DateTime.Parse("2008-09-09"), EndDate = DateTime.Parse("2007-09-10") },
                new Exhibitions {Name="Life is beautiful",Alias="life-is-beautiful",Image="life-is-beautiful.jpg", StartDate = DateTime.Parse("2008-09-10"), EndDate = DateTime.Parse("2007-09-10") },
               
            };
            exhibition.ForEach(s => context.Exhibitions.Add(s));
            context.SaveChanges();

            var customer = new List<Customers>
            {
                new Customers {Name="Phong", Address="Ba ria vung tau",Phone="0128.66.01281",Gender="Male",DateBuy=DateTime.Now,Design=design[0],Exhibition=exhibition[0] },
                new Customers {Name="Son", Address="Tp.HCM",Phone="0128.66.01282",Gender="Male" ,DateBuy=DateTime.Now,Design=design[0],Exhibition=exhibition[0]},
                new Customers {Name="Phong", Address="TP.HCM",Phone="0128.66.01283",Gender="Male",DateBuy=DateTime.Now ,Design=design[0],Exhibition=exhibition[0]},
                new Customers {Name="Kim", Address="TP.HCM",Phone="0128.66.01284",Gender="Female",DateBuy=DateTime.Now ,Design=design[0],Exhibition=exhibition[0]},
            };
            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            var menu = new List<Menus>
            {
                /*1*/new Menus {Name = "Home Page", Controller="", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="home_icon.png", ParentID=-1,Display=true},
                /*2*/new Menus {Name = "Logout", Controller="members", Action = "logout",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                
                /*3*/new Menus {Name = "Menus", Controller="menus", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                /*4*/new Menus {Name = "Add new menu", Controller="menus", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*5*/new Menus {Name = "Edit menu", Controller="menus", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*6*/new Menus {Name = "Delete menu", Controller="menus", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*7*/new Menus {Name = "Enable menu", Controller="menus", Action = "enable",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*8*/new Menus {Name = "Disable menu", Controller="menus", Action = "disable",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                
                /*9*/new Menus {Name = "Roles", Controller="roles", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                /*10*/new Menus {Name = "Add new role", Controller="roles", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*11*/new Menus {Name = "Edit role", Controller="roles", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*12*/new Menus {Name = "Delete role", Controller="roles", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*13*/new Menus {Name = "View menu of role", Controller="menu", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                
                /*14*/new Menus {Name = "Designs", Controller="designs", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="designs_icon.png", ParentID=-1,Display=true},
                /*15*/new Menus {Name = "List of designs", Controller="designs", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=14,Display=true},
                /*16*/new Menus {Name = "View exhibition of designs", Controller="exhibitions", Action = "exhibitiondesign",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=14,Display=false},
                /*17*/new Menus {Name = "Add design to exhibition", Controller="design", Action = "designtoexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=14,Display=false},
                /*18*/new Menus {Name = "Delete design", Controller="design", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=14,Display=false},
                
                /*19*/new Menus {Name = "Competitions", Controller="competitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=-1,Display=true},
                /*20*/new Menus {Name = "List of competitions", Controller="competitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=true},
                /*21*/new Menus {Name = "View kinds of competition", Controller="kinds", Action = "kindcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                /*22*/new Menus {Name = "View conditions of competition", Controller="condititons", Action = "conditioncompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                /*23*/new Menus {Name = "View awards of competition", Controller="awards", Action = "awardcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                /*24*/new Menus {Name = "View designs of competition", Controller="designs", Action = "designcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                /*25*/new Menus {Name = "Add new competition", Controller="competitions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=true},
                /*26*/new Menus {Name = "Edit competition", Controller="competitions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                /*27*/new Menus {Name = "Delete competition", Controller="competitions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=19,Display=false},
                
                /*28*/new Menus {Name = "Kinds", Controller="kinds", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*29*/new Menus {Name = "List of kinds", Controller="kinds", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=true},
                /*30*/new Menus {Name = "View designs have kind", Controller="designs", Action = "designkind",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=false},
                /*31*/new Menus {Name = "View competition have kind", Controller="competitions", Action = "competitionkind",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=false},
                /*32*/new Menus {Name = "Add new kind", Controller="kinds", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=true},
                /*33*/new Menus {Name = "Edit kind", Controller="kinds", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=false},
                /*34*/new Menus {Name = "Delete kind", Controller="kinds", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=28,Display=false},
                
                /*35*/new Menus {Name = "Awards", Controller="awards", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*36*/new Menus {Name = "List of awards", Controller="awards", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=35,Display=true},
                /*37*/new Menus {Name = "Add new award", Controller="awards", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=35,Display=true},
                /*38*/new Menus {Name = "Edit award", Controller="awards", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=35,Display=false},
                /*39*/new Menus {Name = "Delete award", Controller="awards", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=35,Display=false},
                
                /*40*/new Menus {Name = "Conditions", Controller="conditions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*41*/new Menus {Name = "List of conditions", Controller="conditions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=40,Display=true},
                /*42*/new Menus {Name = "Add new condition", Controller="conditions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=40,Display=true},
                /*43*/new Menus {Name = "Edit condition", Controller="conditions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=40,Display=false},
                /*44*/new Menus {Name = "Delete condition", Controller="conditions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=40,Display=false},
                
                /*45*/new Menus {Name = "Exhibitions", Controller="exhibitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*46*/new Menus {Name = "List of exhibitions", Controller="exhibitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=45,Display=true},
                /*47*/new Menus {Name = "View designs of exhibition", Controller="designs", Action = "designexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=45,Display=false},
                /*48*/new Menus {Name = "Add new exhibition", Controller="exhibitions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=45,Display=true},
                /*49*/new Menus {Name = "Edit exhibition", Controller="exhibitions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=45,Display=false},
                /*50*/new Menus {Name = "Delete exhibition", Controller="exhibitions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=45,Display=false},
                
                /*51*/new Menus {Name = "Classes", Controller="classes", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*52*/new Menus {Name = "List of classes", Controller="classes", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=51,Display=true},
                /*53*/new Menus {Name = "View students of class", Controller="members", Action = "membersclass",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=51,Display=false},
                /*54*/new Menus {Name = "Add new class", Controller="classes", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=51,Display=true},
                /*55*/new Menus {Name = "Edit class", Controller="classes", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=51,Display=false},
                /*56*/new Menus {Name = "Delete class", Controller="classes", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=51,Display=false},
                
                /*57*/new Menus {Name = "Members", Controller="members", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*58*/new Menus {Name = "List of members", Controller="members", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=57,Display=true},
                /*59*/new Menus {Name = "View designs of member", Controller="designs", Action = "designmember",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=57,Display=false},
                /*60*/new Menus {Name = "Edit member", Controller="members", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=57,Display=false},
                /*61*/new Menus {Name = "Delete member", Controller="members", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=57,Display=false},
                
                /*62*/new Menus {Name = "List of Customers", Controller="customers", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=45,Display=true},
                             
            };
            menu.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();

            menu[0].Role.Add(role[0]);
            menu[1].Role.Add(role[0]);
            menu[2].Role.Add(role[0]);
            menu[3].Role.Add(role[0]);
            menu[4].Role.Add(role[0]);
            menu[5].Role.Add(role[0]);
            menu[6].Role.Add(role[0]);
            menu[7].Role.Add(role[0]);
            menu[8].Role.Add(role[0]);
            menu[9].Role.Add(role[0]);
            menu[10].Role.Add(role[0]);
            menu[11].Role.Add(role[0]);
            menu[12].Role.Add(role[0]);
            menu[13].Role.Add(role[0]);
            menu[14].Role.Add(role[0]);
            menu[15].Role.Add(role[0]);
            menu[16].Role.Add(role[0]);
            menu[17].Role.Add(role[0]);
            menu[18].Role.Add(role[0]);
            menu[19].Role.Add(role[0]);
            menu[20].Role.Add(role[0]);
            menu[21].Role.Add(role[0]);
            menu[22].Role.Add(role[0]);
            menu[23].Role.Add(role[0]);
            menu[24].Role.Add(role[0]);
            menu[25].Role.Add(role[0]);
            menu[26].Role.Add(role[0]);
            menu[27].Role.Add(role[0]);
            menu[28].Role.Add(role[0]);
            menu[29].Role.Add(role[0]);
            menu[30].Role.Add(role[0]);
            menu[31].Role.Add(role[0]);
            menu[32].Role.Add(role[0]);
            menu[33].Role.Add(role[0]);
            menu[34].Role.Add(role[0]);
            menu[35].Role.Add(role[0]);
            menu[36].Role.Add(role[0]);
            menu[37].Role.Add(role[0]);
            menu[38].Role.Add(role[0]);
            menu[39].Role.Add(role[0]);
            menu[40].Role.Add(role[0]);
            menu[41].Role.Add(role[0]);
            menu[42].Role.Add(role[0]);
            menu[43].Role.Add(role[0]);
            menu[44].Role.Add(role[0]);
            menu[45].Role.Add(role[0]);
            menu[46].Role.Add(role[0]);
            menu[47].Role.Add(role[0]);
            menu[48].Role.Add(role[0]);
            menu[49].Role.Add(role[0]);
            menu[50].Role.Add(role[0]);
            menu[51].Role.Add(role[0]);
            menu[52].Role.Add(role[0]);
            menu[53].Role.Add(role[0]);
            menu[54].Role.Add(role[0]);
            menu[55].Role.Add(role[0]);
            menu[56].Role.Add(role[0]);
            menu[57].Role.Add(role[0]);
            menu[58].Role.Add(role[0]);
            menu[59].Role.Add(role[0]);
            menu[60].Role.Add(role[0]);
            menu[61].Role.Add(role[0]);
            context.SaveChanges();

            
        }
    }
}