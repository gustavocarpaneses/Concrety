
using System.ComponentModel;
using System.Reflection;
namespace Concrety.Core.Extensions
{
    public static class TExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            if (fi == null)
                return string.Empty;

            var attribute = (DescriptionAttribute)fi.GetCustomAttributes(typeof(DescriptionAttribute), false)[0];

            if (attribute == null)
                return string.Empty;

            return attribute.Description;
        }
    }
}
