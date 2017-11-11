using System;
using System.Collections.Generic;
using System.IO;
using TaskNumberTwo.Interfaces;
using TaskNumberTwo.Model;
using TaskNumberTwo.TextReader;
using TaskNumberTwo.TextParser;

namespace Demo
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
            Console.WriteLine();

            Console.WriteLine("_____Task number one:");
            foreach (var item in objectText.WordsInSentence())
            {
                Console.WriteLine("{0}" + " --- have {1} words!", item, item.WordsInSentence());
            }
            Console.WriteLine();

            Console.WriteLine("_____Task number two:");
            foreach (var item in objectText.QuestionWithLength(3))
            {
                Console.WriteLine(item.WordOrPunctuationValue.ToUpper());
            }
            Console.WriteLine();

            Console.WriteLine("_____Task number three:");
            objectText.DeleteWords(7);
            Console.WriteLine(objectText);
            Console.WriteLine();

            Console.WriteLine("_____Task number four:");
            objectText.ReplaceThisWords(0, 5, "{EPAMTaskNumberTwo}");
            Console.WriteLine(objectText);

            Console.ReadLine();

        }
    }
}
