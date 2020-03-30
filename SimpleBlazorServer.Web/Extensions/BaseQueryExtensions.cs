using SimpleBlazorServer.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SimpleBlazorServer.Web.Extensions
{
    public static class BaseQueryExtensions
    {
        public static string ToQueryString<T>(this T item) where T : BaseQuery 
        {
            var encodedValues = typeof(T)
                .GetProperties()
                .Where(p => p.GetValue(item) != null)
                .Select(p =>
                {
                    var propertyType = p.PropertyType;

                    if (propertyType == typeof(int?))
                        return EncodeValue(p, item);

                    if (!propertyType.IsGenericType)
                        return EncodeValue(p, item);

                    if (propertyType.GetGenericTypeDefinition().GetInterfaces().Any(i => i == typeof(IEnumerable)))
                    {
                        var encodedItems = new List<string>();
                        foreach (var enumeratedValue in p.GetValue(item) as IEnumerable)
                            encodedItems.Add($"{p.Name.ToLower()}={enumeratedValue}");

                        return string.Join("&", encodedItems);
                    }

                    throw new Exception("Unsupported property type for url encoding");
                });

            return string.Join("&", encodedValues);
        }
        private static string EncodeValue<T>(PropertyInfo propertyInfo, T value)
        {
            return $"{propertyInfo.Name.ToLower()}={HttpUtility.UrlEncode(propertyInfo.GetValue(value).ToString())}";
        }
    }
}
