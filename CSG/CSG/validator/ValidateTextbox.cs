using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CSG.validator
{
    class ValidateTextbox
    {
        //1-Solo letras con espacios (Nombres, etc)
        //2-Solo letras sin espacios (NIT)
        //3-Solo números con espacios 1 2 3 4 5
        //4-Solo números sin espacios 12345
        //5-Numero y letras sin espacios abc12345

        //1
        public static void LetterSpace(KeyPressEventArgs key)
        {
            if (char.IsLetter(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsSeparator(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsControl(key.KeyChar))
            {
                key.Handled = false;
            }
            else
            {
                key.Handled = true;
            }
        }

        //2
        public static void LetterNoSpace(KeyPressEventArgs key)
        {
            if (char.IsLetter(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsControl(key.KeyChar))
            {
                key.Handled = false;
            }
            else
            {
                key.Handled = true;
            }
        }
        //3
        public static void NumericSpace(KeyPressEventArgs key)
        {
            if (char.IsDigit(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsSeparator(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsControl(key.KeyChar))
            {
                key.Handled = false;
            }
            else
            {
                key.Handled = true;
            }
        }
        //4
        public static void NumericNoSpace(KeyPressEventArgs key)
        {
            if (char.IsDigit(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsControl(key.KeyChar))
            {
                key.Handled = false;
            }
            else
            {
                key.Handled = true;
            }
        }

        //5
        public static void LetterAndNumericNoSpace(KeyPressEventArgs key)
        {
            if (char.IsLetterOrDigit(key.KeyChar))
            {
                key.Handled = false;
            }
            else if (char.IsControl(key.KeyChar))
            {
                key.Handled = false;
            }
            else
            {
                key.Handled = true;
            }
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, 
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
