using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Q_A_system.Models
{
    public class Answer
    {
       
        public int Id { get; set; }
        [Required]
        public string answer { get; set; }

        public int QId { get; set; }
        public Quation Quation { get; set; }
    }
}
