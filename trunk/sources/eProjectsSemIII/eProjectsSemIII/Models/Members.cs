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
        [Required]
       
        public string Name { get; set; }
        [Required]
    
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]

        public string Gender { get; set; }

         [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

         [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Datejoin { get; set; }

        //one to many with Role
        //reference with role
        public int RoleID { get; set; }
        //navigation property
        public Roles Role { get; set; }

        //one to many with design
        //navigation property
        public ICollection<Designs> Design { get; set; }

        //many to many with class
        //navigation property
        public ICollection<Classs> Class { get; set; }

        public Members GetMemberByUserAndPass(string user, string pass)
        {
            FineArtContext context = new FineArtContext();
            var query = (from d in context.Members
                        where d.Username == user && d.Password == pass
                        select d).FirstOrDefault();
            return query;
        }
    }
}