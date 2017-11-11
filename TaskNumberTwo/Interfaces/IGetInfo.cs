using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Model;

namespace TaskNumberTwo.Interfaces
{
    public interface IGetInfo
    {
        int GetInfoAboutWord(ISentenceItem item);
    }
}
