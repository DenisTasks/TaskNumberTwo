using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TaskNumberTwo.Interfaces;
using TaskNumberTwo.Model;
using TaskNumberTwo.TextReader;
using TaskNumberTwo.TextParser;

namespace TaskNumberTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader textreader = new Reader("myExample.txt");
            List<string> charsSentences = textreader.Read();
            IParser parser = new Parser();
            Text objectText = parser.Parse(charsSentences);
            Console.WriteLine(objectText);
            Console.ReadLine();
        }
    }
}
