using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PlanningRZA.Web.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<KeyValuePair<string, string>> GetPropertiesDescription(this Type type)
        {
            var propertiesInfo = type.GetProperties();

            foreach (var propertyInfo in propertiesInfo)
            {
                var propertyName = propertyInfo.Name.FirstLetterToLowerCase();
                var _Attribs = propertyInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    var attributeValue = ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                    yield return KeyValuePair.Create(propertyName, attributeValue);
                }
            }
        }

        private static string FirstLetterToLowerCase(this string input)
        {
            return $"{Char.ToLowerInvariant(input[0])}{input.Substring(1)}";
        }

    }
}
