using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EC.SystemExtensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Obter a descrição que há em cada item do enum, definido pelo atributo "Description".
        /// </summary>
        /// <param name="value">Item do enum.</param>
        /// <returns>Valor declarado no item do enum.</returns>
        public static String GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            return GetDescriptionBy(field) ?? value.ToString();
        }

        public static IDictionary<String, Object> GetDescriptionsValues(this Type type)
        {
            var result = new Dictionary<String, Object>();

            foreach(var item in GetEnumItems(type))
            {
                var field = type.GetField(item.Key);
                var description = GetDescriptionBy(field) ?? item.Key;

                result.Add(description, item.Value);
            }

            return result;
        }

        public static IEnumerable<KeyValuePair<String, Object>> GetEnumItems(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (!type.IsEnum)
                throw new ArgumentException("Parameter should by enum type.", "type");

            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);

            for (var i = 0; i < names.Length; i++)
            {
                yield return new KeyValuePair<String, Object>((String)names.GetValue(i), values.GetValue(i));
            }
        }

        private static String GetDescriptionBy(MemberInfo member)
        {
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute));
            return attribute == null ? null : attribute.Description;
        }
    }
}