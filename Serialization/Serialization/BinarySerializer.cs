using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TaskNumberTwo.Model;
using Serialization.Interfaces;

namespace Serialization.Serialization
{
    public class BinarySerializer : ISerialized
    {
        private readonly BinaryFormatter _formatter;

        public BinarySerializer()
        {
            _formatter = new BinaryFormatter();
        }
        public void SaveData(Text item)
        {
            using (FileStream fileStream = new FileStream("myText.dat", FileMode.OpenOrCreate))
            {
                _formatter.Serialize(fileStream, item);
                Console.WriteLine("BinarySerialization was successful!");
                Console.WriteLine();
            }
        }
        public Text GetData()
        {
            using (FileStream fileStream = new FileStream("myText.dat", FileMode.OpenOrCreate))
            {
                Text text = (Text)_formatter.Deserialize(fileStream);
                Console.WriteLine("BinaryDeserialization was successful!");
                Console.WriteLine();
                return text;
            }
        }
    }
}
