using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Awards
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public DateTime DateUpdate { get; set; }

        public int Level { get; set; }

        // many to many with competition
        public ICollection<Competitions> Competition { get; set; }

        public List<Awards> ListAward(int skip, int take)
        {
            var db = new FineArtContext();
            return db.Awards.OrderBy(a => a.Name).Skip(skip).Take(take).ToList();
        }

        public decimal TotalAward()
        {
            return new FineArtContext().Awards.Count();
        }
    }
}