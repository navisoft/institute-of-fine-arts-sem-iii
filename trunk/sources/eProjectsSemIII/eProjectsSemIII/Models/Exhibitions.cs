using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Exhibitions
    {
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
        public string Alias { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public ICollection<Designs> Designs { get; set; }


        // relationship many to many with design and Customers
         public int TotalExhibition()
         {
             return new FineArtContext().Exhibitions.Count();
         }
         public List<Exhibitions> ListExhibition(int skip, int take)
         {
             return new FineArtContext().Exhibitions.OrderBy(e => e.ID).Skip(skip).Take(take).ToList();
         }

         public Exhibitions GetNavigationWithID(string navigation)
         {
             return new FineArtContext().Exhibitions.Include(navigation).Where(e => e.ID == this.ID).FirstOrDefault();
         }
    }
}