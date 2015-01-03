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
        public double Inclination { get; set; }
        public double RAofNode { get; set; }
        public double Eccentricity { get; set; }
        public double ArgOfPerigee { get; set; }
        public double MeanAnomaly { get; set; }
        public double MeanMotion { get; set; }
        public double DecayRate { get; set; }
        public int EpochRev { get; set; }
        public int Checksum { get; set; }

        public bool ObjectComplete()
        {
            return HasValue(Name) &&
                   HasValue(CatalogNumber) &&
                   HasValue(EpochTime) &&
                   HasValue(ElementSet) &&
                   HasValue(Inclination) &&
                   HasValue(RAofNode) &&
                   HasValue(Eccentricity) &&
                   HasValue(ArgOfPerigee) &&
                   HasValue(MeanAnomaly) &&
                   HasValue(MeanMotion) &&
                   HasValue(DecayRate) &&
                   HasValue(EpochRev) &&
                   HasValue(Checksum);
        }

        private bool HasValue(string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        private bool HasValue(int i)
        {
            return i != 0;
        }

        private bool HasValue(double d)
        {
            return HasValue((decimal)d);
        }

        private bool HasValue(decimal d)
        {
            return d != 0;
        }
    }
}
