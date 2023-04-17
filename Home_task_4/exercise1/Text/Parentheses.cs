using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Text
{
    internal class Parentheses
    {
        public static List<string> FindParentheses(string text)
        {
            char[] separators = new char[] { '.', '!', '?' };
            string[] sentences = text.Replace('\n', '\0').Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Contains("(") && sentence.Contains(")"))
                {
                    result.Add(sentence);
                }
            }

            return result;
        }
    }
}
