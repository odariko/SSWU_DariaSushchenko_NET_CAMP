namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringsWork stringsWork = new StringsWork();
            string text = "I am a lazzy frog am I";
            string substring = "am";
            string replacement = "productive";

            Console.WriteLine("Second substring in " + stringsWork.FindSecondSubstringIndex(text, substring));
            Console.WriteLine("Found capitalized words " + stringsWork.CountCapitalizedWords(text));
            Console.WriteLine(stringsWork.ReplaceWordsWithDoubledLetters(text, replacement));
        }
    }
}