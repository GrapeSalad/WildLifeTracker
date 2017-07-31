using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WildLifeTracker.Models
{
    [Table("species")]
    public class Species
    {
        [Key]
        public int speciesId { get; set; }
        public string name { get; set; }
    }
}
