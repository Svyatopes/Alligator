using Alligator.UI.VIewModels.TabItemsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.UI.Commands.TabItemClients
{
    public static class TextBoxesValidation
    {
        public static string invalidSymbols = "1234567890-=!@#$%^&*()_+ ";
        public static string validSymbols = "1234567890";
        public static string validMail = "@";
        public static bool EmailValidation(string mail)
        {
            bool valid = true;
            string textTrim = mail.Trim();
            if (!textTrim.Contains(validMail))
            {
                valid = false;

            }
            else
            {
                valid = true;
            }
            return valid;
        }
        public static bool PhoneNumberValidation(string number)
        {
            bool valid = true;
            string textTrim = number.Trim();
            foreach (var item in validSymbols)
            {
                if (!textTrim.Contains(item))
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }
        public static bool ClientsNameValidation(string text)
        {
            bool isValid = true;
            string textTrim = text.Trim();
            foreach (var item in invalidSymbols)
            {

                if (textTrim.Contains(item))
                {
                    isValid = false;
                    break;
                }

            }
            return isValid;
        }
    }
}
