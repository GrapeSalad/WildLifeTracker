using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WildLifeTracker.Models
{
    public class WildlifeTrackerContext : DbContext
    {
        public class ViewSpecS
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Sighting> Sightings { get; set; }

        public ActionResult Both()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WildlifeTracker;integrated security=True");
        }
    }
}
