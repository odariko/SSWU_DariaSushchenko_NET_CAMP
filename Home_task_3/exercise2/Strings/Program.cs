namespace Strings
{// 1 задача.Симулятор має помпу, має usera і їх створює. тому мала бути композиція з зафарбованими  ромбиками до симулятора
    internal class Program
    {
        static void Main(string[] args)
        {
            StringsWork stringsWork = new StringsWork();
            // тут ще одне словечко міняти треба
            string text = "I am a lazzy frog am I";
            string substring = "am";
            string replacement = "productive";

            Console.WriteLine("Second substring in " + stringsWork.FindSecondSubstringIndex(text, substring));
            Console.WriteLine("Found capitalized words " + stringsWork.CountCapitalizedWords(text));
            Console.WriteLine(stringsWork.ReplaceWordsWithDoubledLetters(text, replacement));
        }
    }
}
