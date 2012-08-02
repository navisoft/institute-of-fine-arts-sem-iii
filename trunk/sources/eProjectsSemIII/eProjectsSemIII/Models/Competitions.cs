using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class Competitions
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

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