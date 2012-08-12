using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Classes
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Alias { get; set; }

        //many to many with members
        public ICollection<Members> Member { get; set; }

        public DateTime DateUpdate { get; set; }


        internal decimal TotalClasses()
        {
            return new FineArtContext().Classes.Count();
        }

        internal List<Classes> ListClasses(int skip, int take)
        {
            return new FineArtContext().Classes.OrderBy(c => c.ID).Skip(skip).Take(take).ToList();
        }
        public Classes GetNavigationWithID(string navigation)
        {
            return new FineArtContext().Classes.Include(navigation).Where(c => c.ID == this.ID).FirstOrDefault();
        }
    }
}