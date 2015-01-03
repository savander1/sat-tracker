using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sat_tracker.parser;
using sat_tracker.core.Entities;

namespace sat_tracker.tests.Parser
{
    [TestClass]
    public class VerboseParserTests
    {
        private VerboseParser _verboseParser;

        [TestInitialize]
        public void Setup()
        {
            _verboseParser = new VerboseParser();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parse_ArgIsNull_ThrowsException()
        {
            // arrange

            // act
            _verboseParser.Parse(null);
        }

        [TestMethod]
        public void Parse_ArgIsEmptyString_ReturnsEmptyList()
        {
            // arrange
            const string fileContent = "";

            // act
            var result = _verboseParser.Parse(fileContent);

            // assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void Parse_OneInvalidSatellitePassed_NoSatellitesReturned()
        {
            //arrange
            var fileContent = GetIncompleteFile();

            // act
            var result = _verboseParser.Parse(fileContent);

            // assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void Parse_OneValidSatellitePassed_OneSatelliteReturned()
        {
            //arrange
            var fileContent = GetCompleteFile();
            var expected = GetExpectedSatellite();

            // act
            var result = _verboseParser.Parse(fileContent).FirstOrDefault();

            // assert
            Assert.IsNotNull(result, "result can not be null");
            Assert.IsTrue(result.ObjectComplete(), "ObjectComplete()");
            Assert.AreEqual(expected.ArgOfPerigee, result.ArgOfPerigee, "ArgOfPerigee");
            Assert.AreEqual(expected.CatalogNumber, result.CatalogNumber, "CatalogNumber");
            Assert.AreEqual(expected.Checksum, result.Checksum, "Checksum");
            Assert.AreEqual(expected.DecayRate, result.DecayRate, "DecayRate");
            Assert.AreEqual(expected.Eccentricity, result.Eccentricity, "Eccentricity");
            Assert.AreEqual(expected.ElementSet, result.ElementSet, "ElementSet");
            Assert.AreEqual(expected.EpochRev, result.EpochRev, "EpochRev");
            Assert.AreEqual(expected.EpochTime, result.EpochTime, "EpochTime");
            Assert.AreEqual(expected.Inclination, result.Inclination, "Inclination");
            Assert.AreEqual(expected.MeanAnomaly, result.MeanAnomaly, "MeanAnomaly");
            Assert.AreEqual(expected.MeanMotion, result.MeanMotion, "MeanMotion");
            Assert.AreEqual(expected.Name, result.Name, "Name");
            Assert.AreEqual(expected.RAofNode, result.RAofNode, "RAofNode");
        }

        private static string GetCompleteFile()
        {
            return @"SB KEPS @ AMSAT  $ORB15001.O
Orbital Elements  15001.OSCAR

HR AMSAT ORBITAL ELEMENTS FOR OSCAR SATELLITES
FROM WA5QGD FORT WORTH,TX January 1, 2015
BID: ORB15001.O
TO ALL RADIO AMATEURS BT

Satellite: AO-07
Catalog number: 07530
Epoch time:      14365.96416624
Element set:     157
Inclination:      101.4991 deg
RA of node:       341.4640 deg
Eccentricity:    0.0011635
Arg of perigee:   269.4368 deg
Mean anomaly:     124.4812 deg
Mean motion:   12.53610824 rev/day
Decay rate:       -4.5e-07 rev/day^2
Epoch rev:           83630
Checksum:              288
";
        }

        private static string GetIncompleteFile()
        {
            var complete = GetCompleteFile();
            var halfLength = complete.Length / 2;
            return complete.Take(halfLength).ToString();
        }

        private static SatelliteModel GetExpectedSatellite()
        {
            return new SatelliteModel
            {
                Name = "AO-07",
                CatalogNumber = "07530",
                EpochTime = 14365.96416624,
                ElementSet = "157",
                Inclination = 101.4991,
                RAofNode = 341.4640,
                Eccentricity = 0.0011635,
                ArgOfPerigee = 269.4368,
                MeanAnomaly = 124.4812,
                MeanMotion = 12.53610824,
                DecayRate = -0.00000045,
                EpochRev = 83630,
                Checksum = 288
            };
        }
    }
}
