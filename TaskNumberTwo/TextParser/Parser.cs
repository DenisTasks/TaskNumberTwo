using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;
using TaskNumberTwo.Model;
using System.Text.RegularExpressions;

namespace TaskNumberTwo.TextParser
{
    public class Parser : IParser
    {
        public Text Parse(List<string> fromReader)
        {
            Text finishedText = new Text();
            foreach (string sentence in fromReader)
            {
                string pattern = @"\s+|\t+";
                string withoutTabOrSpaces = new Regex(pattern).Replace(sentence, " ");
                Sentence objectSentence = new Sentence();
                pattern = @"\w+|\p{P}";
                foreach (Match regex in Regex.Matches(withoutTabOrSpaces, pattern))
                {
                    if (Regex.IsMatch(regex.Value, @"\w+"))
                    {
                        objectSentence.Add(new SentenceItem(regex.Value, TypeOfItem.Word));
                    }
                    if (Regex.IsMatch(regex.Value, @"\p{P}"))
                    {
                        objectSentence.Add(new SentenceItem(regex.Value, TypeOfItem.Punctuation));
                    }
                }
                finishedText.Add(objectSentence);
            }
            return finishedText;
        }
    }
}
