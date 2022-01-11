using System;
using System.Net.Mail;

namespace Alligator.UI.Helpers
{
    public static class UserInputValidation
    {
        public static bool EmailValidation(string mail)
        {
            try
            {
                MailAddress m = new MailAddress(mail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}