using Alligator.BusinessLayer.Models;

namespace Alligator.UI.Helpers
{
    public static class ClientValidation
    {
        public static bool TrimAndCheckIsValid(ClientModel client)
        {
            WorkWithClasses.TrimAllStringProperties(client);
            if (!UserInputValidation.EmailValidation(client.Email))
                return false;
            return client.IsValid();
        }
    }
}