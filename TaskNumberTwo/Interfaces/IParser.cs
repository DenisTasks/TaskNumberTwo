using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Model;

namespace TaskNumberTwo.Interfaces
{
    public interface IParser
    {
        Text Parse(List<string> fromReader);
    }
}
