using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_tracker.parser
{
    public enum LineType
    {
        Name,
        CatalogNumber,
        EpochTime,
        ElementSet,
        Inclination,
        RAofNode,
        Eccentricity,
        ArgOfPerigee,
        MeanAnomaly,
        MeanMotion,
        DecayRate,
        EpochRev,
        Checksum,
        Unknown
    }
}
