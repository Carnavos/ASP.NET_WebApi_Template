using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Concert
    {
        public string PerformingArtistName { get; set; }
        public List<Track> Setlist { get; set; }
    }
}
