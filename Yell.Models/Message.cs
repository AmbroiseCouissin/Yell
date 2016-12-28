using System;

namespace Yell.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal Power { get; set; } // in Watt
        public Tuple<double, double> Position { get; set; } // Latitude, Longitude
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
    }
}
