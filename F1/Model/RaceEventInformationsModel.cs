using System.Collections.Generic;

namespace F1.Models
{
    public record RaceEventInformationsModel
    {
        public List<RaceEventModel> Races { get; set; }
    }
}
