using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildLifeTracker.Models
{
    [Table("sightings")]
    public class Sighting
    {
        //public Sighting()
        //{
        //    this.Species = new HashSet<Species> { };
        //}
        [Key]
        public int sightingId { get; set; }
        public DateTime date { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int speciesId { get; set; }
        public virtual Species Species { get; set; }
       
    }
}
