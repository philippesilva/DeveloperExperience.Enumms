using System;
using System.ComponentModel;

namespace Enumms
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T enumValue) where T : Enum
        {
            return GetAttributeValue<T, DescriptionAttribute>(enumValue);
        }

        private static string GetAttributeValue<TEnum, TAttribute>(this TEnum enumValue) where TEnum : Enum
        {
            var fieldName = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(fieldName);

            if (fieldInfo == null) return null;

            var attributes = fieldInfo.GetCustomAttributes(typeof(TAttribute), true);

            return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : null;
        }
    }
}
