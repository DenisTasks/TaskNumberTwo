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
            string lineWithBuffer = inputline;
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
                if (sepIndex.FirstOrDefault(x => x > 0) > 0)
                {
                    sentenceString.Add((lineWithBuffer.Substring(0, sepIndex.FirstOrDefault(x => x > 0) + 1)));
                    lineWithBuffer = lineWithBuffer.Substring(sepIndex.FirstOrDefault(x => x > 0) + 1);
                    _buffer = lineWithBuffer;
                }
                else
                {
                    _buffer = lineWithBuffer;
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
