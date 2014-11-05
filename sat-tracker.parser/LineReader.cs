using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_tracker.parser
{
    internal class LineReader
    {
        private readonly string[] _lines;
        private readonly IEnumerator _enumerator;

        internal LineReader(string[] lines)
        {
            _lines = lines;
            _enumerator = _lines.GetEnumerator();
        }

        internal bool Read()
        {
            return _enumerator.MoveNext();
        }

        internal string GetLine()
        {
            return ((string)_enumerator.Current).Trim();
        }
    }
}
