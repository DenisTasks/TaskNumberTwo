using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;
using System.Runtime.Serialization;

namespace TaskNumberTwo.Model
{
    [Serializable]
    public class SentenceItem: ISentenceItem
    {
        public string WordOrPunctuationValue { get; set; }
        public TypeOfItem TypeOfItem { get; set; }
        public SentenceItem(string wordOrPunctuation, TypeOfItem typeOfItem)
        {
            this.WordOrPunctuationValue = wordOrPunctuation;
            this.TypeOfItem = typeOfItem;
        }
    }
}
