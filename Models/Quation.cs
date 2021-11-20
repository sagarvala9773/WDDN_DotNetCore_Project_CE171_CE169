using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Q_A_system.Models
{
    public class Quation
    {   
        public int Id { get; set; }
        [Required]
        public string Qtype { get; set; }
        [Required]
        public string Qname { get; set; }
        public ApplicationUser1 ApplicationUser1 { get; set; }

        [ForeignKey("ApplicationUser1")]
        public string userid { get; set; }
        public ICollection<Answer> Answers {get; set;}
    }
}
