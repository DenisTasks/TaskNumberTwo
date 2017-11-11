using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;
using TaskNumberTwo.Model;
using System.Text.RegularExpressions;

namespace TaskNumberTwo.TextParser
{
    public class Parser : IParser
    {
        private string _buffer;
        public Text Parse(List<string> fromReader)
        {
            Text finishedText = new Text();
            foreach (string sentence in fromReader)
            {
                string inline = sentence.Substring(1, sentence.Length - 1);
                string pattern = @"\s+|\t+";
                _buffer = new Regex(pattern).Replace(inline, " ");
                ISentence objectSentence = new Sentence();
                while (_buffer.Length > 0)
                {
                    char[] sentenceCharArray = _buffer.ToCharArray(0, _buffer.Length);
                    List<int> separatorsIndex = new List<int>();
                    foreach (var item in new SeparatorWord().FindSeparator())
                    {
                        for (int i = 0; i < sentenceCharArray.Length; i++)
                        {
                            if (item == sentenceCharArray[i])
                            {
                                separatorsIndex.Add(i + 1);
                            }
                        }
                    }
                    separatorsIndex.Sort();
                    if (separatorsIndex.Count >= 1)
                    {
                        objectSentence.Add(new SentenceItem(_buffer.Substring(0, separatorsIndex.FirstOrDefault(x => x >= 0) - 1), TypeOfItem.Word));
                        _buffer = _buffer.Substring(separatorsIndex.FirstOrDefault(x => x >= 0));
                    }
                    else
                    {
                        objectSentence.Add(new SentenceItem(_buffer.Substring(0, _buffer.Length - 1), TypeOfItem.Word));
                        objectSentence.Add(new SentenceItem(_buffer.Substring(_buffer.Length - 1, 1), TypeOfItem.Punctuation));
                        _buffer = string.Empty;
                    }
                }
                //foreach (Match regex in Regex.Matches(sentence, pattern))
                //{
                //    if (Regex.IsMatch(regex.Value, @"\w+"))
                //    {
                //        objectSentence.Add(new SentenceItem(regex.Value, TypeOfItem.Word));
                //    }
                //    if (Regex.IsMatch(regex.Value, @"\p{P}"))
                //    {
                //        objectSentence.Add(new SentenceItem(regex.Value, TypeOfItem.Punctuation));
                //    }
                //}
                finishedText.Add(objectSentence);
            }
            return finishedText;
        }
    }
}
