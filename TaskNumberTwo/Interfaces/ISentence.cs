using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskNumberTwo.Interfaces
{
    public interface ISentence
    {
        void Add(ISentenceItem item);
        int WordsInSentence();
        bool FindQuestionSentence();
        ICollection<ISentenceItem> GetCurrentWords(int x);
        void DeleteWords(int x);
        void ReplaceThisWords(int x, string s);
    }
}
