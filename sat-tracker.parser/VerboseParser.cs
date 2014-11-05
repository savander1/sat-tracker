using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sat_tracker.core.Entities;

namespace sat_tracker.parser
{
    public class VerboseParser : IParser
    {
        private const string Separator = ":";

        internal enum LineType
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

        public IEnumerable<SatelliteModel> Parse(string fileContent)
        {
            var lines = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var reader = new LineReader(lines);

            while (reader.Read())
            {
                var currentLine = reader.GetLine();
                var parts = currentLine.Split(Separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    continue;
                }

                var lineType = GetLineType(parts[0].ToLower().Trim());
            }
            
        }

        private LineType GetLineType(string lineStart)
        {
            switch (lineStart)
            {
                case "satellite":
                    return LineType.Name;
                case "catalog number":
                    return LineType.CatalogNumber;
                case "epoch time":
                    return LineType.EpochTime;
                case "element set":
                    return LineType.ElementSet;
                case "inclination":
                    return LineType.Inclination;
                case "ra of node":
                    return LineType.RAofNode;
                case "eccentricity":
                    return LineType.Eccentricity;
                case "arg of perigee":
                    return LineType.ArgOfPerigee;
                case "mean anomaly":
                    return LineType.MeanAnomaly;
                case "mean motion":
                    return LineType.MeanMotion;
                case "decay rate":
                    return LineType.DecayRate;
                case "epoch rev":
                    return LineType.EpochRev;
                case "checksum":
                    return LineType.Checksum;
                default:
                    return LineType.Unknown;
            }
        }

    }
}
