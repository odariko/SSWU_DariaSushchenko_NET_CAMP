using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Email
{
    internal class EmailValidator
    {
        public static List<string> Validation(string text)
        {
            List<string> validEmails = new List<string>();
//Між словами могло бути і кілька пропусків, а це вами не враховано
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (word.Contains('@'))
                {
                    if (IsValidEmail(word))
                    {
                        validEmails.Add(word);
                    }
                }
            }

            return validEmails;
        }

        static bool IsValidEmail(string email)
        {
            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            string local_part = parts[0];
            string domain = parts[1];
            string[] domainParts = domain.Split('.');

            if (domainParts.Length < 2)
            {
                return false;
            }
// ці константи краще винести за тіло методу, щоб їх при потребі легко можна було змінити
            if (local_part.Length < 1 || local_part.Length > 64)
            {
                return false;
            }

            if (domain.Length < 1 || domain.Length > 255)
            {
                return false;
            }

            if (local_part[0] == '.' || local_part[local_part.Length - 1] == '.') return false;

            for (int i = 0; i < local_part.Length - 1; i++)
            {
                if (local_part[i] == '.' && local_part[i] == local_part[i + 1])
                {
                    return false;
                }
            }

            foreach (char c in local_part)
            {// Тут можна скористатись методом Containce
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-' && c != '!' && c != '#' && c != '$' && c != '%'
                    && c != '&' && c != '\'' && c != '*' && c != '+' && c != '/' && c != '=' && c != '?' && c != '^' && c != '`'
                    && c != '{' && c != '|' && c != '}' && c != '~')
                {
                    return false;
                }
            }

            if (domain[0] == '-' || domain[domain.Length - 1] == '-') return false;

            return true;
        }

        public static List<string> ValidationRegex(string text)
        {
            List<string> validEmails = new List<string>();

            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                if (word.Contains('@'))
                {
                    if (IsValidEmailRegex(word))
                    {
                        validEmails.Add(word);
                    }
                }
            }

            return validEmails;
        }

        static bool IsValidEmailRegex(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
// Цей регулярний вираз не годиться до заданої умови!
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }
}
