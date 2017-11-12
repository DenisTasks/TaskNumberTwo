using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNumberTwo.Model;

namespace Serialization.Interfaces
{
    public interface ISerialized
    {
        void SaveData(Text item);
        Text GetData();
    }
}
