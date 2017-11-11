using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;
using System.Text.RegularExpressions;

namespace TaskNumberTwo.Model
{
    public class Sentence: ISentence
    {
        private readonly List<ISentenceItem> _sentenceItems;
        public Sentence()
        {
            _sentenceItems = new List<ISentenceItem>();
        }
        public void Add(ISentenceItem item)
        {
            _sentenceItems.Add(item);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in _sentenceItems)
            {
                if (item.TypeOfItem == TypeOfItem.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(item.WordOrPunctuationValue);
            }
            builder.Remove(0, 1);
            return builder.ToString();
        }
    }
}
