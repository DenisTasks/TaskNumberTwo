using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;

namespace TaskNumberTwo.Model
{
    public class SeparatorWord : IGetSeparator
    {
        private readonly char[] _separators = new char[] { ' ', '-'};

        public IEnumerable<char> FindSeparator()
        {
            return _separators.AsEnumerable();
        }
    }
}