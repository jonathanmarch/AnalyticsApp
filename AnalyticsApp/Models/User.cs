using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsApp.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public User()
        {
            Websites = new List<Website>();
        }

        public ICollection<Website> Websites { get; set; }
    }
}
