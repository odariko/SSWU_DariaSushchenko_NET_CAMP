using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Text
{
    internal class Parentheses
    {// за умовою задачі мала бути колекція стрічок, яку не можна зливати в одну стрічку(
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
