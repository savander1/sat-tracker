using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sat_tracker.core.Entities;

namespace sat_tracker.parser
{
    public interface IParser
    {
        IEnumerable<SatelliteModel> Parse(string fileContent);
    }
}
