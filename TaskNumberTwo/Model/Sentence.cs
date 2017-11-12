using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Interfaces;
using System.Text.RegularExpressions;
using TaskNumberTwo.WordInformer;
using System.Runtime.Serialization;

namespace TaskNumberTwo.Model
{
    [Serializable]
    public class Sentence: ISentence
    {
        private readonly List<ISentenceItem> _sentenceItems;
        private readonly IGetInfo _informer;
        public Sentence()
        {
            _sentenceItems = new List<ISentenceItem>();
            _informer = new InformerLenght();
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
        public int WordsInSentence()
        {
            int wordsInSentence = 0;
            for (int i = 0; i < _sentenceItems.Count; i++)
            {
                if (_sentenceItems.ElementAt(i).TypeOfItem == TypeOfItem.Word)
                {
                    wordsInSentence++;
                }
            }
            return wordsInSentence;
        }
        public bool FindQuestionSentence()
        {
            if (_sentenceItems.ElementAt(_sentenceItems.Count - 1).WordOrPunctuationValue == "?")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ICollection<ISentenceItem> GetCurrentWords(int x)
        {
            ICollection<ISentenceItem> questionList = new List<ISentenceItem>();
            foreach (var item in _sentenceItems)
            {
                if (item.TypeOfItem == TypeOfItem.Word
                    && _informer.GetInfoAboutWord(item) == x
                    && !questionList.Any(w => w.WordOrPunctuationValue.ToLower() == item.WordOrPunctuationValue.ToLower()))
                {
                    questionList.Add(item);
                }
            }
            return questionList;
        }
        public void DeleteWords(int x)
        {
            string patternConsonantLetter = @"^[^aeiouy]{1,}";
            for (int i = 0; i < _sentenceItems.Count; i++)
            {
                if (Regex.IsMatch(
                        _sentenceItems.ElementAt(i).WordOrPunctuationValue, patternConsonantLetter, RegexOptions.IgnoreCase)
                    && _sentenceItems.ElementAt(i).TypeOfItem == TypeOfItem.Word
                    && _informer.GetInfoAboutWord(_sentenceItems.ElementAt(i)) == x)
                {
                    _sentenceItems.Remove(_sentenceItems.ElementAt(i));
                    //_sentenceItems.Insert(i, new SentenceItem("{DELETED WORD HERE!}", TypeOfItem.Word));
                    i--;
                }
            }
        }
        public void ReplaceThisWords(int searchLenght, string newWord)
        {
            foreach (var item in _sentenceItems)
            {
                if (item.TypeOfItem == TypeOfItem.Word
                    && _informer.GetInfoAboutWord(item) == searchLenght)
                {
                    item.WordOrPunctuationValue = newWord;
                }
            }
        }
    }
}
