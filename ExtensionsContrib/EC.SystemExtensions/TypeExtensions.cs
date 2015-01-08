using System;
using System.Collections.Generic;

namespace EC.SystemExtensions
{
    public static class TypeExtensions
    {
        //private readonly static String NULLABLE_TYPE_NAME = typeof(Nullable<>).Name;

        private readonly static Type GENERIC_NULLABLE_TYPE = typeof(Nullable<>);

        private readonly static String STRING_TYPE_NAME = typeof(String).Name;

        private readonly static Type GENERIC_ENUMERABLE_TYPE = typeof(IEnumerable<>);

        /// <summary>
        /// Indicar se o tipo é do tipo nullable.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Boolean IsNullable(this Type type)
        {
            return type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition() == GENERIC_NULLABLE_TYPE;
        }

        /// <summary>
        /// Identifica se o tipo é string.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Boolean IsString(this Type type)
        {
            return type.Name.Equals(STRING_TYPE_NAME, StringComparison.Ordinal);
        }

        public static Boolean IsEnumerable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == GENERIC_ENUMERABLE_TYPE;
        }

        /// <summary>
        /// Identificar se o tipo implementa a tipo parametrizado.
        /// </summary>
        /// <typeparam name="T">Se implementa o tipo.</typeparam>
        /// <param name="type">Tipo a ser verificado.</param>
        /// <returns>True caso o tipo implementea o tipo.</returns>
        public static Boolean HasImplemented<T>(this Type type)
        {
            var t = typeof(T);
            return t != type && t.IsAssignableFrom(type);
        }
    }
}