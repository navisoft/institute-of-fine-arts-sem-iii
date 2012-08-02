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
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Awards> Awards { get; set; }
        public DbSet<Conditions> Conditions { get; set; }
    }
}