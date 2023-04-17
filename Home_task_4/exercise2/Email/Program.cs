namespace Email
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "This is a sample text with email1@gmail.com and email2@yahoo.com, as well as some invalid tokens like invalid@address, but with @ symbol.";
            List<string> validEmails = new List<string>();
            validEmails = EmailValidator.Validation(text);

            Console.WriteLine("Valid emails:");
            foreach (string email in validEmails)
            {
                Console.WriteLine(email);
            }

            validEmails= EmailValidator.ValidationRegex(text);
            Console.WriteLine("Valid emails by regular expression:");
            foreach (string email in validEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}