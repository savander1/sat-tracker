using sat_tracker.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace sat_tracker.parser
{
    public class SatelliteModelConfigurator
    {
        public SatelliteModel Configure(SatelliteModel satellite, LineType lineType, string lineValue)
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
                    break;GetDegrees(lineValue);
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
                    satellite.DecayRate = lineValue;
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
            return double.Parse(value);
        }

        private static decimal GetDegrees(string value)
        {
            var toParse = Regex.Replace(value, "[a-zA-Z]", "");
            return decimal.Parse(toParse);
        }

        private static decimal GetDecayRate(string value)
        {

        }
    }
}
