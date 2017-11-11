using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskNumberTwo.Model;
using TaskNumberTwo.Interfaces;

namespace TaskNumberTwo.WordInformer
{
    public class InformerLenght : IGetInfo
    {
        public int GetInfoAboutWord(ISentenceItem item)
        {
            return item.WordOrPunctuationValue.Length;
        }
    }
}
