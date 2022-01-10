namespace Alligator.UI.Helpers
{
    public static class WorkWithClasses
    {
        public static void TrimAllStringProperties(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string) && property.GetValue(obj) is not null)
                {
                    property.SetValue(obj, ((string)property.GetValue(obj)).Trim());
                }
            }
        }
    }
}
