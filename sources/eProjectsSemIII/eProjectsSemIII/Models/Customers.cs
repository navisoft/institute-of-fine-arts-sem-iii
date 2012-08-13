using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class Customers
    {
        public int ID { get; set; }
       [Required(ErrorMessage = "Name is required.")]
      
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required.")]
      
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
      
        public string Phone { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
     
        public string Gender { get; set; }

        public DateTime DateBuy { get; set; }

        // relationship many to many with design and Exhibitions
        public Designs Design { get; set; }

        public Exhibitions Exhibition { get; set; }
        

       public decimal TotalCustomer()
       {
           return new FineArtContext().Customers.Count();
       }

       internal List<Customers> ListCustomers(int skip, int take)
       {
           return new FineArtContext().Customers.Include("Design").Include("Exhibition").OrderBy(c => c.ID).Skip(skip).Take(take).ToList();
       }
    }
}