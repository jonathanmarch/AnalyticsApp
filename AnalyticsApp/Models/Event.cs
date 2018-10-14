using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AnalyticsApp.Models
{
    public enum EventTypes
    {
        Unknown,
        Pageload,
        Custom
    }

    public enum PlatformTypes {
        Unknown,
        Windows,
        Mac,
        Linux,
        Android,
        iOS
    }

    public enum BrowserTypes
    {
        Unknown,
        IE,
        Edge,
        Chrome,
        Safari,
        Opera,
        Firefox
    }

    [Table("Events")]
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public EventTypes Type { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [Required]
        public string UserAgent { get; set; }
        [Required]
        public PlatformTypes Platform { get; set; }
        [Required]
        public BrowserTypes Browser { get; set; }
        public string IpAddress { get; set; }
        public string EventData { get; set; }
        public string URL { get; set; }
        public string Path { get; set; }
    }
}
