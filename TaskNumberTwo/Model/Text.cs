using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;

namespace TaskNumberTwo.Model
{
    public class Text
    {
        private readonly ICollection<ISentence> _objectSentences;
        public Text()
        {
            _objectSentences = new List<ISentence>();
        }
        public void Add(ISentence item)
        {
            _objectSentences.Add(item);
        }
        public override string ToString()
        {
            return string.Join(" ", _objectSentences);
        }
    }
}
