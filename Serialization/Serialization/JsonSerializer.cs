using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using TaskNumberTwo.Model;
using Serialization.Interfaces;

namespace Serialization.Serialization
{
    public class JsonSerializer : ISerialized
    {
        private readonly DataContractJsonSerializer _formatter;
        public JsonSerializer()
        {
            _formatter = new DataContractJsonSerializer(typeof(Text));
        }
        public void SaveData(Text item)
        {
            using (FileStream fileStream = new FileStream("myText.json", FileMode.OpenOrCreate))
            {
                _formatter.WriteObject(fileStream, item);
                Console.WriteLine("JsonSerialization was successful!");
                Console.WriteLine();
            }
        }
        public Text GetData()
        {
            using (FileStream fileStream = new FileStream("myText.json", FileMode.OpenOrCreate))
            {
                Text text = (Text)_formatter.ReadObject(fileStream);
                Console.WriteLine("JsonDeserialization was successful!");
                Console.WriteLine();
                return text;
            }
        }
    }
}
