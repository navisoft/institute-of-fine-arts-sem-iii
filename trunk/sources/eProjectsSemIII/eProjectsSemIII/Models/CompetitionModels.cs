using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProjectsSemIII.Models
{
    public class CompetitionModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<CompetitionModels> getAllCompetition()
        {
            List<CompetitionModels> listCompetition = new List<CompetitionModels>();
            using (var db = new FineArtContext())
            {
                //listCompetition = db.Competitions.ToList();
            }
            return listCompetition;
        }
    }
}