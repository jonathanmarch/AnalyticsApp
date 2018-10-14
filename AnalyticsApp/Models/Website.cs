using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsApp.Models
{
    [Table("Websites")]
    public class Website
    {
        public Website()
        {
            Events = new List<Event>();
        }

        public ICollection<Event> Events { get; set; }

        public Guid WebsiteId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Domain { get; set; }
    }
}
