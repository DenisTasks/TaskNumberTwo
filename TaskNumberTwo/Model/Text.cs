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
        public IEnumerable<ISentence> SentencesToString()
        {
            return _objectSentences;
        }
        public IEnumerable<ISentence> WordsInSentence()
        {
            return _objectSentences.OrderBy(x => x.WordsInSentence());
        }
        public IEnumerable<ISentenceItem> QuestionWithLength(int x)
        {
            List<ISentenceItem> questionOut = new List<ISentenceItem>();
            foreach (var item in _objectSentences)
            {
                if (item.FindQuestionSentence())
                {
                    ICollection<ISentenceItem> questionIn = item.GetCurrentWords(x);
                    questionOut.AddRange(questionIn);
                }
            }
            return questionOut;
        }
        public void DeleteWords(int x)
        {
            foreach (var item in _objectSentences)
            {
                item.DeleteWords(x);
            }
        }
        public void ReplaceThisWords(int sentenceIndex, int searchLenght, string newWord)
        {
            if (_objectSentences.ElementAt(sentenceIndex) != null)
            {
                _objectSentences.ElementAt(sentenceIndex).ReplaceThisWords(searchLenght, newWord);
            }
        }
    }
}
