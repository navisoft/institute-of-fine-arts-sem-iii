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
        //one to many with student and staff.
        public int MemberID { get; set; }
        public Members Member { get; set; }

        // one to many
        public int StaffID { get; set; }

        //one to many
        public int KindID { get; set; }
        public Kinds Kind { get; set; }

        //one to many
        public int CompetitionID { get; set; }
        public Competitions Competition { get; set; }
        public Awards Award { get; set; }
        public bool IsSold { get; set; }
        public decimal PriceSold { get; set; }
        public bool IsPaidStudent { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePost { get; set; }

        public int Remark { get; set; }
        public int Mark { get; set; }

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
    }
}