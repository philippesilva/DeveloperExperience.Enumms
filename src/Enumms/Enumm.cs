using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Enumms
{
    public static class Enumm
    {
        public static IEnumerable<string> GetDescriptions<T>()
        {
            var attributes = typeof(T).GetMembers()
                .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>())
                .ToList();

            return attributes.Select(x => x.Description);
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            var fields = typeof(T).GetFields();

            foreach (var field in fields)
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (string.Equals(attribute.Description, description, StringComparison.InvariantCulture))
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException("Enumm - Not found.", nameof(description));
        }
    }
}
