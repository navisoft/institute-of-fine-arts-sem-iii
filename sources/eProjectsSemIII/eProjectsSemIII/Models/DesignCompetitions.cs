using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace eProjectsSemIII.Models
{
    public class DesignCompetitions
    {
        public int DesignId { get; set; }
        public int CompetitionID { get; set; }
        public int MemberID { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePost { get; set; }

        public int Remark { get; set; }
        public int Mark { get; set; }
    }
}