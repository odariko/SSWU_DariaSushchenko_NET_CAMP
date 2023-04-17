using System.Security.AccessControl;
using System.Text;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string text = "This is the first sentence. Here is (some information) in\n parentheses, and here is\n another sentence! What about (another piece of information)? And finally, a last sentence.";
            string textukr = "Це перше речення. Тут є (деяка інформація) в дужках, а тут є\n інше речення! Як щодо (іншого шматку інформації)? І нарешті, останнє речення.";
            List<string> result = Parentheses.FindParentheses(text);
            List<string> resultukr = Parentheses.FindParentheses(textukr);

            Console.WriteLine("Sentences containing parentheses:");
            foreach (string sentence in result)
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine("Речення з дужками:");
            foreach (string sentence in resultukr)
            {
                Console.WriteLine(sentence);
            }

        }
    }
}