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
            var competition = new List<Competitions>
            {
                new Competitions {
                    Name="The Eros Award 2012",Staffs = new List<Members>(),
                    Alias="the-eros-award-2012", 
                    StartDate = DateTime.Parse("2012-09-10"), EndDate = DateTime.Parse("2013-01-10") ,DeadlineDate = DateTime.Parse("2012-12-10"),
                    Images="the-eros-award-2012.jpg",
                    Summary="Poverty is a global issue. Over a decade ago, world leaders at the UN Millennium Summit pledged to ’End poverty by 2015’. With just three years left, they will not meet their commitment. Perhaps surprisingly, Hong Kong too has a serious poverty problem. Amidst great affluence, 18.1% of the population struggles to make ends meet. Images of the personal and social impact of poverty are everywhere. Supported by WYNG Foundation, the WYNG Masters Award for Photography is a non-profit project initiated to spark public awareness and support interest in socially relevant subjects. The intention is to stimulate discussion and encourage social responsibility on important issues in Hong Kong through the medium of photography. The WYNG Masters Award theme for 2012 is POVERTY. The WYNG Masters Award program includes an additional component - the WYNG Poverty Project. The WYNG Poverty Project recipient will develop, with the WYNG Photography Project Trustees, a photographic project highlighting a subject or theme related to poverty in the context of Hong Kong, one of the world’s most dynamic urban centres. All genres of photography and techniques used to produce images are welcome for submission. Photographs must be taken in Hong Kong or the subject of the work must be related to Hong Kong. There is no entry fee." },
                new Competitions {
                    Name="The Climate Change Ad Competition 2012",Staffs = new List<Members>(),
                    Alias="the-climate-change-ad-competition-2012",  
                    StartDate = DateTime.Parse("2012-12-10"), EndDate = DateTime.Parse("2013-04-10") ,DeadlineDate = DateTime.Parse("2013-03-10"),
                    Images="the-climate-change-ad-competition-2012.jpg",
                    Summary="Poverty is a global issue. Over a decade ago, world leaders at the UN Millennium Summit pledged to ’End poverty by 2015’. With just three years left, they will not meet their commitment. Perhaps surprisingly, Hong Kong too has a serious poverty problem. Amidst great affluence, 18.1% of the population struggles to make ends meet. Images of the personal and social impact of poverty are everywhere. Supported by WYNG Foundation, the WYNG Masters Award for Photography is a non-profit project initiated to spark public awareness and support interest in socially relevant subjects. The intention is to stimulate discussion and encourage social responsibility on important issues in Hong Kong through the medium of photography. The WYNG Masters Award theme for 2012 is POVERTY. The WYNG Masters Award program includes an additional component - the WYNG Poverty Project. The WYNG Poverty Project recipient will develop, with the WYNG Photography Project Trustees, a photographic project highlighting a subject or theme related to poverty in the context of Hong Kong, one of the world’s most dynamic urban centres. All genres of photography and techniques used to produce images are welcome for submission. Photographs must be taken in Hong Kong or the subject of the work must be related to Hong Kong. There is no entry fee." },
                new Competitions {
                    Name="ILFORD Student Photo Competition 2012",Staffs = new List<Members>(),
                    Alias="ilford-student-photo-competition-2012",  
                    StartDate = DateTime.Parse("2012-08-10"), EndDate = DateTime.Parse("2012-12-10") ,DeadlineDate = DateTime.Parse("2012-11-10"),
                    Images="ilford-student-photo-competition-2012.jpg",
                    Summary="Poverty is a global issue. Over a decade ago, world leaders at the UN Millennium Summit pledged to ’End poverty by 2015’. With just three years left, they will not meet their commitment. Perhaps surprisingly, Hong Kong too has a serious poverty problem. Amidst great affluence, 18.1% of the population struggles to make ends meet. Images of the personal and social impact of poverty are everywhere. Supported by WYNG Foundation, the WYNG Masters Award for Photography is a non-profit project initiated to spark public awareness and support interest in socially relevant subjects. The intention is to stimulate discussion and encourage social responsibility on important issues in Hong Kong through the medium of photography. The WYNG Masters Award theme for 2012 is POVERTY. The WYNG Masters Award program includes an additional component - the WYNG Poverty Project. The WYNG Poverty Project recipient will develop, with the WYNG Photography Project Trustees, a photographic project highlighting a subject or theme related to poverty in the context of Hong Kong, one of the world’s most dynamic urban centres. All genres of photography and techniques used to produce images are welcome for submission. Photographs must be taken in Hong Kong or the subject of the work must be related to Hong Kong. There is no entry fee." },
                new Competitions {
                    Name="Embracing Our Differences 2013",Staffs = new List<Members>(),
                    Alias="embracing-our-differences-2013",  
                    StartDate = DateTime.Parse("2012-07-10"), EndDate = DateTime.Parse("2012-11-10") ,DeadlineDate = DateTime.Parse("2012-10-10"),
                    Images="embracing-our-differences-2013.jpg",
                    Summary="Poverty is a global issue. Over a decade ago, world leaders at the UN Millennium Summit pledged to ’End poverty by 2015’. With just three years left, they will not meet their commitment. Perhaps surprisingly, Hong Kong too has a serious poverty problem. Amidst great affluence, 18.1% of the population struggles to make ends meet. Images of the personal and social impact of poverty are everywhere. Supported by WYNG Foundation, the WYNG Masters Award for Photography is a non-profit project initiated to spark public awareness and support interest in socially relevant subjects. The intention is to stimulate discussion and encourage social responsibility on important issues in Hong Kong through the medium of photography. The WYNG Masters Award theme for 2012 is POVERTY. The WYNG Masters Award program includes an additional component - the WYNG Poverty Project. The WYNG Poverty Project recipient will develop, with the WYNG Photography Project Trustees, a photographic project highlighting a subject or theme related to poverty in the context of Hong Kong, one of the world’s most dynamic urban centres. All genres of photography and techniques used to produce images are welcome for submission. Photographs must be taken in Hong Kong or the subject of the work must be related to Hong Kong. There is no entry fee." },
                new Competitions {
                    Name="Pink Lady Food Photographer Of The Year 2013",Staffs = new List<Members>(),
                    Alias="pink-lady-food-photographer-of-the-year-2013",  
                    StartDate = DateTime.Parse("2012-03-10"), EndDate = DateTime.Parse("2012-08-10") ,DeadlineDate = DateTime.Parse("2012-07-10"),
                    Images="pink-lady-food-photographer-of-the-year-2013.jpg",
                    Summary="Poverty is a global issue. Over a decade ago, world leaders at the UN Millennium Summit pledged to ’End poverty by 2015’. With just three years left, they will not meet their commitment. Perhaps surprisingly, Hong Kong too has a serious poverty problem. Amidst great affluence, 18.1% of the population struggles to make ends meet. Images of the personal and social impact of poverty are everywhere. Supported by WYNG Foundation, the WYNG Masters Award for Photography is a non-profit project initiated to spark public awareness and support interest in socially relevant subjects. The intention is to stimulate discussion and encourage social responsibility on important issues in Hong Kong through the medium of photography. The WYNG Masters Award theme for 2012 is POVERTY. The WYNG Masters Award program includes an additional component - the WYNG Poverty Project. The WYNG Poverty Project recipient will develop, with the WYNG Photography Project Trustees, a photographic project highlighting a subject or theme related to poverty in the context of Hong Kong, one of the world’s most dynamic urban centres. All genres of photography and techniques used to produce images are welcome for submission. Photographs must be taken in Hong Kong or the subject of the work must be related to Hong Kong. There is no entry fee." },
                new Competitions {
                    Name="Greenham Common Open 2012 Competition",Staffs = new List<Members>(),
                    Alias="greenham-common-open-2012-competition",  
                    StartDate = DateTime.Parse("2012-01-10"), EndDate = DateTime.Parse("2012-05-10") ,DeadlineDate = DateTime.Parse("2012-04-10"),
                    Images="greenham-common-open-2012-competition.jpg",
                    Summary="New Greenham Arts is based on the de-commissioned American nuclear air base at Greenham Common. Our current visual arts strategy explores the geographic, political and emotional themes drawn from the significance.." },
               
            };
            competition.ForEach(s => context.Competitions.Add(s));
            context.SaveChanges();

            var award = new List<Awards>
            {
                new Awards {Level = 1,Name="1 International winner", Description = "1,000 Euro per student or team (up to four members)",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 2,Name="2 International runners-up", Description = "500 Euro for each",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 3,Name="10 international finalists", Description = "Gentletude Award Certificate",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 1,Name="1st prizes", Description = "3000 Euro",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 2,Name="2st prizes", Description = "1000 Euro",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 1,Name="1 International winner", Description = "The jury will also award up to a maximum of 4, non-monetary, special mentions",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 1,Name="1st Place", Description = " R$ 6.000,00 (approx. 3,000 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 2,Name="2nd Place", Description = "R$ 3.000,00 (approx. 1,500 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 3,Name="3rd Place", Description = "R$ 1.000,00 (approx. 500 USD) plus trophy;",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 1,Name="First Award", Description = "5,000 $",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
                new Awards {Level = 2,Name="Award of Merit", Description = "(for 5 caricaturists) is 1,000 $",Competition = new List<Competitions>(),DateUpdate=DateTime.Now},
               
            };
            award.ForEach(s => context.Awards.Add(s));
            context.SaveChanges();

            award[0].Competition.Add(competition[0]);
            award[1].Competition.Add(competition[0]);
            award[2].Competition.Add(competition[0]);

            award[0].Competition.Add(competition[1]);
            award[1].Competition.Add(competition[1]);
            award[2].Competition.Add(competition[1]);

            award[0].Competition.Add(competition[2]);
            award[1].Competition.Add(competition[2]);
            award[2].Competition.Add(competition[2]);

            award[0].Competition.Add(competition[3]);
            award[1].Competition.Add(competition[3]);
            award[2].Competition.Add(competition[3]);

            award[0].Competition.Add(competition[4]);
            award[1].Competition.Add(competition[4]);
            award[2].Competition.Add(competition[4]);

            award[0].Competition.Add(competition[5]);
            award[1].Competition.Add(competition[5]);
            award[2].Competition.Add(competition[5]);
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

            condition[0].Competition.Add(competition[0]);
            condition[1].Competition.Add(competition[0]);
            condition[2].Competition.Add(competition[0]);
            condition[3].Competition.Add(competition[0]);
            condition[4].Competition.Add(competition[0]);

            condition[0].Competition.Add(competition[1]);
            condition[1].Competition.Add(competition[1]);
            condition[2].Competition.Add(competition[1]);
            condition[3].Competition.Add(competition[1]);
            condition[4].Competition.Add(competition[1]);

            condition[0].Competition.Add(competition[2]);
            condition[1].Competition.Add(competition[2]);
            condition[2].Competition.Add(competition[2]);
            condition[3].Competition.Add(competition[2]);
            condition[4].Competition.Add(competition[2]);

            condition[0].Competition.Add(competition[3]);
            condition[1].Competition.Add(competition[3]);
            condition[2].Competition.Add(competition[3]);
            condition[3].Competition.Add(competition[3]);
            condition[4].Competition.Add(competition[3]);

            condition[0].Competition.Add(competition[4]);
            condition[1].Competition.Add(competition[4]);
            condition[2].Competition.Add(competition[4]);
            condition[3].Competition.Add(competition[4]);
            condition[4].Competition.Add(competition[4]);

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

            kind[0].Competition.Add(competition[0]);
            kind[1].Competition.Add(competition[0]);
            kind[2].Competition.Add(competition[0]);
            kind[3].Competition.Add(competition[0]);
            kind[4].Competition.Add(competition[0]);

            kind[0].Competition.Add(competition[1]);
            kind[1].Competition.Add(competition[1]);
            kind[2].Competition.Add(competition[1]);
            kind[3].Competition.Add(competition[1]);
            kind[4].Competition.Add(competition[1]);

            kind[0].Competition.Add(competition[2]);
            kind[1].Competition.Add(competition[2]);
            kind[2].Competition.Add(competition[2]);
            kind[3].Competition.Add(competition[2]);
            kind[4].Competition.Add(competition[2]);
            kind[5].Competition.Add(competition[2]);

            kind[0].Competition.Add(competition[3]);
            kind[1].Competition.Add(competition[3]);
            kind[2].Competition.Add(competition[3]);
            kind[3].Competition.Add(competition[3]);
            kind[4].Competition.Add(competition[3]);
            kind[5].Competition.Add(competition[3]);
            context.SaveChanges();

            var member = new List<Members>
            {
                new Members {Images="minhphong1.jpg",Username="minhphong1",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Le Dang Son",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601281",Gender="Male",Birthday=DateTime.Parse("1988-09-05"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[0]},//1//1
                new Members {Images="minhphong2.jpg", Username="minhphong2",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Le Dang Son",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601282",Gender="Male",Birthday=DateTime.Parse("1988-09-06"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[1]},//2//2
                new Members {Images="minhphong3.jpg", Username="minhphong3",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Nguyen Thanh Phong",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601283",Gender="Male",Birthday=DateTime.Parse("1988-09-07"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3//3
                new Members {Images="minhphong4.jpg", Username="minhphong4",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Hoang My Kim",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//4
                new Members {Images="minhphong5.jpg", Username="minhphong5",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Cao Minh Phong",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//5
                new Members {Images="minhphong6.jpg", Username="minhphong6",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Nguyen Van Teo",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//6
                new Members {Images="minhphong7.jpg", Username="minhphong7",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Luu Ba Thanh",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//7
                new Members {Images="minhphong8.jpg", Username="minhphong8",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Cao Minh Phong",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//8
                new Members {Images="minhphong9.jpg", Username="minhphong9",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Hoang Hai Yen",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//9
                new Members {Images="minhphong10.jpg", Username="minhphong10",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Jenny Nguyen",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3//10
                new Members {Images="minhphong11.jpg", Username="minhphong11",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Luu Khai Phong",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3//11
                new Members {Images="minhphong12.jpg", Username="minhphong12",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Cao Ba Quat",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[2]},//3//12
                new Members {Images="minhphong13.jpg", Username="minhphong13",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Thong Ma La",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//13
                new Members {Images="minhphong14.jpg", Username="minhphong14",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Hoang Tu",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//14
                new Members {Images="minhphong15.jpg", Username="minhphong15",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Ho La La",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//15
                new Members {Images="minhphong16.jpg", Username="minhphong16",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Nguyen Cao Thanh",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//16
                new Members {Images="minhphong17.jpg", Username="minhphong17",Email="sonld.hv@gmail.com",Password="e45229557b78a24cd11a9b6ec9c55183", Name="Huynh Quang Minh",Address="123 Nguyen Trung Truc, Q1, Tp.HCM",Phone="01286601284",Gender="Female",Birthday=DateTime.Parse("1988-09-08"),Datejoin=DateTime.Parse("2008-09-05"),Role=role[3]},//4//17
              
               
            };
            member.ForEach(s => context.Members.Add(s));
            context.SaveChanges();
            competition[0].Staffs.Add(member[9]);
            competition[0].Staffs.Add(member[10]);
            competition[0].Staffs.Add(member[11]);

            competition[1].Staffs.Add(member[9]);
            competition[1].Staffs.Add(member[10]);
            competition[1].Staffs.Add(member[11]);

            competition[2].Staffs.Add(member[9]);
            competition[2].Staffs.Add(member[10]);
            competition[2].Staffs.Add(member[11]);

            competition[3].Staffs.Add(member[9]);
            competition[3].Staffs.Add(member[10]);
            competition[3].Staffs.Add(member[11]);

            competition[4].Staffs.Add(member[9]);
            competition[4].Staffs.Add(member[10]);
            competition[4].Staffs.Add(member[11]);

            competition[5].Staffs.Add(member[9]);
            competition[5].Staffs.Add(member[10]);
            competition[5].Staffs.Add(member[11]);
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
                    Member = member[3],Competition=competition[4],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="the-climate-change-ad-competition-2012.jpg"
                },
                new Designs {
                    Name = "ILFORD Student Photo Competition 2012",Alias = "ilford-student-photo-competition-2012",
                    Description="Climate change is recognized as a priority challenge that humanity is facing in the 21st century and some of its consequences – like increased frequency and intensity of natural hazards – are already being felt. The..", 
                    Member = member[4],Competition=competition[4],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="ilford-student-photo-competition-2012.jpg"
                },
                new Designs {
                    Name = "Embracing Our Differences 2013",Alias = "embracing-our-differences-2013",
                    Description="The theme of the competition is FAMILY. There is no limit to the number of entries permitted per student. Images must be printed on ILFORD black and white darkroom paper. Negatives or digital files will be called..", 
                    Member =member[5],Competition=competition[4],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="embracing-our-differences-2013.jpg"
                },
                new Designs {
                    Name = "Pink Lady Food Photographer Of The Year 2013",Alias = "pink-lady-food-photographer-of-the-year-2013",
                    Description="Embracing Our Differences invites artists, photographers, professionals, amateurs, teachers and students to participate in its new visual art exhibit celebrating diversity. 45 artists will be selected for the exhibit...", 
                    Member = member[6],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="pink-lady-food-photographer-of-the-year-2013.jpg"
                },
                new Designs {
                    Name = "Greenham Common Open 2012 Competition",Alias = "greenham-common-open-2012-competition",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[7],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="greenham-common-open-2012-competition.jpg"
                },
                new Designs {
                    Name = "WYNG Masters Award For Photography",Alias = "wyng-masters-award-for-photography",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[8],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="wyng-masters-award-for-photography.jpg"
                },
                new Designs {
                    Name = "Gentletude Design",Alias = "gentletude-design",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[12],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="gentletude-design.jpg"
                },
                new Designs {
                    Name = "Lorem Ipsum is simply dummy text of the printing",Alias = "lorem-ipsum-is-simply-dummy-text-of-the-printing",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[13],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="lorem-ipsum-is-simply-dummy-text-of-the-printing.jpg"
                },
                new Designs {
                    Name = "It is a long established fact that a reader",Alias = "it-is-a-long-established-fact-that-a-reader",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[14],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="it-is-a-long-established-fact-that-a-reader.jpg"
                },
                new Designs {
                    Name = "Contrary to popular belief",Alias = "contrary-to-popular-belief",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[15],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="contrary-to-popular-belief.jpg"
                },
                new Designs {
                    Name = "There are many variations of passages",Alias = "there-are-many-variations-of-passages",
                    Description="Pink Lady Food Photographer of the Year is inspired by the proliferation of wonderful food photography in a huge variety of applications. From eye-catching advertising hoardings, to sumptuous editorial features,..", 
                    Member = member[16],Competition=competition[2],DatePost=DateTime.Parse("2012-10-10"),Kind = kind[0],
                    Images="there-are-many-variations-of-passages.jpg"
                },
            };
            design.ForEach(s => context.Designs.Add(s));
            context.SaveChanges();

            var mark = new List<Marks>
            {
                new Marks{Design=design[0],Staff=member[9],Mark=5,ReMark="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."},
                new Marks{Design=design[0],Staff=member[10],Mark=5,ReMark="Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"},
                new Marks{Design=design[0],Staff=member[11],Mark=5,ReMark="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo."},
                new Marks{Design=design[1],Staff=member[9],Mark=4,ReMark="Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. "},
                new Marks{Design=design[1],Staff=member[10],Mark=5,ReMark="Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur"},
                new Marks{Design=design[1],Staff=member[11],Mark=5,ReMark="But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness."},
                new Marks{Design=design[2],Staff=member[9],Mark=3,ReMark="No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure."},
                new Marks{Design=design[2],Staff=member[10],Mark=5,ReMark="To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure"},
                new Marks{Design=design[2],Staff=member[11],Mark=5,ReMark="At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus."},

            };

            mark.ForEach(mm => context.Marks.Add(mm));
            context.SaveChanges();
            
            var exhibition = new List<Exhibitions>
            {
                new Exhibitions {
                    Name="Exhibition graphic design summer 2012",
                    Alias="exhibition-graphic-design-summer-2012",
                    Image="exhibition-graphic-design-summer-2012.jpg", 
                    StartDate = DateTime.Parse("2012-08-05"), EndDate = DateTime.Parse("2012-12-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
                new Exhibitions {
                    Name="Spring 2012 exhibition",
                    Alias="spring-2012-exhibition",
                    Image="spring-2012-exhibition.jpg", 
                    StartDate = DateTime.Parse("2008-09-06"), EndDate = DateTime.Parse("2007-09-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
                new Exhibitions {
                    Name="Exhibition, to family life",
                    Alias="exhibition-to-family-life",
                    Image="exhibition-to-family-life.jpg", 
                    StartDate = DateTime.Parse("2008-09-07"), EndDate = DateTime.Parse("2007-09-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
                new Exhibitions {
                    Name="Outdoor Exhibition 2013",
                    Alias="outdoor-exhibition-2013",
                    Image="outdoor-exhibition-2013.jpg", 
                    StartDate = DateTime.Parse("2008-09-08"), 
                    EndDate = DateTime.Parse("2007-09-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
                new Exhibitions {
                    Name="Annual Exhibition June 2011",
                    Alias="annual-exhibition-june-2011",
                    Image="annual-exhibition-june-2011.jpg", 
                    StartDate = DateTime.Parse("2008-09-09"), EndDate = DateTime.Parse("2007-09-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
                new Exhibitions {
                    Name="Life is beautiful",
                    Alias="life-is-beautiful",
                    Image="life-is-beautiful.jpg", 
                    StartDate = DateTime.Parse("2008-09-10"), EndDate = DateTime.Parse("2007-09-10"),
                    Description = "EyeTime 2012 was assembled by photographers, professors and students as a means to publically promote the research, exploration and investigation currently happening amongst today's emerging talent. We invite students and young professionals to share their voices with the collective intelligence of a community of visual thinkers.The proliferation of device culture, social networking, and cloud technology are changing the way we create, and connect on a daily basis. For photography, this means that technology is not only transforming the process of production, but also the processes through which we share, critique, and organize ourselves around the work we do. The competition is first, and foremost an experiment in distributed intelligence. By leveraging the wisdom of crowds every entrant can see and understand how his or her work is experienced by others. It has been predicted that in 2020, there will be 50 billion mobile internet connections worldwide, the equivalent of seven devices per person. Thus, this competition is not simply about the existence of technology, but rather why and how we harness it as artists. As the paradigm shift from analog to digital is paired with the emergence of platforms for the digital consumption of images, photography inherently reassess its methods, media and subjects, in order to establish a dialogue with an audience whose visual abilities are increasingly expanded by technology. Thus, this competition challenges you to confront the world with your photography. By sending it out into the field you will test yourself and your work. You are the artist, the curator and the critic. EyeTime 2012 poses the following questions: How are your photos perceived? What does it take for an image to make a difference within the continuous overflow of data and information we currently inhabit? How can images impact evolving forms of media in order to engage audiences with their message? What is your message? There are two categories: Emerging Talent (students only) uture Voices (young professionals or enthusiasts)All submissions are digital and each entrant may submit a maximum of three collections. Entrants maintain full copyright to their work.There is no entry fee.Eligibility• Emerging Talent submissions: Students must currently be under-graduate or post-graduate students at universities or tertiary institutions. (Tertiary institutions include: junior colleges, colleges of technology, and other relevant vocational schools.)• Future Voices submissions: Competition is open to everyone 35 years old and younger in all creative fields including but not limited to photography, architecture, design, art, sculpture, fashion and technology.All international entries are welcomed.PrizePublication and promotion."
                },
               
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
                /*7*/new Menus {Name = "Enable display menu", Controller="menus", Action = "enable",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*8*/new Menus {Name = "Disable display menu", Controller="menus", Action = "disable",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                
                /*9*/new Menus {Name = "Roles", Controller="roles", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=true},
                /*10*/new Menus {Name = "Add new role", Controller="roles", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*11*/new Menus {Name = "Edit role", Controller="roles", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*12*/new Menus {Name = "Delete role", Controller="roles", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*13*/new Menus {Name = "View menu of role", Controller="menus", Action = "menusrole",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*14*/new Menus {Name = "Add menu for role", Controller="menus", Action = "removemenurole",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                /*15*/new Menus {Name = "Delete menu of role", Controller="menus", Action = "removemenurole",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=1,Display=false},
                
                /*16*/new Menus {Name = "Designs", Controller="designs", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="designs_icon.png", ParentID=-1,Display=true},
                /*17*/new Menus {Name = "List of designs", Controller="designs", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=16,Display=true},
                /*18*/new Menus {Name = "View exhibition of designs", Controller="exhibitions", Action = "exhibitiondesign",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=16,Display=false},
                /*19*/new Menus {Name = "Add design to exhibition", Controller="designs", Action = "designtoexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=16,Display=false},
                /*20*/new Menus {Name = "Delete design", Controller="designs", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=16,Display=false},
                
                /*21*/new Menus {Name = "Competitions", Controller="competitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=-1,Display=true},
                /*22*/new Menus {Name = "List of competitions", Controller="competitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=true},
                /*23*/new Menus {Name = "View kinds of competition", Controller="kinds", Action = "kindcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*24*/new Menus {Name = "View conditions of competition", Controller="conditions", Action = "conditioncompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*25*/new Menus {Name = "View awards of competition", Controller="awards", Action = "awardcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*26*/new Menus {Name = "View designs of competition", Controller="designs", Action = "designcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*27*/new Menus {Name = "Add new competition", Controller="competitions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=true},
                /*28*/new Menus {Name = "Edit competition", Controller="competitions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*29*/new Menus {Name = "Delete competition", Controller="competitions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*30*/new Menus {Name = "Add award for competition", Controller="awards", Action = "addawardcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*31*/new Menus {Name = "Delete award of competition", Controller="awards", Action = "removeawardcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*32*/new Menus {Name = "Add condition for competition", Controller="conditions", Action = "addconditionscompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*33*/new Menus {Name = "Remove condition of competition", Controller="conditions", Action = "removeconditioncompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*34*/new Menus {Name = "Add kinds for competition", Controller="kinds", Action = "addkindcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                /*35*/new Menus {Name = "Delete kinds of competition", Controller="kinds", Action = "removekindcompetition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="competition_icon.png", ParentID=21,Display=false},
                  
                /*36*/new Menus {Name = "Kinds", Controller="kinds", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*37*/new Menus {Name = "List of kinds", Controller="kinds", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=true},
                /*38*/new Menus {Name = "View designs have kind", Controller="designs", Action = "designkind",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=false},
                /*39*/new Menus {Name = "View competition have kind", Controller="competitions", Action = "competitionkind",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=false},
                /*40*/new Menus {Name = "Add new kind", Controller="kinds", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=true},
                /*41*/new Menus {Name = "Edit kind", Controller="kinds", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=false},
                /*42*/new Menus {Name = "Delete kind", Controller="kinds", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=36,Display=false},
                
                /*43*/new Menus {Name = "Awards", Controller="awards", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*44*/new Menus {Name = "List of awards", Controller="awards", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=43,Display=true},
                /*45*/new Menus {Name = "Add new award", Controller="awards", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=43,Display=true},
                /*46*/new Menus {Name = "Edit award", Controller="awards", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=43,Display=false},
                /*47*/new Menus {Name = "Delete award", Controller="awards", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=43,Display=false},
                
                /*48*/new Menus {Name = "Conditions", Controller="conditions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*49*/new Menus {Name = "List of conditions", Controller="conditions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=48,Display=true},
                /*50*/new Menus {Name = "Add new condition", Controller="conditions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=48,Display=true},
                /*51*/new Menus {Name = "Edit condition", Controller="conditions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=48,Display=false},
                /*52*/new Menus {Name = "Delete condition", Controller="conditions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=48,Display=false},
                
                /*53*/new Menus {Name = "Exhibitions", Controller="exhibitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*54*/new Menus {Name = "List of exhibitions", Controller="exhibitions", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=true},
                /*55*/new Menus {Name = "View designs of exhibition", Controller="designs", Action = "designexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                /*56*/new Menus {Name = "Add new exhibition", Controller="exhibitions", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=true},
                /*57*/new Menus {Name = "Edit exhibition", Controller="exhibitions", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                /*58*/new Menus {Name = "Delete exhibition", Controller="exhibitions", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                /*59*/new Menus {Name = "Add exhibition for design", Controller="exhibitions", Action = "addexhibitiondesign",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                /*60*/new Menus {Name = "List of Customers", Controller="customers", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=53,Display=true},
                /*61*/new Menus {Name = "Add new Customers", Controller="customers", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=53,Display=false},
                /*62*/new Menus {Name = "Edit Customers", Controller="customers", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=53,Display=false},
                /*63*/new Menus {Name = "Delete Customers", Controller="customers", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=53,Display=false},
                
                /*64*/new Menus {Name = "Classes", Controller="classes", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*65*/new Menus {Name = "List of classes", Controller="classes", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=64,Display=true},
                /*66*/new Menus {Name = "View students of class", Controller="members", Action = "membersclass",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=64,Display=false},
                /*67*/new Menus {Name = "Add new class", Controller="classes", Action = "add",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=64,Display=true},
                /*68*/new Menus {Name = "Edit class", Controller="classes", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=64,Display=false},
                /*69*/new Menus {Name = "Delete class", Controller="classes", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=64,Display=false},
                
                /*70*/new Menus {Name = "Members", Controller="members", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", Icon="kinds_icon.png", ParentID=-1,Display=true},
                /*71*/new Menus {Name = "List of members", Controller="members", Action = "",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=70,Display=true},
                /*72*/new Menus {Name = "View designs of member", Controller="designs", Action = "designmember",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=70,Display=false},
                /*73*/new Menus {Name = "Edit member", Controller="members", Action = "edit",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=70,Display=false},
                /*74*/new Menus {Name = "Delete member", Controller="members", Action = "delete",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=70,Display=false},
                /*75*/new Menus {Name = "List of contact", Controller="members", Action = "contact",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=70,Display=true},
                
                /*76*/new Menus {Name = "Add designs for exhibition", Controller="designs", Action = "adddesignexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                /*77*/new Menus {Name = "Remove designs of exhibition", Controller="designs", Action = "removedesignexhibition",Role = new List<Roles>(),Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry", ParentID=53,Display=false},
                
                
                            
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
            menu[62].Role.Add(role[0]);
            menu[63].Role.Add(role[0]);
            menu[64].Role.Add(role[0]);
            menu[65].Role.Add(role[0]);
            menu[66].Role.Add(role[0]);
            menu[67].Role.Add(role[0]);
            menu[68].Role.Add(role[0]);
            menu[69].Role.Add(role[0]);
            menu[70].Role.Add(role[0]);
            menu[71].Role.Add(role[0]);
            menu[72].Role.Add(role[0]);
            menu[73].Role.Add(role[0]);
            menu[74].Role.Add(role[0]);
            menu[75].Role.Add(role[0]);
            menu[76].Role.Add(role[0]);


            menu[0].Role.Add(role[1]);
            menu[0].Role.Add(role[2]);

            context.SaveChanges();

            
        }
    }
}