using Alligator.BusinessLayer;

namespace Alligator.UI.Helpers
{
    public static class ClientValidation
    {
        public static bool TrimAndCheckIsValid(ClientModel client)
        {
            TrimAllStringProperties(client);
            if (!UserInputValidation.EmailValidation(client.Email))
                return false;
            return client.IsValid();
        }

        public static void TrimAllStringProperties(ClientModel client)
        {
            foreach (var property in client.GetType().GetProperties())
            {
                if(property.PropertyType == typeof(string))
                {
                    property.SetValue(client, ((string)property.GetValue(client)).Trim());
                }
            }
        }
    }
}
