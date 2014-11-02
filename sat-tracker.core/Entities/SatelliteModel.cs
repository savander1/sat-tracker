using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_tracker.core.Entities
{
    public class SatelliteModel
    {
        public string Name { get; set; }
        public string CatalogNumber { get; set; }
        public double EpochTime { get; set; }
        public string ElementSet  { get; set; }
        public decimal Inclination { get; set; }
        public decimal RAofNode { get; set; }
        public decimal Eccentricity { get; set; }
        public decimal ArgOfPerigee { get; set; }
        public decimal MeanAnomaly { get; set; }
        public decimal MeanMotion { get; set; }
        public double DecayRate { get; set; }
        public int EpochRev { get; set; }
        public int Checksum { get; set; }
    }
}
