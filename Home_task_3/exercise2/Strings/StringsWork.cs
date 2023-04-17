using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class StringsWork
    {
        public int? FindSecondSubstringIndex(string text, string substring)
        {
            int firstIndex = text.IndexOf(substring);
            if (firstIndex == -1)
            {
                return null;
            }

            int secondIndex = text.IndexOf(substring, firstIndex + 1);
            if (secondIndex == -1)
            {
                return null;
            }

            return secondIndex;
        }

        public int CountCapitalizedWords(string text)
        {
            int count = 0;
            // Можна використати в Split другий параметр. тоді все лаконічніше...
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word) && char.IsUpper(word[0]))
                {
                    count++;
                }
            }

            return count;
        }
// Порушується попередня структура тексту...
        public string ReplaceWordsWithDoubledLetters(string text, string replacement)
        {
            string[] words = text.Split(' ');
            string word = words[0];

            for (int i = 0; i < words.Length; i++)
            {
                word = words[i];

                for (int j = 0; j < word.Length - 1; j++)
                {
                    if (word[j] == word[j + 1])
                    {
                        words[i] = replacement;
                        break;
                    }
                }
            }

            return string.Join(' ', words);
        }
    }
}
