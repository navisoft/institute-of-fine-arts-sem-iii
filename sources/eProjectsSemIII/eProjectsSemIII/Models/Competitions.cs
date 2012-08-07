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

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Images { get; set; }
        //many to many
        public ICollection<Conditions> Condition { get; set; }
        public ICollection<Awards> Award { get; set; }
        public List<Competitions> getAllCompetition()
        {
            List<Competitions> listCompetition = new List<Competitions>();
            using (var db = new FineArtContext())
            {
                listCompetition = db.Competitions.ToList();
            }
            return listCompetition;
        }
    }
}