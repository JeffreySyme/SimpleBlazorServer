using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlazorServer.Web.Extensions
{
    public static class QueryStringHelpers
    {
        public static T ParseQuery<T>(string queryString) where T : new()
        {
            var dictionary = QueryHelpers.ParseQuery(queryString);
            var obj = new T();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (dictionary.TryGetValue(property.Name.ToLower(), out StringValues stringValues))
                {
                    var value = Parse(stringValues, property.PropertyType);

                    if (value == null)
                        continue;

                    property.SetValue(obj, value, null);
                }
            }
            return obj;
        }
        private static object Parse(IEnumerable<string> stringValues, Type type)
        {
            if (type == typeof(int?) || type == typeof(int))
                return int.TryParse(stringValues.FirstOrDefault(), out int value) ? (int?)value : null;
            if (type == typeof(string))
                return stringValues.FirstOrDefault();
            if (type.GetGenericTypeDefinition().GetInterfaces().Any(i => i == typeof(IEnumerable)))
            {
                var listType = type.GetGenericArguments()[0];
                var result = stringValues.Select(sv => Parse(new List<string> { sv }, listType));

                if (listType == typeof(int?))
                    return result.Cast<int?>();
                if (listType == typeof(int))
                    return result.Cast<int>();
                if (listType == typeof(string))
                    return result.Cast<string>();

                return result;
            }

            return null;
        }
    }
}
