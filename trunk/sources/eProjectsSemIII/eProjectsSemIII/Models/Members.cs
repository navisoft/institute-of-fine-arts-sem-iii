using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Members
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       [Required(ErrorMessage = "Name is required.")]
       
        public string Name { get; set; }
       [Required(ErrorMessage = "Address is required.")]
    
       public string Address { get; set; }
       public string Images { get; set; }

        public string Phone { get; set; }
       [Required(ErrorMessage = "Gender is required.")]

        public string Gender { get; set; }

         [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

         [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Datejoin { get; set; }

        //one to many with Role
        //reference with role
        //navigation property
        public Roles Role { get; set; }

        //one to many with design
        //navigation property
        public ICollection<Designs> Design { get; set; }

        public ICollection<Competitions> Competitions { get; set; }

        //many to many with class
        //navigation property
        public Classes Class { get; set; }

        /**
         * Function: GetMemberByUserAndPass
         * Get Member by username and password
         * @param name="pass": password
         * @param name="user": username
         * @returns: A member
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public Members GetMemberByUserAndPass(string user, string pass)
        {
            FineArtContext context = new FineArtContext();
            var query = (from d in context.Members
                         where d.Username == user && d.Password == pass
                         select d).FirstOrDefault();
            return query;
        }

        public decimal TotalMember()
        {
            return new FineArtContext().Members.Count();
        }

        public List<Members> ListMembers(int skip, int take)
        {
            return new FineArtContext().Members.Include("Class").Include("Role").OrderBy(m => m.ID).Skip(skip).Take(take).ToList();
        }
        public Members GetMemberWithID()
        {
            return new FineArtContext().Members.Include("Class").Include("Role").Include("Design").Where(m => m.ID == this.ID).FirstOrDefault();
        }
    }
}