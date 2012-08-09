using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Competitions
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeadlineDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Images { get; set; }
        public string Summary { get; set; }

        //many to many
        public ICollection<Conditions> Condition { get; set; }
        public ICollection<Awards> Award { get; set; }

        // many to many with competion
        public ICollection<Kinds> Kind { get; set; }

        //one to many with design
        public ICollection<Designs> Design { get; set; }

        public List<Competitions> ListAllCompetition(int skip, int take)
        {
            var db = new FineArtContext();
            var query = db.Competitions.OrderBy(o=>o.StartDate).Skip(skip).Take(take).ToList();
            return query;
        }
       
    }
}