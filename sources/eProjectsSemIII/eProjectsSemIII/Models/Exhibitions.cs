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

        // relationship many to many with design and Customers
         public int TotalExhibition()
         {
             return new FineArtContext().Exhibitions.Count();
         }
         public List<Exhibitions> ListExhibition(int skip, int take)
         {
             return new FineArtContext().Exhibitions.OrderBy(e => e.ID).Skip(skip).Take(take).ToList();
         }
    }
}