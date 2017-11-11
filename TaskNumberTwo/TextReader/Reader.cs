using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TaskNumberTwo.Interfaces;

namespace TaskNumberTwo.TextReader
{
    public class Reader : IReader
    {
        private readonly string _filePath;
        private string _buffer = "";

        public Reader(string filePath)
        {
            _filePath = filePath;
        }

        public List<string> Read()
        {
            List<string> finishedRead = new List<string>();
            using (StreamReader textReader = new StreamReader(new FileStream(_filePath, FileMode.Open), Encoding.Default))
            {
                while (!textReader.EndOfStream)
                {
                    string eachLine = textReader.ReadLine();
                    finishedRead.AddRange(SentenceString(eachLine, textReader.EndOfStream));
                }
            }
            return finishedRead;
        }
        private List<string> SentenceString(string inputline, bool endOfStream)
        {
            inputline = string.Join(" ", _buffer, inputline);
            //  Console.WriteLine(inputline);
            string lineWithBuffer = inputline;
            //  Console.WriteLine(lineWithBuffer);
            List<string> sentenceString = new List<string>();
            while (lineWithBuffer.Length > 0)
            {
                char[] separators = new char[] { '.', '!', '?' };
                List<int> sepIndex = new List<int>();
                foreach (var item in separators)
                {
                    sepIndex.Add(lineWithBuffer.IndexOf(item));
                }
                sepIndex.Sort();
                //foreach (var item in sepIndex)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.ReadKey();
                if (sepIndex.FirstOrDefault(x => x > 0) > 0)
                {
                    //Console.WriteLine("lineWithBuffer= " + lineWithBuffer);
                    sentenceString.Add((lineWithBuffer.Substring(0, sepIndex.FirstOrDefault(x => x > 0) + 1)));
                    //foreach (var item in sentenceString)
                    //{
                    //    Console.WriteLine("sentenceString=" + item);
                    //}
                    lineWithBuffer = lineWithBuffer.Substring(sepIndex.FirstOrDefault(x => x > 0) + 1);
                    _buffer = lineWithBuffer;
                    //Console.WriteLine("buffer" + buffer);
                    //Console.ReadKey();
                }
                else
                {
                    _buffer = lineWithBuffer;
                    //Console.WriteLine("buffer" + buffer);
                    //Console.ReadKey();
                    if (endOfStream)
                    {
                        sentenceString.Add(lineWithBuffer);
                    }
                    break;
                }
            }
            return sentenceString;
        }
    }
}
