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
        Pageload,
        Custom
    }

    public enum OperatingSytemTypes {
        Windows,
        Mac,
        Linux,
        Android,
        iOs,
        Unknown
    }

    [Table("Events")]
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public EventTypes Type { get; set; }
        [Required]
        public string UserAgent { get; set; }
        [Required]
        public OperatingSytemTypes OS { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public byte[] IPAddressBytes { get; set; }
        public string Location { get; set; }
        public string EventData { get; set; }

        [NotMapped]
        public IPAddress IPAddress
        {
            get { return new IPAddress(IPAddressBytes); }
            set { IPAddressBytes = value.GetAddressBytes(); }
        }
    }
}
