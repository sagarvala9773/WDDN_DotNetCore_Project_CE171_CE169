using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Q_A_system.Models
{
    public class ApplicationUser1:IdentityUser

    {
        public string Email { get; set; }

        public ICollection<Quation> Quations { get; set; }
    }
}
