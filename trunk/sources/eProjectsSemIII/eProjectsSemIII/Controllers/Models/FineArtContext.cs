using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eProjectsSemIII.Models
{
    public class FineArtContext:DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //competition jion condition
        //    modelBuilder.Entity<Competitions>().
        //      HasMany(c => c.Condition).
        //      WithMany(p => p.Competition).
        //      Map(
        //       m =>
        //       {
        //           m.MapLeftKey("CompetitionID");
        //           m.MapRightKey("ConditionID");
        //           m.ToTable("CompetitionCondition");
        //       });
        //    //competion jion student
        //    modelBuilder.Entity<Competitions>().
        //      HasMany(c => c.Student).
        //      WithMany(p => p.Competition).
        //      Map(
        //       m =>
        //       {
        //           m.MapLeftKey("CompetitionID");
        //           m.MapRightKey("StudentID");
        //           m.ToTable("CompetitionStudent");
        //       });

            //competition jion award
            //modelBuilder.Entity<Competitions>().
            //  HasMany(c => c.Award).
            //  WithMany(p => p.Competition).
            //  Map(
            //   m =>
            //   {
            //       m.MapLeftKey("CompetitionID");
            //       m.MapRightKey("AwardID");
            //       m.ToTable("CompetitionAward");
               

            //   });
         
             

        //    //competion jion design
        //    modelBuilder.Entity<Competitions>().
        //      HasMany(c => c.Design).
        //      WithMany(p => p.Competition).
        //      Map(
        //       m =>
        //       {
        //           m.MapLeftKey("CompetitionID");
        //           m.MapRightKey("DesignID");
        //           m.ToTable("CompetitionDesign");
        //       });

        //    //competion jion staff
        //    modelBuilder.Entity<Competitions>().
        //      HasMany(c => c.Staff).
        //      WithMany(p => p.Competition).
        //      Map(
        //       m =>
        //       {
        //           m.MapLeftKey("CompetitionID");
        //           m.MapRightKey("StaffID");
        //           m.ToTable("CompetitionStaff");
        //       });

        //    //student jion award
        //    modelBuilder.Entity<Students>().
        //      HasMany(c => c.Award).
        //      WithMany(p => p.Student).
        //      Map(
        //       m =>
        //       {
        //           m.MapLeftKey("StudentID");
        //           m.MapRightKey("AwardID");
        //           m.ToTable("StudentAward");
        //       });



        //}
        public FineArtContext()
            : base("FineArtDb")
        {

        }
       
        public DbSet<Awards> Awards { get; set; }
        public DbSet<Classs> Classs { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Conditions> Conditions { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Designs> Designs { get; set; }
        public DbSet<Exhibitions> Exhibitions { get; set; }
        public DbSet<Kinds> Kinds { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Students> Students { get; set; }
    }

}