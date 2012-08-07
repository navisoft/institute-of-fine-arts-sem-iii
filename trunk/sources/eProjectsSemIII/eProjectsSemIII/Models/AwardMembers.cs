using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class AwardMembers
    {
      
        public int CompetitionID { get; set; }
        public int AwardID { get; set; }
        public int MemberID { get; set; }
        [Required(ErrorMessage = "Remark is required.")]
        public int Remark { get; set; }

    }
}