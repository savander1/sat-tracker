using sat_tracker.core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace sat_tracker.parser
{
    public class SatelliteModelConfigurator
    {
        public static SatelliteModel Configure(SatelliteModel satellite, LineType lineType, string lineValue)
        {
            if (satellite == null) throw new ArgumentNullException("satellite");
            if (string.IsNullOrEmpty(lineValue)) throw new ArgumentNullException("lineValue");

            switch (lineType)
            {
                case LineType.Name:
                    satellite.Name = lineValue;
                    break;
                case LineType.CatalogNumber:
                    satellite.CatalogNumber = lineValue;
                    break;
                case LineType.EpochTime:
                    satellite.EpochTime = GetEpochTime(lineValue);
                    break ;
                case LineType.ElementSet:
                    satellite.ElementSet = lineValue;
                    break;
                case LineType.Inclination:
                    satellite.Inclination = GetDegrees(lineValue);
                    break;
                case LineType.RAofNode:
                    satellite.RAofNode = GetDegrees(lineValue);
                    break;
                case LineType.Eccentricity:
                    satellite.Eccentricity = GetDegrees(lineValue);
                    break;
                case LineType.ArgOfPerigee:
                    satellite.ArgOfPerigee = GetDegrees(lineValue);
                    break;
                case LineType.MeanAnomaly:
                    satellite.MeanAnomaly = GetDegrees(lineValue);
                    break;
                case LineType.MeanMotion:
                    satellite.MeanMotion = GetDegrees(lineValue);
                    break;
                case LineType.DecayRate:
                    satellite.DecayRate = GetDecayRate(lineValue);
                    break;
                case LineType.EpochRev:
                    satellite.EpochRev = int.Parse(lineValue);
                    break;
                case LineType.Checksum:
                    satellite.Checksum = int.Parse(lineValue);
                    break;
            }

            return satellite;
        }

        private static double GetEpochTime(string value)
        {
            return double.Parse(value, NumberStyles.Any);
        }

        private static double GetDegrees(string value)
        {
            var toParse = Regex.Replace(value, "[a-zA-Z/]", "").Trim();
            return double.Parse(toParse, NumberStyles.Any);
        }

        private static double GetDecayRate(string value)
        {
            var toParse = Regex.Replace(value, "rev/day\\^2", "").Trim();
            return double.Parse(toParse, NumberStyles.Any);
        }
    }
}
