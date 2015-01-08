using System;

namespace EC.SystemExtensions
{
    public static class ConvertExtension
    {
        /// <summary>
        /// Converter valores para para um tipo especificado.
        /// <para>Suporta converção para tipos Nullable[T].</para>
        /// </summary>
        /// <typeparam name="T">Tipo a ser convertido.</typeparam>
        /// <param name="value">Valor a ser convertido.</param>
        /// <returns>Valor convertido para o tipo genérico especificado.</returns>
        public static T Convert<T>(this Object value)
        {
            return Convert<T>(value, default(T));
        }

        /// <summary>
        /// Converter valores para para um tipo especificado.
        /// <para>Suporta converção para tipos Nullable[T].</para>
        /// </summary>
        /// <typeparam name="T">Tipo a ser convertido.</typeparam>
        /// <param name="value">Valor a ser convertido.</param>
        /// <param name="defaultValue">Valor default assumido caso o valor seja nullo, ou vazio em caso de string.</param>
        /// <returns>Valor convertido para o tipo genérico especificado.</returns>
        public static T Convert<T>(this Object value, T defaultValue)
        {
            return (T)Convert(value, defaultValue, typeof(T));
        }

        public static Object Convert(this Object value, Type type)
        {
            return Convert(value, null, type);
        }

        /// <summary>
        /// Converter valores para para um tipo especificado.
        /// </summary>
        /// <param name="value">Valor a ser convertido.</param>
        /// <param name="defaultValue">Valor default assumido caso o valor seja nullo, ou vazio em caso de string.</param>
        /// <param name="type">Tipo de retorno.</param>
        /// <returns>Valor convertido.</returns>
        public static Object Convert(this Object value, Object defaultValue, Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var result = defaultValue;
            if (value != null) //&& (isString && !String.IsNullOrEmpty(strValue)) )
            {
                var strValue = value.GetType().IsString() ? value.ToString() : String.Empty;

                var isNullable = type.IsNullable();
                var convertToType = isNullable ? type.GetGenericArguments()[0] : type;
                var valueConverted = type.IsEnum || (isNullable && convertToType.IsEnum) ? Enum.ToObject(convertToType, strValue[0]) : System.Convert.ChangeType(value, convertToType);
                result = isNullable ? type.GetConstructor(new[] { convertToType }).Invoke(new Object[] { valueConverted }) : valueConverted;
            }

            return result;
        }
    }
}