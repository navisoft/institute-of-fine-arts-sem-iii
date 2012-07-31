using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace eProjectsSemIII.Models
{
    public class FineArtContext:DbContext
    {
        public FineArtContext()
            : base("FineArtDb")
        {

        }
        public DbSet<CompetitionModels> Competitions { get; set; }
        public DbSet<AwardModels> Awards { get; set; }
        public DbSet<ConditionModels> Conditions { get; set; }
    }
}