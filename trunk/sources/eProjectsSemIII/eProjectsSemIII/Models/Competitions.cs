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

        public ICollection<Members> Staffs { get; set; }

        //many to many
        public virtual ICollection<Conditions> Condition { get; set; }
        public ICollection<Awards> Award { get; set; }

        // many to many with competion
        public ICollection<Kinds> Kind { get; set; }

        //one to many with design
        public ICollection<Designs> Design { get; set; }

        /**
         * Function: ListAllCompetition
         * @param name="skip": The number of elements to skip before returning the remaining elements.
         * @param name="take": The number of elements to return.
         * Return: List Competition
         * Author: Le Dang Son
         * Date: 09/08/2012
         */

        public List<Competitions> ListCompetition(int skip, int take)
        {
            return new FineArtContext().Competitions.OrderBy(o => o.StartDate).Skip(skip).Take(take).ToList();
        }

        public Competitions ListNavigation(string navigation)
        {
            return new FineArtContext().Competitions.Include(navigation).Where(c=>c.ID == this.ID).FirstOrDefault();
        }


        public int TotalCompetition()
        {
            return new FineArtContext().Competitions.Count();
        }

        public Competitions GetCompetitionWithID()
        {
            return new FineArtContext().Competitions.Where(c => c.ID == this.ID).FirstOrDefault();
        }
    }
}