using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Conditions
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
    
        public string Description { get; set; }
        public DateTime DateUpdate { get; set; }
        // many to many with competition
        public ICollection<Competitions> Competition { get; set; }

        public decimal TotalCondition()
        {
            var db = new FineArtContext();
            return db.Conditions.Count();
        }
        public List<Conditions> ListCondition(int skip, int take)
        {
            var db = new FineArtContext();
            return db.Conditions.OrderBy(c => c.ID).Skip(skip).Take(take).ToList();
        }
    }
}