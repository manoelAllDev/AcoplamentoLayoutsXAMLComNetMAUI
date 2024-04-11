using System.Collections.Generic;

namespace F1.Models
{
    public record LapModel
    {
        public int Number { get; set; }
        public List<TimingsModel> Timings { get; set; }
    }
}
