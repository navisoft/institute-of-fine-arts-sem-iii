﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eProjectsSemIII.Models
{
    public class Designs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Images { get; set; }
        //one to many
        public int MemberID { get; set; }
        public Members Member { get; set; }
        //one to many
        public int KindID { get; set; }
        public Kinds Kind { get; set; }

        //one to many
        public int CompetitionID { get; set; }
        public Competitions Competition { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DatePost { get; set; }

        public int Remark { get; set; }
        public int Mark { get; set; }
     
     
    }
}