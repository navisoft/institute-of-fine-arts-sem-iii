using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Designs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Images { get; set; }
        //one to many with member
        public int MemberID { get; set; }
        public Members Member { get; set; }

        // one to many
        public int StaffID { get; set; }

        public bool IsSpecial { get; set; }
        //one to many
        public Kinds Kind { get; set; }

        //one to many
        public int CompetitionID { get; set; }
        public Competitions Competition { get; set; }

        public bool IsSold { get; set; }
        public decimal PriceSold { get; set; }
        public bool IsPaidStudent { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePost { get; set; }
        
        public ICollection<Exhibitions> Exhibitions { get; set; }


        public decimal TotalDesign()
        {
            return new FineArtContext().Designs.Count();
        }
        public List<Designs> ListDesign(int skip, int take)
        {
            var db = new FineArtContext();
            return db.Designs
                .Include("Member")
                .Include("Kind")
                .Include("Competition")
                .OrderBy(d => d.ID).Skip(skip).Take(take).ToList();
        }

        public Designs GetDesignByID()
        {
            return new FineArtContext().Designs
                .Include("Member")
                .Include("Kind")
                .Include("Competition")
                .Where(d => d.ID == this.ID)
                .FirstOrDefault();
        }

        public Designs GetNavigationWithID(string navigation)
        {
            return new FineArtContext()
                .Designs
                .Include(navigation)
                .Where(d => d.ID == this.ID)
                .FirstOrDefault();
        }
    }
}