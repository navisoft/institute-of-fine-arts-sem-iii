using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eProjectsSemIII.Models
{
    public class FineArtContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
           

            //modelBuilder.Entity<DesignExhibitions>().
            //  HasKey(t => new { t.CustomerID, t.DesignID, t.ExhibitionID });

            //modelBuilder.Entity<AwardMembers>().
            //  HasKey(t => new { t.CompetitionID, t.AwardID, t.MemberID });

            modelBuilder.Entity<Conditions>().
               HasMany(c => c.Competition).
               WithMany(i => i.Condition).
               Map(t =>
                        t.MapLeftKey("ConditionID").
                        MapRightKey("CompetitionID").
                        ToTable("ConditionCompetitions"));

            modelBuilder.Entity<Competitions>().
               HasMany(c => c.Award).
               WithMany(i => i.Competition).
               Map(t =>
                        t.MapLeftKey("AwardID").
                        MapRightKey("CompetitionID").
                        ToTable("CompetitionAwards"));

            modelBuilder.Entity<Classs>().
               HasMany(c => c.Member).
               WithMany(i => i.Class).
               Map(t =>
                        t.MapLeftKey("ClassID").
                        MapRightKey("MemberID").
                        ToTable("ClassMember"));

            modelBuilder.Entity<Roles>().
              HasMany(c => c.Menu).
              WithMany(i => i.Role).
              Map(t =>
                       t.MapLeftKey("RoleID").
                       MapRightKey("MenuID").
                       ToTable("RoleMenus"));      

        }
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
        //public DbSet<DesignExhibitions> DesignExhibitions { get; set; }
        //public DbSet<AwardMembers> AwardMembers { get; set; }
        public DbSet<Menus> Menus { get; set; }
    }

}